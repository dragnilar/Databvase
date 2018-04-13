using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Messages
{
    public class NewScriptMessage
    {
        public const string NewScriptSender = "NewScriptSender";
        public string Script { get; set; }
        public string SelectedDatabase { get; set; }

        public NewScriptMessage(string script, string selectedDatabase)
        {

            Script = script;
            SelectedDatabase = selectedDatabase;
        }

        public override string ToString()
        {
            return NewScriptSender;
        }
    }
}

