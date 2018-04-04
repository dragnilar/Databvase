using System.Windows.Forms;
using LWSqlQueryTool_Winforms.View_Models;

namespace LWSqlQueryTool_Winforms.Views
{
    public partial class ConnectionStringView : Form
    {
        public ConnectionStringView()
        {
            InitializeComponent();
            if (!mvvmContextConnectionStringView.IsDesignMode)
                InitializeBindings();
        }

        void InitializeBindings()
        {
            var fluent = mvvmContextConnectionStringView.OfType<ConnectionStringViewModel>();
        }
    }
}
