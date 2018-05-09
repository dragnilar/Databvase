using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
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

        public virtual string BackupName { get; set; }
        public virtual string ProgressMessage { get; set; }
        public virtual string RecoveryModel { get; set; }
        public virtual string CurrentInstanceName { get; set; }
        public virtual string CurrentLoginName { get; set; }
        public virtual int StatusImageIndex { get; set; }
        public virtual Database CurrentDatabase { get; set; }
        public virtual int BackupPercentageComplete {get; set; }
        private Backup BackupProcess = new Backup();
        public virtual WindowState State { get; set; }
        public virtual List<Database> DatabaseList { get; set; }
        public virtual List<string> IncrementalTypes { get; set; }
        public virtual string IncrementalTypeString { get; set; }
        public virtual bool IncrementalBackupOption { get; set; }
        protected IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();


        public BackupViewModel()
        {
            CurrentDatabase = App.Connection.InstanceTracker.CurrentDatabase;
            StatusImageIndex = 0;
            ProgressMessage = "Ready";
            BackupName = string.Empty;
            IncrementalBackupOption = false;
            IncrementalTypeString = "Full";
            BackupPercentageComplete = 0;
            State = WindowState.Open;
            HookUpEvents();
            GetRecoveryModel();
            GetDatabaseList();
            GetCurrentInstanceAndLogin();
            GetIncrementalOptions();
        }

        //Binds at runtime
        protected void OnCurrentDatabaseChanged()
        {
            GetRecoveryModel();
        }

        protected void OnIncrementalTypeStringChanged()
        {
            IncrementalBackupOption = IncrementalTypeString != "Full";
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
            CurrentInstanceName = App.Connection.InstanceTracker.CurrentInstance.Name;
            CurrentLoginName = App.Connection.InstanceTracker.CurrentInstance.ConnectionContext.TrueLogin;
        }

        private void GetDatabaseList()
        {
            DatabaseList = new List<Database>();
            foreach(Database db in App.Connection.InstanceTracker.CurrentInstance.Databases) DatabaseList.Add(db);
        }

        private void HookUpEvents()
        {
            BackupProcess.Complete += BackupProcessOnComplete;
            BackupProcess.PercentComplete += BackupProcessOnPercentComplete;
        }

        private void BackupProcessOnPercentComplete(object sender, PercentCompleteEventArgs e)
        {
            StatusImageIndex = 1;
            BackupPercentageComplete = e.Percent;
        }

        private void BackupProcessOnComplete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error.Number == 3014)
            {
                StatusImageIndex = 0;
                ProgressMessage = "Complete";
                MessageBoxService.ShowMessage("Backup Completed Successfully!", "Backup Complete", MessageButton.OK,
                    MessageIcon.Information);
                State = WindowState.Closed;

            }
            else
            {
                StatusImageIndex = 2;
                ProgressMessage = "Error";
                BackupPercentageComplete = 0;
                MessageBoxService.ShowMessage(e.Error.Message, "Backup Failed", MessageButton.OK, MessageIcon.Error);

            }
        }

        private string GetBackupPath()
        {
            if (CurrentDatabase != null)
            {
                DataTable backupSets = CurrentDatabase.EnumBackupSets();

                foreach (DataRow row in backupSets.Rows)
                {
                    //Is this even useful? 
                }
            }

            return null;
        }

        private void GetRecoveryModel()
        {
            if (CurrentDatabase != null)
                RecoveryModel = CurrentDatabase.RecoveryModel.ToString();
        }

        public void Cancel()
        {
            State = WindowState.Closed;
        }

        public void ValidateAndRunBackup()
        {
            if (string.IsNullOrEmpty(BackupName.Trim()))
            {
                MessageBoxService.ShowMessage("You must enter a backup path.");
                return;
            }

            if (CurrentDatabase == null)
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
                BackupProcess.Action = BackupActionType.Database;
                BackupProcess.Database = CurrentDatabase.Name;
                BackupProcess.Devices.AddDevice(BackupName, DeviceType.File);
                BackupProcess.BackupSetName = CurrentDatabase.Name + " Full Database Backup";
                BackupProcess.BackupSetDescription = string.Empty;
                BackupProcess.Initialize = false;
                BackupProcess.Incremental = IncrementalBackupOption;
                ProgressMessage = "In Progress";
                StatusImageIndex = 1;
                BackupProcess.SqlBackup(App.Connection.InstanceTracker.CurrentInstance);
            }
            catch (Exception e)
            {
                MessageBoxService.ShowMessage(e.Message, "Error Starting Backup", MessageButton.OK, MessageIcon.Error);
                StatusImageIndex = 2;
                ProgressMessage = "Error";
            }
        }


        public enum  WindowState
        {
            Open,
            Closed
        }
    }
}
