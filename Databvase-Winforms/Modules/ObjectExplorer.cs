using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Messages;
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
            RegisterMessages();
        }



        private void HookupEvents()
        {

            treeListObjExp.PopupMenuShowing += TreeListObjectExplorerOnPopupMenuShowing;
            treeListObjExp.MouseDown += TreeListObjExpOnMouseDown;
            treeListObjExp.BeforeExpand += TreeListObjExpOnBeforeExpand;
            barButtonItemCopy.ItemClick += CopyCell;

        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<InstanceConnectedMessage>(this, InstanceConnectedMessage.ConnectInstanceSender, InitInstances);
            Messenger.Default.Register<DisconnectInstanceMessage>(this, DisconnectInstanceMessage.DisconnectInstanceSender, DisconnectInstance);
        }



        #region TreeList Methods

        private void TreeListObjExpOnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var instanceName = GetFocusedNodeInstance();
                if (instanceName != null)
                {
                    Messenger.Default.Send(new InstanceNameChangeMessage(instanceName), InstanceNameChangeMessage.NewInstanceNameSender);
                }
            }

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

        #endregion

        #region Tree List Unbound Methods

        private void TreeListObjExpOnBeforeExpand(object sender, BeforeExpandEventArgs e)
        {

            switch (e.Node.Tag.ToString())
            {
                case "Instance":
                    if (e.Node.Nodes.Count > 0)
                    {
                        return;
                    }
                    InitDatabases(e.Node);
                    break;
                case "Database":
                    if (e.Node.Nodes.Count > 0)
                    {
                        return;
                    }
                    InitTables(e.Node);
                    break;
                case "Table":
                    if (e.Node.Nodes.Count > 0)
                    {
                        return;
                    }
                    InitColumns(e.Node);
                    break;
            }
        }

        private void InitInstances(InstanceConnectedMessage message)
        {
            if (message == null)
            {
                return;
            }
            treeListObjExp.BeginUnboundLoad();
            try
            {
                foreach (var instance in mvvmContextObjectExplorer.GetViewModel<ObjectExplorerViewModel>().GetInstancesList())
                {
                    if (InstanceAlreadyOnTree(instance))
                    {
                        continue;
                    }
                    var node = treeListObjExp.AppendNode(new object[]
                    {
                        instance,
                        "Instance",
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

        private void DisconnectInstance(DisconnectInstanceMessage message)
        {
            if (message == null) return;
            var nodes = treeListObjExp.Nodes.Where(r => r.Level == 0).ToList();

            var instanceNode = nodes.FirstOrDefault(x =>
                x.GetValue(treeListColumnFullName).ToString() == message.InstanceName);

            if (instanceNode != null)
            {
                treeListObjExp.Nodes.Remove(instanceNode);
            }
        }

        private bool InstanceAlreadyOnTree(string instance)
        {
            var nodes = treeListObjExp.Nodes.Where(r => r.Level == 0).ToList();

            if (nodes.Any(x=>x.GetValue(treeListColumnFullName).ToString() == instance))
            {
                return true;
            }

            return false;
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
            var instanceName = GetNodesFullName(instanceNode);
            var dbList = SQLServerInterface.GetDatabases(instanceName);
            if (dbList.Any())
            {
                foreach (var db in dbList)
                {
                    var node = treeListObjExp.AppendNode(new object[]
                    {
                        db.Name,
                        "Database",
                         instanceName,
                        db,
                        instanceName
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
            var databaseName = GetNodesFullName(databaseNode);
            var instanceName = GetNodesFullName(databaseNode.ParentNode);
            var tableList = SQLServerInterface.GetTables(instanceName, databaseName);

            if (tableList.Any())
            {
                foreach (var table in tableList)
                {
                    var node = treeListObjExp.AppendNode(new object[]
                    {
                        table.Schema != "dbo" ? $"{table.Schema}.{table.Name}" : table.Name,
                        "Table",
                        databaseName,
                        table,
                        table.Parent.Parent.Name
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
            var tableName = GetNodesFullName(tableNode);
            var dbName = GetNodesFullName(tableNode.ParentNode);
            var instanceName = GetNodesFullName(tableNode.ParentNode.ParentNode);
            var columnList = SQLServerInterface.GetColumns(tableName, dbName, instanceName);

            if (!columnList.Any()) return;
            foreach (var col in columnList)
            {
                var node = treeListObjExp.AppendNode(new object[]
                {
                    col.Name,
                    "Column",
                    tableName,
                    col,
                    ((Table)col.Parent).Parent.Parent.Name
                }, tableNode);
                node.StateImageIndex = 3;
                node.HasChildren = false;
                node.Tag = "Column";
            }
        }

        #region Focused Node Methods

        private string GetNodesFullName(TreeListNode node)
        {
            return node.GetValue(treeListColumnFullName).ToString();
        }

        private string GetFocusedNodeFullName()
        {
            return treeListObjExp.FocusedNode?.GetValue(treeListColumnFullName).ToString();
        }

        private Table GetFocusedNodeTable()
        {
            return (Table)treeListObjExp.FocusedNode?.GetValue(treeListColumnData);
        }

        private Column GetFocusedNodeColumn()
        {
            return (Column)treeListObjExp.FocusedNode?.GetValue(treeListColumnData);
        }

        private Database GetFocusedNodeDatabase()
        {
            return (Database)treeListObjExp.FocusedNode?.GetValue(treeListColumnData);
        }

        private string GetFocusedNodeInstance()
        {
            return (string) treeListObjExp.FocusedNode?.GetValue(treeListColumnInstance);
        }

        #endregion


        #endregion

        private void CopyCell(object sender, EventArgs e)
        {
            Clipboard.SetText(GetFocusedNodeFullName());
        }

        private void InitializeBindings()
        {
            var fluent = mvvmContextObjectExplorer.OfType<ObjectExplorerViewModel>();
            fluent.SetBinding(barButtonItemGenerateSelectTopStatement, x => x.Caption,
                y => y.SelectTopContextMenuItemDescription);
            fluent.BindCommand(barButtonItemGenerateSelectAll, (x,p) => x.ScriptSelectAllForTable(p), x=>GetFocusedNodeTable());
            fluent.BindCommand(barButtonItemGenerateSelectTopStatement, (x,p) => x.ScriptSelectTopForTable(p), x=>GetFocusedNodeTable());

        }
    }
}