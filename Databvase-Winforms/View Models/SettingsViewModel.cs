using DevExpress.Mvvm.DataAnnotations;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel()]
    public class SettingsViewModel
    {

        public virtual bool ShowRowNumberColumn { get; set; }
        public virtual int NumberOfRowsForSelectTopScript { get; set; }
        public virtual WindowState State { get; set; }

        public SettingsViewModel()
        {
            ShowRowNumberColumn = App.Config.ShowRowNumberColumn;
            NumberOfRowsForSelectTopScript = App.Config.NumberOfRowsForTopSelectScript;
            State = WindowState.Open;
        }


        public void Save()
        {
            App.Config.ShowRowNumberColumn = ShowRowNumberColumn;
            App.Config.NumberOfRowsForTopSelectScript = NumberOfRowsForSelectTopScript;
            App.Config.Save();
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
