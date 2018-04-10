using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Databvase_Winforms.Dialogs
{
    public partial class RenameTabDialog : XtraForm
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