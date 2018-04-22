using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;

namespace Databvase_Winforms.Dialogs
{
    public partial class TextEditorFontChangeDialog : XtraForm
    {

        public TextEditorFontChangeDialog()
        {
            InitializeComponent();
            HookupEvents();
        }

        private void HookupEvents()
        {
            simpleButtonOK.Click += SimpleButtonOkOnClick;
            simpleButtonCancel.Click += SimpleButtonCancelOnClick;
        }

        private void SimpleButtonCancelOnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void SimpleButtonOkOnClick(object sender, EventArgs e)
        {
            App.Config.DefaultTextEditorFont = textEditorFontEdit.SelectedFont;
            App.Config.TextEditorDefaultColor = textEditorFontEdit.DefaultTextColor;
            App.Config.TextEditorKeywordColor = textEditorFontEdit.DefaultKeywordColor;
            App.Config.TextEditorStringColor = textEditorFontEdit.DefaultStringColor;
            App.Config.TextEditorCommentsColor = textEditorFontEdit.DefaultCommentColor;
            App.Config.Save();
            Close();
        }


    }
}