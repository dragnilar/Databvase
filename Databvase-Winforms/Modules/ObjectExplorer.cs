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
        private bool InstancesLoaded;

        public ObjectExplorer()
        {
            InitializeComponent();
            treeListObjExp.DataSource = new object();
            if (!mvvmContextObjectExplorer.IsDesignMode)
                InitializeBindings();
            HookupEvents();
        }

        private void HookupEvents()
        {
            treeListObjExp.GetSelectImage += TreeListObjExpOnGetSelectImage;
            treeListObjExp.PopupMenuShowing += TreeListObjectExplorerOnPopupMenuShowing;
            treeListObjExp.MouseDown += TreeListObjExpOnMouseDown;

            barButtonItemCopy.ItemClick += CopyCell;
            barButtonItemGenerateSelectAll.ItemClick += ScriptSelectAllForTable;
        }



        #region TreeList Methods
        private void TreeListObjExpOnGetSelectImage(object sender, GetSelectImageEventArgs e)
        { //This is view code so it stays on the view
            switch (e.Node.Level)
            {
                case 0:
                    e.NodeImageIndex = 0;
                    break;
                case 1:
                    e.NodeImageIndex = 1;
                    break;
                case 2:
                    e.NodeImageIndex = 2;
                    break;
                case 3:
                    e.NodeImageIndex = 3;
                    break;
            }
        }

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
        #endregion

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
            fluent.EventToCommand<VirtualTreeGetChildNodesInfo>(treeListObjExp, "VirtualTreeGetChildNodes",
                x => x.GetNodesForObjectExplorer(null));
            fluent.EventToCommand<VirtualTreeGetCellValueInfo>(treeListObjExp, "VirtualTreeGetCellValue",
                x => x.GetCellValue(null));

        }
    }
}