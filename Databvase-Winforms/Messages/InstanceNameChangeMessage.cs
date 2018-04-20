using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Models;

namespace Databvase_Winforms.Messages
{
    public class InstanceNameChangeMessage
    {
        public const string NewInstanceNameSender = "NewInstanceNameSender";

        public InstanceAndDatabaseTracker Tracker { get; set; }

        public InstanceNameChangeMessage(InstanceAndDatabaseTracker tracker)
        {
            Tracker = tracker;
        }

        public override string ToString()
        {
            return NewInstanceNameSender;
        }
    }
}
