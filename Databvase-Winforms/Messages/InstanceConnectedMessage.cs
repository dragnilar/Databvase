using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Models;

namespace Databvase_Winforms.Messages
{
    class InstanceConnectedMessage
    {
        public const string ConnectInstanceSender = "ConnectInstanceSender";

        public InstanceAndDatabaseTracker Tracker { get; set; }

        public InstanceConnectedMessage(InstanceAndDatabaseTracker tracker)
        {
            Tracker = tracker;
        }

        public override string ToString()
        {
            return ConnectInstanceSender;
        }
    }
}
