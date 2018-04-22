using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace Databvase_Winforms.Messages
{
    public class NewScriptMessage
    {
        public string Script { get; set; }
        public string SelectedDatabase { get; set; }

        public NewScriptMessage(string script, string selectedDatabase)
        {

            Script = script;
            SelectedDatabase = selectedDatabase;
            SendMessage();
        }

        private void SendMessage()
        {
            Messenger.Default.Send(this, GetType().Name);
        }
    }
}

