using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Databvase_Winforms.Views
{
    public partial class BackupView : DevExpress.XtraEditors.XtraForm
    {
        public BackupView()
        {
            InitializeComponent();
            HookupEvents();
        }

        void HookupEvents()
        {
            accordianElementGeneral.Click += (sender, args) =>
                navigationFrameBackupWindow.SelectedPage = navigationPageBackupGeneral;
            accordianElementMedia.Click += (sender, args) =>
                navigationFrameBackupWindow.SelectedPage = navigationPageMediaOptions;
            accordianElementBackupOptions.Click += (sender, args) =>
                navigationFrameBackupWindow.SelectedPage = navigationPageBackupOptions;
        }
    }
}