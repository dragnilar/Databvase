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
        public const string NewInstanceNameSender = "NewInstanceNameSender";

        public InstanceAndDatabaseTracker Tracker { get; set; }

        public InstanceNameChangeMessage(string instanceName, Database database)
        {
            Tracker = new InstanceAndDatabaseTracker
            {
                InstanceName = instanceName,
                DatabaseObject = database
            };
            SendMessage();
        }

        private void SendMessage()
        {
            Messenger.Default.Send(this,
                NewInstanceNameSender);
        }
    }
}
