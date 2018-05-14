using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Models;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel()]
    public class BackupViewModel
    {

        public virtual string ProgressMessage { get; set; }
        public virtual string RecoveryModel { get; set; }
        public virtual string CurrentInstanceName { get; set; }
        public virtual string CurrentLoginName { get; set; }
        public virtual int StatusImageIndex { get; set; }
        public virtual int BackupPercentageComplete {get; set; }
        public virtual BackupContainer BackupEntityForVm { get; set; }
        public virtual WindowState State { get; set; }
        public virtual List<Database> DatabaseList { get; set; }
        public virtual List<string> IncrementalTypes { get; set; }
        public virtual string IncrementalTypeString { get; set; }
        public virtual bool VerifyBackupOnComplete { get; set; }
        protected IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();


        public BackupViewModel()
        {
            BackupEntityForVm = new BackupContainer();
            StatusImageIndex = 0;
            ProgressMessage = "Ready";
            IncrementalTypeString = "Full";
            BackupPercentageComplete = 0;
            State = WindowState.Open;
            VerifyBackupOnComplete = false;
            HookUpEvents();
            GetRecoveryModel();
            GetDatabaseList();
            GetCurrentInstanceAndLogin();
            GetIncrementalOptions();
            Test();
        }

        //Binds at runtime
        protected void OnCurrentDatabaseChanged()
        {
            GetRecoveryModel();
            BackupEntityForVm.GetMostRecentBackupsFromSQL();
        }

        //Binds at runtime
        protected void OnIncrementalTypeStringChanged()
        {
            BackupEntityForVm.IncrementalBackupOption = IncrementalTypeString != "Full";
            
        }

        private void GetIncrementalOptions()
        {
            IncrementalTypes =  new List<string>
            {
                "Full",
                "Incremental"
            };

        }

        private void GetCurrentInstanceAndLogin()
        {
            CurrentInstanceName = App.Connection.CurrentServer.Name;
            CurrentLoginName = App.Connection.CurrentServer.ConnectionContext.TrueLogin;
        }

        private void GetDatabaseList()
        {
            DatabaseList = new List<Database>();
            foreach(Database db in App.Connection.CurrentServer.Databases) DatabaseList.Add(db);
        }

        private void HookUpEvents()
        {
            BackupEntityForVm.CurrentBackup.Complete += BackupEntityOnComplete;
            BackupEntityForVm.CurrentBackup.PercentComplete += BackupEntityOnPercentComplete;
        }

        private void BackupEntityOnPercentComplete(object sender, PercentCompleteEventArgs e)
        {
            StatusImageIndex = 1;
            BackupPercentageComplete = e.Percent;
        }

        private void BackupEntityOnComplete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error.Number == 3014)
            {
                FinalizeBackup();
            }
            else
            {
                HandleBackupFailureError(e);
            }
        }

        private void FinalizeBackup()
        {
            StatusImageIndex = 0;
            ProgressMessage = "Complete";
            MessageBoxService.ShowMessage("Backup Completed Successfully!", "Backup Complete", MessageButton.OK,
                MessageIcon.Information);
            VerifyBackup();
            State = WindowState.Closed;
        }

        private void VerifyBackup()
        {
            if (!VerifyBackupOnComplete) return;

            if (BackupEntityForVm.VerifyBackup())
            {
                MessageBoxService.ShowMessage($"The backup for {BackupEntityForVm.CurrentDatabase.Name} is valid", "Backup Verification Result",
                    MessageButton.OK, MessageIcon.Information);
            }
            else
            {
                MessageBoxService.ShowMessage($"Warning: The backup for {BackupEntityForVm.CurrentDatabase.Name} is invalid \n" +
                                              $"It is recommended that you create another backup. If this problem persists\n" +
                                              $"you may have an issue with data corruption. ", "Backup Verification Result",
                    MessageButton.OK, MessageIcon.Warning);
            }
        }

        private void HandleBackupFailureError(ServerMessageEventArgs e)
        {
            StatusImageIndex = 2;
            ProgressMessage = "Error";
            BackupPercentageComplete = 0;
            MessageBoxService.ShowMessage(e.Error.Message, "Backup Failed", MessageButton.OK, MessageIcon.Error);
        }

        private void GetRecoveryModel()
        {
            if (BackupEntityForVm.CurrentDatabase != null)
                RecoveryModel = BackupEntityForVm.CurrentDatabase.RecoveryModel.ToString();
        }

        public void Cancel()
        {
            State = WindowState.Closed;
        }

        public void ValidateAndRunBackup()
        {
            if (string.IsNullOrEmpty(BackupEntityForVm.BackupPath.Trim()))
            {
                MessageBoxService.ShowMessage("You must enter a backup path.");
                return;
            }

            if (BackupEntityForVm.CurrentDatabase == null)
            {
                MessageBoxService.ShowMessage("You must select a database to backup");
                return;
            }

            RunBackup();
        }

        private void RunBackup()
        {
            try
            {
                ProgressMessage = "In Progress";
                StatusImageIndex = 1;
                BackupEntityForVm.RunCurrentBackup();
            }
            catch (Exception e)
            {
                MessageBoxService.ShowMessage(e.Message, "Error Starting Backup", MessageButton.OK, MessageIcon.Error);
                StatusImageIndex = 2;
                ProgressMessage = "Error";
            }
        }

        public void Update()
        {
            //This is needed for the MVVM Context in the view to create two way bindings back to the BackupEntityForVM
        }

        private void Test()
        {

        }


        public enum  WindowState
        {
            Open,
            Closed
        }
    }
}
