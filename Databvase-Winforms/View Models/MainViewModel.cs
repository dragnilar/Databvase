using System.Linq;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Modules;
using Databvase_Winforms.Services;

namespace Databvase_Winforms.View_Models
{
    [MetadataType(typeof(MetaData))]
    public class MainViewModel
    {

        public IDocumentManagerService DocumentManagerService => this.GetRequiredService<IDocumentManagerService>();
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
            Messenger.Default.Register<InstanceConnectedMessage>(this, InstanceConnectedMessage.ConnectInstanceSender, ReceiveInstanceConnectedMessage);
            Messenger.Default.Register<InstanceNameChangeMessage>(this, InstanceNameChangeMessage.NewInstanceNameSender, ReceiveInstanceNameChangedMessage);
        }

        private void ReceiveInstanceNameChangedMessage(InstanceNameChangeMessage message)
        {
            if (message != null)
            {
                ChangeInstanceName(message.InstanceName);
            }
        }

        private void ReceiveInstanceConnectedMessage(InstanceConnectedMessage message)
        {
            if (message != null)
            {
                ChangeInstanceName(message.InstanceName);
            }
        }


        private void ChangeInstanceName(string instanceName)
        {
            if (!string.IsNullOrEmpty(instanceName))
            {
                App.Connection.CurrentInstance = instanceName;
            }
        }

        public void AddNewTab()
        {
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

        protected void SaveTextEditorColors()
        {
            if (Loading)
            {
                return;
            }
            App.Config.TextEditorBackgroundColor = TextEditorBackgroundColor;
            App.Config.TextEditorLineNumberColor = TextEditorLineNumberColor;
            App.Config.Save();
            Messenger.Default.Send(new SettingsUpdatedMessage(SettingsUpdatedMessage.SettingsUpdateType.TextEditorBackground), 
                SettingsUpdatedMessage.SettingsUpdatedSender);
        }

        public class MetaData : IMetadataProvider<MainViewModel>
        {
            public void BuildMetadata(MetadataBuilder<MainViewModel> builder)
            {
                builder.Property(x => x.TextEditorBackgroundColor).OnPropertyChangedCall(x => x.SaveTextEditorColors());
                builder.Property(x => x.TextEditorLineNumberColor).OnPropertyChangedCall(x => x.SaveTextEditorColors());
            }
        }
    }

}