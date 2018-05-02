using System.Windows.Forms;
using Databvase_Winforms.Views;

namespace Databvase_Winforms.Services.Window_Dialog_Services
{
    internal interface ISettingsWindowService
    {
        void ShowDialog();
        void Show();
    }

    internal class SettingsWindowService : ISettingsWindowService
    {
        public void ShowDialog()
        {
            var window = new SettingsView();
            window.StartPosition = FormStartPosition.CenterScreen;
            window.ShowDialog();
            window.Dispose();
        }

        public void Show()
        {
            var window = new SettingsView();
            window.StartPosition = FormStartPosition.CenterScreen;
            window.Show();
        }
    }
}
