using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace Databvase_Winforms.Messages
{
    class DisconnectInstanceMessage
    {
        public string InstanceName { get; }

        public DisconnectInstanceMessage(string instanceName)
        {
            InstanceName = instanceName;
            SendMessage();
        }

        private void SendMessage()
        {
            Messenger.Default.Send(this, GetType().Name);
        }
    }
}
