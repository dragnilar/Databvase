using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LWSqlQueryTool_Winforms.Models;
using LWSqlQueryTool_Winforms.Services;

namespace LWSqlQueryTool_Winforms.Modules
{
    public partial class ObjectExplorer : DevExpress.XtraEditors.XtraUserControl
    {
        public ObjectExplorer()
        {
            InitializeComponent();
            HookUpEvents();
        }

        private void HookUpEvents()
        {
            treeListObjectExplorer.VirtualTreeGetCellValue += TreeListObjectExplorer_VirtualTreeGetCellValue;
        }

        private void TreeListObjectExplorer_VirtualTreeGetCellValue(object sender, DevExpress.XtraTreeList.VirtualTreeGetCellValueInfo e)
        {
            
        }
    }
}
