using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Models;
using Databvase_Winforms.View_Models;
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
            treeListObjExp.VirtualTreeGetCellValue += treeListObjectExplorer_VirtualTreeGetCellValue;
            treeListObjExp.GetSelectImage += TreeListObjExpOnGetSelectImage;
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

        
        private void treeListObjectExplorer_VirtualTreeGetCellValue(object sender, DevExpress.XtraTreeList.VirtualTreeGetCellValueInfo e)
        { //This is view code so it stays on the view
            try
            {
                ObjectExplorerTreeListObject nodeObject = (ObjectExplorerTreeListObject)e.Node;
                if (e.Column == treeListColumnFullName)
                {
                    e.CellData = nodeObject.FullName;
                }
                if (e.Column == treeListColumnType)
                {
                    e.CellData = nodeObject.Type;
                }

                if (e.Column == treeListColumnName)
                {
                    e.CellData = nodeObject.Name;
                }

                if (e.Column == treeListColumnParentName)
                {
                    e.CellData = nodeObject.ParentName;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

        }
        #endregion


        //private void TreeListObjectExplorerOnPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        //{
        //    var point = treeListObjectExplorer.PointToClient(MousePosition);
        //    var treeHitinfo = treeListObjectExplorer.CalcHitInfo(point);
        //    if (treeHitinfo.HitInfoType == HitInfoType.Cell)
        //    {
        //        var node = treeHitinfo.Node;
        //        var value = treeListObjectExplorer.GetDataRecordByNode(node) as ObjectExplorerTreeListObject;
        //        if (value != null)
        //        {
        //            //Do something
        //        }


        //        //if (e.Menu.MenuType == TreeListMenuType.User)
        //        //{
        //        //    e.Menu.Items.Add(new DXMenuCheckItem("Test"));
        //        //    e.Menu.Items.Add(new DXMenuCheckItem("Test"));
        //        //    e.Menu.Items.Add(new DXMenuCheckItem("Test"));
        //        //    e.Menu.Items.Add(new DXMenuCheckItem("Test"));
        //        //    e.Menu.Items.Add(new DXMenuCheckItem("Test"));
        //        //}
        //    }


        //}

        //private DXMenuItem Test = new DXMenuItem("Test");

        private void InitializeBindings()
        {
            var fluent = mvvmContextObjectExplorer.OfType<ObjectExplorerViewModel>();
            fluent.EventToCommand<VirtualTreeGetChildNodesInfo>(treeListObjExp, "VirtualTreeGetChildNodes",
                x => x.GetNodesForObjectExplorer(null));

        }
    }
}