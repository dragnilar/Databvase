using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.Controls;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors;

namespace Databvase_Winforms.Modules
{
    public partial class TextEditorFontEdit : XtraUserControl
    {
        
        public Font SelectedFont { get; set; }
        public Color DefaultTextColor
        {
            get => colorPickEditDefaultTextColor.Color;
            set => colorPickEditDefaultTextColor.Color = value;
        }

        public Color DefaultKeywordColor
        {
            get => colorPickEditKeywordColor.Color;
            set => colorPickEditKeywordColor.Color = value;
        }

        public Color DefaultStringColor
        {
            get => colorPickEditStringColor.Color;
            set => colorPickEditStringColor.Color = value;
        }

        public Color DefaultCommentColor
        {
            get => colorPickEditCommentsColor.Color;
            set => colorPickEditCommentsColor.Color = value;
        }

        public TextEditorFontEdit()
        {
            InitializeComponent();
            HookUpEvents();
            GetDefaultSettings();
        }

        private void GetDefaultSettings()
        {
            SelectedFont = App.Config.DefaultTextEditorFont;
            fontEditDefaultFont.EditValue = App.Config.DefaultTextEditorFont.Name;
            colorPickEditDefaultTextColor.Color = App.Config.TextEditorDefaultColor;
            colorPickEditKeywordColor.Color = App.Config.TextEditorKeywordColor;
            colorPickEditStringColor.Color = App.Config.TextEditorStringColor;
            colorPickEditCommentsColor.Color = App.Config.TextEditorCommentsColor;

        }

        private void HookUpEvents()
        {
            fontEditDefaultFont.Click += FontEditDefaultFontOnClick;
        }

        private void FontEditDefaultFontOnClick(object sender, EventArgs e)
        {
            ShowFontDialog();
            
        }
        private void ShowFontDialog()
        {

            XtraFontDialog fontDialog = new XtraFontDialog(SelectedFont);
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedFont = fontDialog.ResultFont;
                fontEditDefaultFont.EditValue = fontDialog.ResultFont.Name;
            }

            fontDialog.Dispose();

        }

    }
}
