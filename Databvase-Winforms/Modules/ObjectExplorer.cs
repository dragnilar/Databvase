using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Models;
using Databvase_Winforms.Services;
using Databvase_Winforms.View_Models;
using DevExpress.Mvvm;
using DevExpress.Utils.Extensions;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Modules
{
    public partial class ObjectExplorer : XtraUserControl
    {
        private List<string> InstancesList { get; set; }

    public ObjectExplorer()
        {
            InitializeComponent();
            if (!mvvmContextObjectExplorer.IsDesignMode)
                InitializeBindings();

            HookupEvents();
            InstancesList = mvvmContextObjectExplorer.GetViewModel<ObjectExplorerViewModel>().GetInstancesList();
            InitializeData();
        }

        private void HookupEvents()
        {

            treeListObjExp.PopupMenuShowing += TreeListObjectExplorerOnPopupMenuShowing;
            treeListObjExp.MouseDown += TreeListObjExpOnMouseDown;
            treeListObjExp.BeforeExpand += TreeListObjExpOnBeforeExpand;

            barButtonItemCopy.ItemClick += CopyCell;
            barButtonItemGenerateSelectAll.ItemClick += ScriptSelectAllForTable;

        }



        private void InitializeData()
        {
            InitInstances(null);
        }



        private void InitInstances(TreeListNode parentNode)
        {
            treeListObjExp.BeginUnboundLoad();
            try
            {
                foreach (var instance in InstancesList)
                {
                    var node = treeListObjExp.AppendNode(new object[]
                    {
                        instance,
                        "Instance",
                        instance,
                        string.Empty
                    }, parentNode);
                    node.StateImageIndex = 0;
                    node.HasChildren = true;
                    node.Tag = "Instance";
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            treeListObjExp.EndUnboundLoad();
        }



        #region TreeList Methods

        private void TreeListObjExpOnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var treeList = sender as TreeList;
            var info = treeList.CalcHitInfo(e.Location);
            if (info?.Node != null)
            {
                treeListObjExp.FocusedNode = info.Node;
            }
        }

        private void TreeListObjectExplorerOnPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var focusedNodeType = treeListObjExp.FocusedNode.GetValue(treeListColumnType).ToString();

            switch (focusedNodeType)
            {
                case "Table":
                    popupMenuTable.ShowPopup(MousePosition);
                    break;
                default:
                    popupMenuObjectExplorer.ShowPopup(MousePosition);
                    break;
            }

        }

        private void TreeListObjExpOnBeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            switch (e.Node.Tag.ToString())
            {
                case "Instance":
                    InitDatabases(e.Node);
                    break;
                case "Database":
                    InitTables(e.Node);
                    break;
                case "Table":
                    InitColumns(e.Node);
                    break;
            }
        }
        #endregion

        private void InitDatabases(TreeListNode parentNode)
        {
            treeListObjExp.BeginUnboundLoad();
            try
            {
                var dbList = SQLServerInterface.GetDatabases();

                if (dbList.Any())
                {
                    foreach (var db in dbList)
                    {
                        var node = treeListObjExp.AppendNode(new object[]
                        {
                            db.Name,
                            "Database",
                            db.Name,
                            string.Empty,
                            db
                        }, parentNode);
                        node.StateImageIndex = 1;
                        node.HasChildren = true;
                        node.Tag = "Database";
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            treeListObjExp.EndUnboundLoad();
        }

        private void InitTables(TreeListNode parentNode)
        {
            treeListObjExp.BeginUnboundLoad();
            try
            {
                var tableList = SQLServerInterface.GetTables(parentNode.GetValue(treeListColumnName).ToString());

                if (tableList.Any())
                {
                    foreach (var table in tableList)
                    {
                        var node = treeListObjExp.AppendNode(new object[]
                        {
                            table.Name,
                            "Table",
                            table.Schema != "dbo" ? $"{table.Schema}.{table.Name}" : table.Name,
                            string.Empty,
                            table
                        }, parentNode);
                        node.StateImageIndex = 2;
                        node.HasChildren = true;
                        node.Tag = "Table";
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            treeListObjExp.EndUnboundLoad();
        }

        private void InitColumns(TreeListNode parentNode)
        {
            treeListObjExp.BeginUnboundLoad();
            try
            {

                var columnList = SQLServerInterface.GetColumns(parentNode.GetValue(treeListColumnName).ToString(), 
                    parentNode.ParentNode.GetValue(treeListColumnName).ToString());

                if (columnList.Any())
                {
                    foreach (var col in columnList)
                    {
                        var node = treeListObjExp.AppendNode(new object[]
                        {
                            col.Name,
                            "Column",
                            col.Name,
                            string.Empty,
                            col
                        }, parentNode);
                        node.StateImageIndex = 3;
                        node.HasChildren = false;
                        node.Tag = "Column";
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            treeListObjExp.EndUnboundLoad();
        }


        private void CopyCell(object sender, EventArgs e)
        {
            Clipboard.SetText(GetFocusedNameCellString());
        }

        private void ScriptSelectAllForTable(object sender, EventArgs e)
        {
            var selectedTable = GetFocusedNameCellString();
            var selectedDatabase = GetFocusedNodeParent();
            mvvmContextObjectExplorer.GetViewModel<ObjectExplorerViewModel>().ScriptSelectAllForTable(selectedTable, selectedDatabase);
        }

        private string GetFocusedNameCellString()
        {
            return treeListObjExp.FocusedNode.GetValue(treeListColumnFullName).ToString();
        }

        private string GetFocusedNodeParent()
        {
            return treeListObjExp.FocusedNode.ParentNode.GetValue(treeListColumnName).ToString();
        }

        private void InitializeBindings()
        {
            var fluent = mvvmContextObjectExplorer.OfType<ObjectExplorerViewModel>();
            //fluent.EventToCommand<VirtualTreeGetChildNodesInfo>(treeListObjExp, "VirtualTreeGetChildNodes",
            //    x => x.GetNodesForObjectExplorer(null));
            //fluent.EventToCommand<VirtualTreeGetCellValueInfo>(treeListObjExp, "VirtualTreeGetCellValue",
            //    x => x.GetCellValue(null));

        }
    }
}