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
        public SettingsUpdateType Type { get; set; }

        public SettingsUpdatedMessage(SettingsUpdateType type)
        {
            Type = type;
        }
         
        public override string ToString()
        { 
            return SettingsUpdatedSender;
        }

        public enum SettingsUpdateType
        {
            TextEditorBackground,
            NumberOfRowsForTopSelectScript
        }
        
    }
}
