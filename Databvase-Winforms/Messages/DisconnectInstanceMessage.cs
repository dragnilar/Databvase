using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Messages
{
    class DisconnectInstanceMessage
    {
        public const string DisconnectInstanceSender = "DisconnectInstanceSender";

        public string InstanceName { get; set; }

        public DisconnectInstanceMessage(string instanceName)
        {
            InstanceName = instanceName;
        }

        public override string ToString()
        {
            return DisconnectInstanceSender;
        }
    }
}
