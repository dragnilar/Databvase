using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace Databvase_Winforms.Messages
{
    public class ServerExplorerNodeChangedMessage
    {
        public string SelectedFolderPath;
        public string SelectedBackupFilePath;

        public ServerExplorerNodeChangedMessage(string selectedFolderPath, string selectedBackupFilePath)
        {
            SelectedFolderPath = selectedFolderPath;
            SelectedBackupFilePath = selectedBackupFilePath;
            SendMessage();
        }

        private void SendMessage()
        {
            Messenger.Default.Send(this, GetType().Name);
        }
    }
}
