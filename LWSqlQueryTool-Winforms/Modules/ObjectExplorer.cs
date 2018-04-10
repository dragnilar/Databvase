using Databvase_Winforms.View_Models;
using DevExpress.XtraEditors;

namespace Databvase_Winforms.Modules
{
    public partial class ObjectExplorer : XtraUserControl
    {
        public ObjectExplorer()
        {
            InitializeComponent();
            if (!mvvmContextObjectExplorer.IsDesignMode)
                InitializeBindings();
        }

        private void InitializeBindings()
        {
            var fluent = mvvmContextObjectExplorer.OfType<ObjectExplorerViewModel>();
            fluent.SetBinding(treeListObjectExplorer, r => r.DataSource, x => x.ObjectExplorerDataSource);
        }
    }
}