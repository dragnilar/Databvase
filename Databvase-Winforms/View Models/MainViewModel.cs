using System;
using System.Linq;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Models;
using Databvase_Winforms.Modules;
using Databvase_Winforms.Services;
using Databvase_Winforms.Services.Window_Dialog_Services;
using DevExpress.Utils.MVVM.Services;

namespace Databvase_Winforms.View_Models
{
    [MetadataType(typeof(MetaData))]
    public class MainViewModel
    {

        public IDocumentManagerService DocumentManagerService => this.GetRequiredService<IDocumentManagerService>();
        protected ISplashScreenService SplashScreenService => this.GetService<ISplashScreenService>();
        protected IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();
        protected IBackupViewService BackupViewService => this.GetService<IBackupViewService>();
        public virtual int NumberOfQueries { get; set; }
        public virtual Color TextEditorBackgroundColor { get; set; }
        public virtual Color TextEditorLineNumberColor { get; set; }
        public virtual bool InstancesConnected { get; set; }
        private readonly bool _loading = true;

        public MainViewModel()
        {
            NumberOfQueries = 0;
            TextEditorBackgroundColor = App.Config.TextEditorBackgroundColor;
            TextEditorLineNumberColor = App.Config.TextEditorLineNumberColor;
            _loading = false;
            RegisterMessages();
        }
        private void RegisterMessages()
        {
            Messenger.Default.Register<InstanceConnectedMessage>(this, typeof(InstanceConnectedMessage).Name, ReceiveInstanceConnectedMessage);
            Messenger.Default.Register<InstanceNameChangeMessage>(this, typeof(InstanceNameChangeMessage).Name, ReceiveInstanceNameChangedMessage);
            Messenger.Default.Register<NewScriptMessage>(this, typeof(NewScriptMessage).Name, AddTabWithScriptText);
        }

        private void ReceiveInstanceNameChangedMessage(InstanceNameChangeMessage message)
        {
            if (message != null)
            {
                ChangeInstanceName(message.Tracker);
            }
        }

        private void ReceiveInstanceConnectedMessage(InstanceConnectedMessage message)
        {
            if (message != null)
            {
                ChangeInstanceName(message.Tracker);
                CheckConnections();

            }
        }

        private void ChangeInstanceName(InstanceAndDatabaseTracker tracker)
        {
            if (tracker?.CurrentInstance != null)
            {
                App.Connection.UpdateInstanceAndDatabaseTracker(tracker);

            }
        }

        public void CheckToShowConnectionsAtStartup()
        {
            if (App.Config.ShowConnectionWindowOnStartup)
            {
                Connect();
            }
        }


        public void Connect()
        {
            this.GetService<IConnectionWindowService>().ShowDialog();
        }

        public void Disconnect()
        {
            new DisconnectInstanceMessage(App.Connection.CurrentServer.Name);
            CheckConnections();
        }

        private void CheckConnections()
        {
            InstancesConnected = App.Connection.CurrentConnections.Count > 0;
        }



        /// <summary>
        /// Creates a new query tab that is displayed in the document manager on the main view.
        /// </summary>
        public void AddBlankTab()
        {
            GenerateNewQueryTextEditor();
        }

        private void AddTabWithScriptText(NewScriptMessage message)
        {
            if (message != null)
            {
                GenerateNewQueryTextEditor(message);
            }
        }

        private void GenerateNewQueryTextEditor(NewScriptMessage optionalNewScriptMessage = null)
        {
            ShowSplashScreen();
            NumberOfQueries++;
            var vm = QueryControlViewModel.Create();
            if (optionalNewScriptMessage != null) vm.ReceiveNewScriptMessageAndSetScriptText(optionalNewScriptMessage);
            var document = DocumentManagerService.CreateDocument("QueryControl", vm);
            document.Title = $"Query {NumberOfQueries}";
            document.DestroyOnClose = true;
            document.Show();
            HideSplashScreen();
        }

        public void ShowSettings()
        {
            this.GetService<ISettingsWindowService>().ShowDialog();
        }

        public void ShowTextEditorFontDialog()
        {
            var dialogResult = this.GetService<ITextEditorFontChangeService>().ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                new SettingsUpdatedMessage(SettingsUpdatedMessage.SettingsUpdateType.TextEditorFontStyle);
            }
        }

        public void ShowQueryBuilder()
        {
            if (App.Connection.CurrentDatabase == null)
            {
                MessageBoxService.ShowMessage(
                    "Please select a database from the object explorer before using the Query Builder",
                    "Database Required For Query Builder",
                    MessageButton.OK, MessageIcon.Information);
                return;
            }
            this.GetService<IQueryBuilderService>().ShowQueryBuilder();
        }

        public void ShowBackupWizard()
        {
            if (App.Connection.CurrentServer == null)
            {
                MessageBoxService.ShowMessage("Please connect to an instance before attempting to perform a backup.",
                    "No Instance Connected",
                    MessageButton.OK, MessageIcon.Stop);
                return;
            }
            BackupViewService.Show();
        }

        #region Skin Methods
        public void ShowBezierPaletteSwitcher()
        {
            this.GetService<ISkinService>().ChangeBezierPalette();
        }

        public void ShowColorMixer()
        {
            this.GetService<ISkinService>().ChangeColorSwatch();
        }
        #endregion

        #region Splash Screen Methods
        public void ShowSplashScreen()
        {
            if (!SplashScreenService.IsSplashScreenActive)
            {
                SplashScreenService.ShowSplashScreen();
            }
        }

        public void HideSplashScreen()
        {
            if (SplashScreenService.IsSplashScreenActive)
            {
                SplashScreenService.HideSplashScreen();
            }
        }
        #endregion

        #region MetaData Bindings

        public class MetaData : IMetadataProvider<MainViewModel>
        {
            public void BuildMetadata(MetadataBuilder<MainViewModel> builder)
            {
                builder.Property(x => x.TextEditorBackgroundColor).OnPropertyChangedCall(x => x.SaveTextEditorColors());
                builder.Property(x => x.TextEditorLineNumberColor).OnPropertyChangedCall(x => x.SaveTextEditorColors());
            }
        }

        protected void SaveTextEditorColors()
        {
            if (_loading)  //TODO - This was necessary because this event can get fired prematurely, see if there is a way to avoid having to do this
            {
                return;
            }
            App.Config.TextEditorBackgroundColor = TextEditorBackgroundColor;
            App.Config.TextEditorLineNumberColor = TextEditorLineNumberColor;
            App.Config.Save();
            new SettingsUpdatedMessage(SettingsUpdatedMessage.SettingsUpdateType.TextEditorBackground);
        }

        #endregion


    }

}