using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Models
{
    public class ScriptGenerationResult
    {
        public string Script { get; set; }
        public string DatabaseName { get; set; }
        public bool HasErrors { get; set; }
        public string ErrorMessage { get; set; }

        public ScriptGenerationResult(string script, string dataBaseName)
        {
            Script = script;
            DatabaseName = dataBaseName;
            ErrorMessage = null;
            HasErrors = false;
        }

        public ScriptGenerationResult(bool hasErrors, string errorMessage)
        {
            Script = string.Empty;
            DatabaseName = string.Empty;
            ErrorMessage = errorMessage;
            HasErrors = hasErrors;
        }

        public ScriptGenerationResult(string script, string dataBaseName, bool hasErrors, string errorMessage)
        {
            Script = script;
            DatabaseName = dataBaseName;
            ErrorMessage = errorMessage;
            HasErrors = hasErrors;
        }
    }


}
