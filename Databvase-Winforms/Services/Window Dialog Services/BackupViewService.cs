using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.Views;

namespace Databvase_Winforms.Services.Window_Dialog_Services
{
    public interface IBackupViewService
    {
        void Show();
    }
    public class BackupViewService : IBackupViewService
    {
        public void Show()
        {
            var backupWindow = new BackupView();
            backupWindow.StartPosition = FormStartPosition.CenterScreen;
            backupWindow.Show();
        }
    }
}
