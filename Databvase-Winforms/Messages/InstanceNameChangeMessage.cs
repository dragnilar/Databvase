using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Messages
{
    public class InstanceNameChangeMessage
    {
        public const string NewInstanceNameSender = "NewInstanceNameSender";

        public string InstanceName { get; set; }

        public InstanceNameChangeMessage(string instanceName)
        {
            InstanceName = instanceName;
        }

        public override string ToString()
        {
            return NewInstanceNameSender;
        }
    }
}
