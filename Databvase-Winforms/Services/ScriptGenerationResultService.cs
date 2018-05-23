using Databvase_Winforms.Messages;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace Databvase_Winforms.Services
{
    public class ScriptGenerationResultService : ISupportServices
    {
        public string Script { get; set; }
        public string DatabaseName { get; set; }
        public bool HasErrors { get; set; }
        public string ErrorMessage { get; set; }


        public IServiceContainer ServiceContainer { get; }

        public ScriptGenerationResultService(IServiceContainer serviceContainer)
        {
            ServiceContainer = serviceContainer;
        }

        private IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();

        public void ResultWithNoErrors(string script, string dataBaseName)
        {
            Script = script;
            DatabaseName = dataBaseName;
            ErrorMessage = null;
            HasErrors = false;
            ValidateResponseAndSendScriptMessage(this);
        }

        public void ResultWithException(bool hasErrors, string errorMessage)
        {
            Script = string.Empty;
            DatabaseName = string.Empty;
            ErrorMessage = errorMessage;
            HasErrors = hasErrors;
            ValidateResponseAndSendScriptMessage(this);
        }

        public ScriptGenerationResultService(string script, string dataBaseName, bool hasErrors, string errorMessage)
        {
            Script = script;
            DatabaseName = dataBaseName;
            ErrorMessage = errorMessage;
            HasErrors = hasErrors;
            ValidateResponseAndSendScriptMessage(this);
        }


        private void ValidateResponseAndSendScriptMessage(ScriptGenerationResultService resultService)
        {
            if (resultService.HasErrors)
            {
                DisplayErrorMessage(resultService.ErrorMessage, "Error Generating Script");
            }
            else
            {
                new NewScriptMessage(resultService.Script, resultService.DatabaseName);
            }

        }

        private void DisplayErrorMessage(string errorMessage, string errorHeader)
        {
            MessageBoxService.ShowMessage(errorMessage, errorHeader, MessageButton.OK, MessageIcon.Error);
        }

    }


}
