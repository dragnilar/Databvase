using Databvase_Winforms.Messages;
using DevExpress.Mvvm;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace Databvase_Winforms.Controls.QueryTextEditor
{
    public class QueryTextEditor : RichEditControl
    {
        public QueryTextEditor()
        {
            InitializeQueryTextEditor();
            RegisterMessages();
        }

        private void InitializeQueryTextEditor()
        {
            ShowLineNumbers();
        }


        public void ShowLineNumbers()
        {
            Document.Sections[0].LineNumbering.RestartType = LineNumberingRestart.Continuous;
            Document.Sections[0].LineNumbering.Start = 1;
            Document.Sections[0].LineNumbering.CountBy = 1;
            Document.Sections[0].LineNumbering.Distance = 0.1f;
            Document.CharacterStyles["Line Number"].ForeColor = App.Config.TextEditorLineNumberColor;
        }

        private void SetLineColor()
        {
            Document.CharacterStyles["Line Number"].ForeColor = App.Config.TextEditorLineNumberColor;
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<SettingsUpdatedMessage>(this, SettingsUpdatedMessage.SettingsUpdatedSender, ApplysettingsUpdate);
        }

        private void ApplysettingsUpdate(SettingsUpdatedMessage message)
        {
            if (message.Type == SettingsUpdatedMessage.SettingsUpdateType.TextEditorBackground)
            {
                SetLineColor();
            }
        }
    }
}
