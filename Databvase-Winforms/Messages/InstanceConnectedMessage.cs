using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Models;
using DevExpress.Mvvm;

namespace Databvase_Winforms.Messages
{
    class InstanceConnectedMessage
    {
        public InstanceAndDatabaseTracker Tracker { get; private set; }

        public InstanceConnectedMessage(InstanceAndDatabaseTracker tracker)
        {
            Tracker = new InstanceAndDatabaseTracker();
            Tracker = tracker;
            SendMessage();
        }

        private void SendMessage()
        {
            Messenger.Default.Send(this, GetType().Name);
        }
    }
}
