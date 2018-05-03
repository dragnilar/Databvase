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

namespace Databvase_Winforms.View_Models
{
    [MetadataType(typeof(MetaData))]
    public class MainViewModel
    {

        public IDocumentManagerService DocumentManagerService => this.GetRequiredService<IDocumentManagerService>();
        protected ISplashScreenService SplashScreenService => this.GetService<ISplashScreenService>();
        public virtual int NumberOfQueries { get; set; }
        public virtual Color TextEditorBackgroundColor { get; set; }
        public virtual Color TextEditorLineNumberColor { get; set; }
        public virtual bool InstancesConnected { get; set; }
        private readonly bool _loading = true;
        


        private class DocumentInfo //TODO - We may want to move this to its own file to avoid cluttering up the View Model
        {
            public string DocumentType;
            public string DocumentTitle;

        }


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
                App.Connection.InstanceTracker = tracker;

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
            new DisconnectInstanceMessage(App.Connection.InstanceTracker.CurrentInstance.Name);
            CheckConnections();
        }

        private void CheckConnections()
        {
            InstancesConnected = App.Connection.CurrentConnections.Count > 0;
        }

        public void AddNewTab()
        {
            ShowSplashScreen();
            NumberOfQueries++;
            var vm = new QueryControlViewModel();
            var docInfo = new DocumentInfo
            {
                DocumentTitle = $"Query {NumberOfQueries}",
                DocumentType = "QueryControl"
            };
            var document = DocumentManagerService.CreateDocument(docInfo.DocumentType, vm);
            document.Title = docInfo.DocumentTitle;
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