using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Models;
using DevExpress.Mvvm;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Messages
{
    public class InstanceNameChangeMessage
    {
        public InstanceAndDatabaseTracker Tracker { get; set; }

        public InstanceNameChangeMessage(Server server, Database database)
        {
            Tracker = new InstanceAndDatabaseTracker
            {
                CurrentInstance = server,
                CurrentDatabase = database
            };
            SendMessage();
        }

        private void SendMessage()
        {
            Messenger.Default.Send(this,
                GetType().Name);
        }
    }
}
