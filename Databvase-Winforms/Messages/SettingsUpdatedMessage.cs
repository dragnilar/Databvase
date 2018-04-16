using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Messages
{
    class SettingsUpdatedMessage
    {
        public const string SettingsUpdatedSender = "SettingsUpdatedSender";
        public bool Updated { get; set; }

        public SettingsUpdatedMessage(bool updated)
        {
            Updated = updated;
        }
         
        public override string ToString()
        { 
            return SettingsUpdatedSender;
        }
    }
}
