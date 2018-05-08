using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace Databvase_Winforms.Messages
{
    class BackupPathMessage
    {
        public string BackupPath;

        public BackupPathMessage(string path)
        {
            BackupPath = path;
            SendMessage();
        }

        private void SendMessage()
        {
            Messenger.Default.Send(this, GetType().Name);
        }
    }
}
