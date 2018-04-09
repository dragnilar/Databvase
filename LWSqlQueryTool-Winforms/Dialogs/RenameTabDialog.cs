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

namespace Databvase_Winforms.Dialogs
{
    public partial class RenameTabDialog : DevExpress.XtraEditors.XtraForm
    {
        public string NewTabName = string.Empty;
        public RenameTabDialog()
        {
            InitializeComponent();
            HookUpEvents();
        }

        private void HookUpEvents()
        {
            simpleButtonRename.Click += SimpleButtonRenameOnClick;
            simpleButtonCancel.Click += SimpleButtonCancelOnClick;
        }

        private void SimpleButtonCancelOnClick(object sender, EventArgs eventArgs)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SimpleButtonRenameOnClick(object sender, EventArgs eventArgs)
        {
            if (!string.IsNullOrEmpty(textEditNewTabName.Text))
            {
                NewTabName = textEditNewTabName.Text;
                DialogResult = DialogResult.OK;
                Close();
            }

        }
    }
}