using System;
using System.Drawing;
using System.Windows.Forms;
using Databvase_Winforms.Models;
using Databvase_Winforms.View_Models;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Menu;

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
            //treeListObjectExplorer.PopupMenuShowing += TreeListObjectExplorerOnPopupMenuShowing;
        }


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
            fluent.SetBinding(treeListObjectExplorer, r => r.DataSource, x => x.ObjectExplorerDataSource);
            
        }
    }
}