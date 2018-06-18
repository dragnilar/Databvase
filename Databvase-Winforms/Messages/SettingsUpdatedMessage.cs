using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.XtraLayout.Resizing;

namespace Databvase_Winforms.Messages
{
    class SettingsUpdatedMessage
    {
        public SettingsUpdateType Type { get; set; }

        public SettingsUpdatedMessage(SettingsUpdateType type)
        {
            Type = type;
            SendMessage();
        }

        private void SendMessage()
        {
            Messenger.Default.Send(this, GetType().Name);
        }
        

        public enum SettingsUpdateType
        {
            TextEditorStyles,
            NumberOfRowsForTopSelectScript
        }
        
    }
}
