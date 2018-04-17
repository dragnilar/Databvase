using System;
using Databvase_Winforms.Messages;
using DevExpress.Mvvm;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace Databvase_Winforms.Controls.QueryTextEditor
{
    public class QueryTextEditor : RichEditControl
    {
        private bool WasShown;
        public QueryTextEditor()
        {
            InitializeQueryTextEditor();
            RegisterMessages();
        }

        private void InitializeQueryTextEditor()
        {
            SetBackgroundColor();
            ShowLineNumbers();
            Enter += OnEnter; //TODO -This feels kind of hack-ish, but its the closest we have to "Shown"
        }

        private void OnEnter(object sender, EventArgs eventArgs)
        {
            if (WasShown) return;
            SetBackgroundColor();
            WasShown = true;
        }

        public void ShowLineNumbers()
        {
            Document.Sections[0].LineNumbering.RestartType = LineNumberingRestart.Continuous;
            Document.Sections[0].LineNumbering.Start = 1;
            Document.Sections[0].LineNumbering.CountBy = 1;
            Document.Sections[0].LineNumbering.Distance = 0.1f;
            Document.CharacterStyles["Line Number"].ForeColor = App.Config.TextEditorLineNumberColor;
        }

        private void SetBackgroundColor()
        {
            ActiveView.BackColor = App.Config.TextEditorBackgroundColor;
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
                SetBackgroundColor();
                SetLineColor();
            }
        }
    }
}
