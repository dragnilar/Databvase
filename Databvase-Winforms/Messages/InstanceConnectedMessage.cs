using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Messages
{
    class InstanceConnectedMessage
    {
        public const string ConnectInstanceSender = "ConnectInstanceSender";

        public string InstanceName { get; set; }

        public InstanceConnectedMessage(string instanceName)
        {
            InstanceName = instanceName;
        }

        public override string ToString()
        {
            return ConnectInstanceSender;
        }
    }
}
