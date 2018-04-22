using System.Drawing;
using Databvase_Winforms.Messages;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

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

        public SettingsViewModel()
        {
            ShowRowNumberColumn = App.Config.ShowRowNumberColumn;
            NumberOfRowsForSelectTopScript = App.Config.NumberOfRowsForTopSelectScript;
            State = WindowState.Open;
            NullColor = App.Config.NullGridCellColor;
            NullText = App.Config.NullGridText;
        }


        public void Save()
        {
            App.Config.ShowRowNumberColumn = ShowRowNumberColumn;
            App.Config.NumberOfRowsForTopSelectScript = NumberOfRowsForSelectTopScript;
            App.Config.NullGridCellColor = NullColor;
            App.Config.NullGridText = NullText;
            App.Config.Save();
            new SettingsUpdatedMessage(SettingsUpdatedMessage.SettingsUpdateType.NumberOfRowsForTopSelectScript);
            State = WindowState.Close;
        }

        public void Cancel()
        {
            State = WindowState.Close;
        }



        public enum WindowState
        {
            Open,
            Close
        }
    }
}
