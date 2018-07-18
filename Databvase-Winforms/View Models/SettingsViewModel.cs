using System.Drawing;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Services;
using Databvase_Winforms.Services.Window_Dialog_Services;
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
        public virtual bool UseDirectX { get; set; }
        private Font  DefaultFont { get; set; }

        protected IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();

        public SettingsViewModel()
        {
            State = WindowState.Loading;
            ShowRowNumberColumn = App.Config.ShowRowNumberColumn;
            NumberOfRowsForSelectTopScript = App.Config.NumberOfRowsForTopSelectScript;
            NullColor = App.Config.NullGridCellColor;
            NullText = App.Config.NullGridText;
            DefaultTextColor = App.Config.TextEditorDefaultColor;
            DefaultCommentColor = App.Config.TextEditorCommentsColor;
            DefaultKeywordColor = App.Config.TextEditorKeywordColor;
            DefaultStringColor = App.Config.TextEditorStringColor;
            DefaultFont = App.Config.DefaultTextEditorFont;
            DefaultFontName = DefaultFont.Name;
            UseDirectX = App.Config.UseDirectX;
            State = WindowState.Shown;
        }

        protected void OnUseDirectXChanged()
        {
            if (State == WindowState.Shown)
            {
                MessageBoxService.ShowMessage(
                    "Changes to the Direct X setting will not take effect until Databvase is restarted.",
                    "Note About Direct X Settings", MessageButton.OK, MessageIcon.Information);
            }

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
            App.Config.UseDirectX = UseDirectX;
            App.Config.Save();
            new SettingsUpdatedMessage(SettingsUpdatedMessage.SettingsUpdateType.NumberOfRowsForTopSelectScript);
            new SettingsUpdatedMessage(SettingsUpdatedMessage.SettingsUpdateType.TextEditorStyles);
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
            Loading,
            Shown,
            Close
        }
    }
}
