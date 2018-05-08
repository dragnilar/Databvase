using System.ComponentModel;
using System.Windows.Forms;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Models.Data_Providers;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel()]
    public class ServerFolderExplorerViewModel
    {

        public virtual string SelectedFolderPath { get; set; }
        public virtual string SelectedBackupFilePath { get; set; }
        public virtual WindowState State { get; set; }


        public ServerFolderExplorerViewModel()
        {
            SelectedFolderPath = string.Empty;
            SelectedBackupFilePath = string.Empty;
            State = WindowState.Open;
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<ServerExplorerNodeChangedMessage>(this,
                typeof(ServerExplorerNodeChangedMessage).Name, OnNodeChangedMessage);
        }

        private void OnNodeChangedMessage(ServerExplorerNodeChangedMessage message)
        {
            if (message != null)
            {
                SelectedFolderPath = message.SelectedFolderPath;
                SelectedBackupFilePath = message.SelectedBackupFilePath;
            }
        }

        //Binds at runtime
        protected void OnSelectedBackupFilePathChanged()
        {
            State = !string.IsNullOrEmpty(SelectedBackupFilePath.Trim()) ? WindowState.ReadyToSave : WindowState.Open;
        }



        public void SaveAndClose()
        {
            new BackupPathMessage(SelectedBackupFilePath);
            State = WindowState.Close;
        }

        public void Close()
        {
            State = WindowState.Close;
        }


        public enum WindowState
        {
            Open,
            ReadyToSave,
            Close
        }

    }
}
