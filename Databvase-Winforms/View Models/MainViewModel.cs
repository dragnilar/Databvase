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
        private bool Loading = true;




        public MainViewModel()
        {
            NumberOfQueries = 0;
            TextEditorBackgroundColor = App.Config.TextEditorBackgroundColor;
            TextEditorLineNumberColor = App.Config.TextEditorLineNumberColor;
            Loading = false;
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
            }
        }


        private void ChangeInstanceName(InstanceAndDatabaseTracker tracker)
        {
            if (tracker?.CurrentInstance != null)
            {
                App.Connection.InstanceTracker = tracker;

            }
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


        private class DocumentInfo
        {
            public string DocumentType;
            public string DocumentTitle;

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

        protected void SaveTextEditorColors()
        {
            if (Loading)  //TODO - This was necessary because this event can get fired prematurely, see if there is a way to avoid having to do this
            {
                return;
            }
            App.Config.TextEditorBackgroundColor = TextEditorBackgroundColor;
            App.Config.TextEditorLineNumberColor = TextEditorLineNumberColor;
            App.Config.Save();
            new SettingsUpdatedMessage(SettingsUpdatedMessage.SettingsUpdateType.TextEditorBackground);
        }

        public class MetaData : IMetadataProvider<MainViewModel>
        {
            public void BuildMetadata(MetadataBuilder<MainViewModel> builder)
            {
                builder.Property(x => x.TextEditorBackgroundColor).OnPropertyChangedCall(x => x.SaveTextEditorColors());
                builder.Property(x => x.TextEditorLineNumberColor).OnPropertyChangedCall(x => x.SaveTextEditorColors());
            }
        }

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
    }

}