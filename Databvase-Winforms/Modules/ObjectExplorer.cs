using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Globals;
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
            treeListObjExp.FocusedNodeChanged += TreeListObjExpOnFocusedNodeChanged;
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
                case GlobalStrings.ObjectExplorerTypes.Table:
                    popupMenuTable.ShowPopup(MousePosition);
                    break;
                default:
                    popupMenuObjectExplorer.ShowPopup(MousePosition);
                    break;
            }

        }

        private void TreeListObjExpOnFocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            if (e.OldNode == null)return;   
            SendInstanceNameChangedMessage();
        }



        #endregion

        private void InitInstances(InstanceConnectedMessage message)
        {
            if (message == null)
            {
                return;
            }
            GenerateInstances();
        }

        private void GenerateInstances()
        {
            treeListObjExp.BeginUnboundLoad();
            try
            {
                foreach (var instance in mvvmContextObjectExplorer.GetViewModel<ObjectExplorerViewModel>().GetInstancesList())
                {
                    if (InstanceAlreadyOnTree(instance))
                    {
                        continue;
                    }

                    CreateInstanceNode(instance);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            treeListObjExp.EndUnboundLoad();
        }

        private void CreateInstanceNode(string instance)
        {
            var node = treeListObjExp.AppendNode(new object[]
            {
                instance,
                GlobalStrings.ObjectExplorerTypes.Instance,
                string.Empty,
                null,
                instance
            }, null);
            node.StateImageIndex = 0;
            node.HasChildren = true;
            node.Tag = GlobalStrings.ObjectExplorerTypes.Instance;
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

        #region Focused Node Methods

        private string GetFocusedNodeFullName()
        {
            return treeListObjExp.FocusedNode?.GetValue(treeListColumnFullName).ToString();
        }

        private Table GetFocusedNodeTable()
        {
            return (Table)treeListObjExp.FocusedNode?.GetValue(treeListColumnData);
        }

        private Database GetFocusedNodeDatabase()
        {
            var focusedNode = treeListObjExp.FocusedNode;
            if (focusedNode == null) return null;
            switch (focusedNode.GetValue(treeListColumnType))
            {
                case GlobalStrings.ObjectExplorerTypes.Instance:
                    return null;
                case GlobalStrings.ObjectExplorerTypes.Database:
                    return (Database) focusedNode.GetValue(treeListColumnData);
                case GlobalStrings.ObjectExplorerTypes.Table:
                    return ((Table) focusedNode.GetValue(treeListColumnData)).Parent;
                case GlobalStrings.ObjectExplorerTypes.Column:
                    if (((Column) focusedNode.GetValue(treeListColumnData)).Parent is Table table) return table.Parent;
                    break;
            }

            return null;
        }

        private string GetFocusedNodeInstance()
        {
            return (string) treeListObjExp.FocusedNode?.GetValue(treeListColumnInstance);
        }

        #endregion

        private void SendInstanceNameChangedMessage()
        {
            var instanceName = GetFocusedNodeInstance();
            var database = GetFocusedNodeDatabase();
            if (instanceName == null) return;
            var tracker = new InstanceAndDatabaseTracker()
            {
                InstanceName = instanceName,
                DatabaseObject = database

            };
            Messenger.Default.Send(new InstanceNameChangeMessage(tracker),
                InstanceNameChangeMessage.NewInstanceNameSender);
        }

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
            fluent.EventToCommand<BeforeExpandEventArgs>(treeListObjExp, "BeforeExpand",
                x => x.ObjectExplorer_OnBeforeExpand(null));

        }
    }
}