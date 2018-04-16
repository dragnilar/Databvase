using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.Views;

namespace Databvase_Winforms.Services
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
