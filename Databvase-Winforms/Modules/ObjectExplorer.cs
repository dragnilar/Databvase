using System;
using System.Windows.Forms;
using Databvase_Winforms.Globals;
using Databvase_Winforms.Models;
using Databvase_Winforms.View_Models;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
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
        }

        private void HookupEvents()
        {
            treeListObjExp.PopupMenuShowing += TreeListObjectExplorerOnPopupMenuShowing;
            treeListObjExp.MouseDown += TreeListObjExpOnMouseDown;
            barButtonItemCopy.ItemClick += CopyCell;
            treeListObjExp.NodeChanged += TreeListObjExpOnNodeChanged;
        }

        private void TreeListObjExpOnNodeChanged(object sender, NodeChangedEventArgs e)
        {   //TODO - This event is firing even when a node is already added, which may mean that this may not be the best way to flag a node as having children...
            if (e.ChangeType == NodeChangeTypeEnum.Add)
            {
                if (!(e.Node.TreeList.GetRow(e.Node.Id) is ObjectExplorerModel model)) return;
                SetHasChildrenForNode(e, model);
            }
        }

        private static void SetHasChildrenForNode(NodeChangedEventArgs e, ObjectExplorerModel objectExplorerModel)
        {
            switch (objectExplorerModel.Type)
            {
                case GlobalStrings.ObjectExplorerTypes.Instance:
                    e.Node.HasChildren = true;
                    break;
                case GlobalStrings.ObjectExplorerTypes.Database:
                    e.Node.HasChildren = true;
                    break;
                case GlobalStrings.ObjectExplorerTypes.Folder:
                    e.Node.HasChildren = true;
                    break;
                case GlobalStrings.ObjectExplorerTypes.Table:
                    e.Node.HasChildren = true;
                    break;
                default:
                    e.Node.HasChildren = false;
                    break;
            }
        }

        private void CopyCell(object sender, EventArgs e)
        {
            Clipboard.SetText(GetFocusedNodeFullName());
        }

        private void InitializeBindings()
        {
            var fluent = mvvmContextObjectExplorer.OfType<ObjectExplorerViewModel>();
            SetBindings(fluent);
            BindCommands(fluent);
            BindEvents(fluent);

        }

        private void SetBindings(MVVMContextFluentAPI<ObjectExplorerViewModel> fluent)
        {
            fluent.SetBinding(barButtonItemGenerateSelectTopStatement, x => x.Caption,
                y => y.SelectTopContextMenuItemDescription);
            fluent.SetBinding(treeListObjExp, x => x.DataSource, vm => vm.ObjectExplorerSource);
        }

        private void BindEvents(MVVMContextFluentAPI<ObjectExplorerViewModel> fluent)
        {
            fluent.EventToCommand<BeforeExpandEventArgs>(treeListObjExp, "BeforeExpand",
                x => x.ObjectExplorer_OnBeforeExpand(null));
            fluent.EventToCommand<FocusedNodeChangedEventArgs>(treeListObjExp, "FocusedNodeChanged",
                x => x.FocusedNodeChanged(null));
        }

        private void BindCommands(MVVMContextFluentAPI<ObjectExplorerViewModel> fluent)
        {
            fluent.BindCommand(barButtonItemGenerateSelectAll, (x, p) => x.ScriptSelectAllForObjectExplorerData(p),
                x => GetFocusedNodeData());
            fluent.BindCommand(barButtonItemGenerateSelectTopStatement, (x, p) => x.ScriptSelectTopForObjectExplorerData(p),
                x => GetFocusedNodeData());
            fluent.BindCommand(barButtonItemAlterScript, (x, p) => x.ScriptModifyForObjectExplorerData(p), x=> GetFocusedNodeData());
            fluent.BindCommand(barButtonItemViewFunction, (x, p) => x.ScriptAlterForObjectExplorerData(p), x=> GetFocusedNodeData());
            fluent.BindCommand(barButtonItemNewQuery, (x,p) => x.NewQueryScript(p), x=> GetFocusedNodeDatabase());
            fluent.SetTrigger(vm => vm.LoadingMode, TriggerAction);
        }

        private void TriggerAction(ObjectExplorerViewModel.UnboundLoadModes unboundLoadMode)
        {
            switch (unboundLoadMode)
            {
                case ObjectExplorerViewModel.UnboundLoadModes.BeginUnboundLoad:
                    treeListObjExp.BeginUnboundLoad();
                    splashScreenManagerObjectExplorer.ShowWaitForm();
                    break;
                case ObjectExplorerViewModel.UnboundLoadModes.FinishUnboundLoad:
                    splashScreenManagerObjectExplorer.CloseWaitForm();
                    treeListObjExp.EndUnboundLoad();
                    treeListObjExp.FocusedNode?.Expand();
                    break;
            }
        }


        #region TreeList Methods

        private void TreeListObjExpOnMouseDown(object sender, MouseEventArgs e)
        {
            var treeList = sender as TreeList;
            var info = treeList.CalcHitInfo(e.Location);
            if (info?.Node != null) treeListObjExp.FocusedNode = info.Node;
        }

        private void TreeListObjectExplorerOnPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var focusedNodeType = treeListObjExp.FocusedNode?.GetValue(treeListColumnType).ToString();

            switch (focusedNodeType)
            {
                case GlobalStrings.ObjectExplorerTypes.Table:
                    popupMenuTable.ShowPopup(MousePosition);
                    break;
                case GlobalStrings.ObjectExplorerTypes.View:
                    popupMenuTable.ShowPopup(MousePosition);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Function:
                    popupMenuFunction.ShowPopup(MousePosition);
                    break;
                case GlobalStrings.ObjectExplorerTypes.StoredProcedure:
                    popupMenuStoredProcedure.ShowPopup(MousePosition);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Nothing:
                    break;
                default:
                    popupMenuObjectExplorer.ShowPopup(MousePosition);
                    break;
            }
        }

        #endregion

        #region Focused Node Methods

        private string GetFocusedNodeFullName()
        {
            return treeListObjExp.FocusedNode?.GetValue(treeListColumnFullName).ToString();
        }

        private object GetFocusedNodeData()
        {
            return treeListObjExp.FocusedNode?.GetValue(treeListColumnData);
        }

        private Database GetFocusedNodeDatabase()
        {
            var data = treeListObjExp.FocusedNode?.GetValue(treeListColumnData);
            switch (data)
            {
                case Database _:
                    return data as Database;
                case Server _:
                    return null;
                case Column _:
                    var column = data as Column;
                    return ((Table) column?.Parent)?.Parent;
                default:
                    return null;
            }
        }

        #endregion

    }
}