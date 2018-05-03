using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.Views;

namespace Databvase_Winforms.Services.Window_Dialog_Services
{
    public interface IConnectionWindowService
    {
        void ShowDialog(); 
    }
    class ConnectionWindowService : IConnectionWindowService
    {
        public void ShowDialog()
        {
            var connectionWindow = new ConnectionWindowView();
            connectionWindow.StartPosition = FormStartPosition.CenterParent;
            connectionWindow.ShowDialog();
            connectionWindow.Dispose();
        }
    }
}
