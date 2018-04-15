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

    public ObjectExplorer()
        {
            InitializeComponent();
            if (!mvvmContextObjectExplorer.IsDesignMode)
                InitializeBindings();

            HookupEvents();
            InitInstances();
        }

        private void HookupEvents()
        {

            treeListObjExp.PopupMenuShowing += TreeListObjectExplorerOnPopupMenuShowing;
            treeListObjExp.MouseDown += TreeListObjExpOnMouseDown;
            treeListObjExp.BeforeExpand += TreeListObjExpOnBeforeExpand;

            barButtonItemCopy.ItemClick += CopyCell;
            barButtonItemGenerateSelectAll.ItemClick += ScriptSelectAllForTable;

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

        #region Tree List Unbound Methods

        private void InitInstances()
        {
            treeListObjExp.BeginUnboundLoad();
            try
            {
                foreach (var instance in mvvmContextObjectExplorer.GetViewModel<ObjectExplorerViewModel>().GetInstancesList())
                {
                    var node = treeListObjExp.AppendNode(new object[]
                    {
                        instance,
                        "Instance",
                        instance,
                        string.Empty
                    }, null);
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

        private void InitDatabases(TreeListNode instanceNode)
        {
            treeListObjExp.BeginUnboundLoad();
            try
            {
                GenerateDatabases(instanceNode);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            treeListObjExp.EndUnboundLoad();
        }

        private void GenerateDatabases(TreeListNode instanceNode)
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
                    }, instanceNode);
                    node.StateImageIndex = 1;
                    node.HasChildren = true;
                    node.Tag = "Database";
                }
            }
        }

        private void InitTables(TreeListNode databaseNode)
        {
            treeListObjExp.BeginUnboundLoad();
            try
            {
                GenerateTables(databaseNode);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            treeListObjExp.EndUnboundLoad();
        }

        private void GenerateTables(TreeListNode databaseNode)
        {
            var tableList = SQLServerInterface.GetTables(databaseNode.GetValue(treeListColumnName).ToString());

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
                    }, databaseNode);
                    node.StateImageIndex = 2;
                    node.HasChildren = true;
                    node.Tag = "Table";
                }
            }
        }

        private void InitColumns(TreeListNode tableNode)
        {
            treeListObjExp.BeginUnboundLoad();
            try
            {
                GenerateColumns(tableNode);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            treeListObjExp.EndUnboundLoad();
        }

        private void GenerateColumns(TreeListNode tableNode)
        {
            var tableName = GetParentNodeFullName(tableNode);
            var dbName = GetParentNodesParentFullName(tableNode);
            var columnList = SQLServerInterface.GetColumns(tableName, dbName);

            if (!columnList.Any()) return;
            foreach (var col in columnList)
            {
                var node = treeListObjExp.AppendNode(new object[]
                {
                    col.Name,
                    "Column",
                    col.Name,
                    string.Empty,
                    col
                }, tableNode);
                node.StateImageIndex = 3;
                node.HasChildren = false;
                node.Tag = "Column";
            }
        }
        #endregion

        private void CopyCell(object sender, EventArgs e)
        {
            Clipboard.SetText(GetFocusedNodeFullName());
        }

        private void ScriptSelectAllForTable(object sender, EventArgs e)
        {
            var selectedTable = GetFocusedNodeFullName();
            var selectedDatabase = GetFocusedNodeParentFullName();
            mvvmContextObjectExplorer.GetViewModel<ObjectExplorerViewModel>().ScriptSelectAllForTable(selectedTable, selectedDatabase);
        }

        private string GetParentNodeFullName(TreeListNode parentNode)
        {
            return parentNode.GetValue(treeListColumnName).ToString();
        }

        private string GetParentNodesParentFullName(TreeListNode parentNode)
        {
            return parentNode.ParentNode.GetValue(treeListColumnName).ToString();
        }

        private string GetFocusedNodeFullName()
        {
            return treeListObjExp.FocusedNode.GetValue(treeListColumnFullName).ToString();
        }

        private string GetFocusedNodeParentFullName()
        {
            return treeListObjExp.FocusedNode.ParentNode.GetValue(treeListColumnName).ToString();
        }

        private void InitializeBindings()
        {
            var fluent = mvvmContextObjectExplorer.OfType<ObjectExplorerViewModel>();

        }
    }
}