using System.Drawing;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel()]
    public class SettingsViewModel
    {

        public virtual bool ShowRowNumberColumn { get; set; }
        public virtual int NumberOfRowsForSelectTopScript { get; set; }
        public virtual WindowState State { get; set; }
        public virtual Color NullColor { get; set; }
        public virtual string NullText { get; set; }
        public virtual Color DefaultTextColor { get; set; }
        public virtual Color DefaultKeywordColor { get; set; }
        public virtual Color DefaultStringColor { get; set; }
        public virtual Color DefaultCommentColor { get; set; }
        public virtual string DefaultFontName { get; set; }
        private Font  DefaultFont { get; set; }

        public SettingsViewModel()
        {
            ShowRowNumberColumn = App.Config.ShowRowNumberColumn;
            NumberOfRowsForSelectTopScript = App.Config.NumberOfRowsForTopSelectScript;
            State = WindowState.Open;
            NullColor = App.Config.NullGridCellColor;
            NullText = App.Config.NullGridText;
            DefaultTextColor = App.Config.TextEditorDefaultColor;
            DefaultCommentColor = App.Config.TextEditorCommentsColor;
            DefaultKeywordColor = App.Config.TextEditorKeywordColor;
            DefaultStringColor = App.Config.TextEditorStringColor;
            DefaultFont = App.Config.DefaultTextEditorFont;
            DefaultFontName = DefaultFont.Name;
        }


        public void Save()
        {
            App.Config.ShowRowNumberColumn = ShowRowNumberColumn;
            App.Config.NumberOfRowsForTopSelectScript = NumberOfRowsForSelectTopScript;
            App.Config.NullGridCellColor = NullColor;
            App.Config.NullGridText = NullText;
            App.Config.TextEditorDefaultColor = DefaultTextColor;
            App.Config.TextEditorCommentsColor = DefaultCommentColor;
            App.Config.TextEditorKeywordColor = DefaultKeywordColor;
            App.Config.TextEditorStringColor = DefaultStringColor;
            App.Config.DefaultTextEditorFont = DefaultFont;
            App.Config.Save();
            new SettingsUpdatedMessage(SettingsUpdatedMessage.SettingsUpdateType.NumberOfRowsForTopSelectScript);
            new SettingsUpdatedMessage(SettingsUpdatedMessage.SettingsUpdateType.TextEditorFontStyle);
            State = WindowState.Close;
        }

        public void Cancel()
        {
            State = WindowState.Close;
        }

        public void ShowFontDialog()
        {
            var selectedFont = this.GetService<IFontDialogService>().ShowDialog(DefaultFont);
            DefaultFont = selectedFont;
            DefaultFontName = selectedFont.Name;
        }



        public enum WindowState
        {
            Open,
            Close
        }
    }
}
