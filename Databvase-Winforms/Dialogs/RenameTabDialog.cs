using System;
using System.Windows.Forms;
using Databvase_Winforms.Messages;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Databvase_Winforms.Dialogs
{
    public partial class RenameTabDialog : XtraForm
    {

        public RenameTabDialog()
        {
            InitializeComponent();
            HookUpEvents();
        }

        private void HookUpEvents()
        {
            simpleButtonRename.Click += SimpleButtonRenameOnClick;
            simpleButtonCancel.Click += SimpleButtonCancelOnClick;
            textEditNewTabName.KeyDown += TextEditNewTabNameOnKeyDown;
        }

        private void SimpleButtonCancelOnClick(object sender, EventArgs eventArgs)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SimpleButtonRenameOnClick(object sender, EventArgs eventArgs)
        {
            ApplyRename();
        }

        private void TextEditNewTabNameOnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ApplyRename();
                    break;
                default:
                    break;
            }
        }

        private void ApplyRename()
        {
            if (!string.IsNullOrEmpty(textEditNewTabName.Text.Trim()))
            {
                new TabNameMessage(textEditNewTabName.Text);
                Close();
            }
        }

    }
}