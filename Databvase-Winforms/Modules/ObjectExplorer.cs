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
            var focusedNodeType = treeListObjExp.FocusedNode?.GetValue(treeListColumnType).ToString();

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
                App.Connection.DisconnectCurrentInstance(); //TODO - This doesn't feel right...
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
            fluent.EventToCommand<BeforeExpandEventArgs>(treeListObjExp, "BeforeExpand",
                x => x.ObjectExplorer_OnBeforeExpand(null));
            fluent.EventToCommand<FocusedNodeChangedEventArgs>(treeListObjExp, "FocusedNodeChanged",
                x => x.FocusedNodeChanged(null));
        }
    }
}