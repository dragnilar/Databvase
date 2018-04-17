using System;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.Menu;
using DevExpress.CodeParser;
using DevExpress.XtraRichEdit.Services;

namespace Databvase_Winforms.Controls.QueryTextEditor
{
    public class QueryTextEditor : RichEditControl
    {
        private bool WasShown;
        public QueryTextEditor()
        {
            InitializeQueryTextEditor();

        }

        private void InitializeQueryTextEditor()
        {
            ShowLineNumbers();
            RegisterMessages();
            RegisterServices();
            HookUpEvents();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<SettingsUpdatedMessage>(this, SettingsUpdatedMessage.SettingsUpdatedSender, ApplySettingsUpdate);
        }

        private void RegisterServices()
        {
            ReplaceService<ISyntaxHighlightService>(new SQLSyntaxHighlightingService(Document));
        }

        private void HookUpEvents()
        {
            Enter += OnEnter; //TODO -This feels kind of hack-ish, but its the closest we have to "Shown"
            PopupMenuShowing += QueryTextEditor_PopupMenuShowing;
        }



        #region events
        private void OnEnter(object sender, EventArgs eventArgs)
        {
            if (WasShown) return;
            SetBackgroundColor();
            WasShown = true;
        }

        private void QueryTextEditor_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == RichEditMenuType.Text)
            {
                e.Menu.RemoveMenuItem(RichEditCommandId.ShowNumberingListForm);
                e.Menu.RemoveMenuItem(RichEditCommandId.CreateBookmark);
                e.Menu.RemoveMenuItem(RichEditCommandId.CreateHyperlink);
                e.Menu.RemoveMenuItem(RichEditCommandId.NewCommentContentMenu);
            }
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

        private void ApplySettingsUpdate(SettingsUpdatedMessage message)
        {
            if (message.Type == SettingsUpdatedMessage.SettingsUpdateType.TextEditorBackground)
            {
                SetBackgroundColor();
                SetLineColor();
            }
        }

        #endregion
    }
}
