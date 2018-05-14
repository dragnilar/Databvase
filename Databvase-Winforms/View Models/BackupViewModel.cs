﻿using System;
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
        public virtual bool VerifyBackupOnComplete { get; set; }
        public virtual bool PerformChecksum { get; set; }
        public virtual bool ContinueAfterError { get; set; }
        public virtual bool CopyOnly { get; set; }
        protected IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();


        public BackupViewModel()
        {
            CurrentDatabase = App.Connection.CurrentDatabase;
            StatusImageIndex = 0;
            ProgressMessage = "Ready";
            BackupName = string.Empty;
            IncrementalBackupOption = false;
            IncrementalTypeString = "Full";
            BackupPercentageComplete = 0;
            State = WindowState.Open;
            VerifyBackupOnComplete = false;
            CopyOnly = false;
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

        //Binds at runtime
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
            var verificationRestore = new Restore();
            verificationRestore.Devices.AddDevice(BackupName, DeviceType.File);
            verificationRestore.Database = CurrentDatabase.Name;
            var isBackupValid = verificationRestore.SqlVerify(App.Connection.CurrentServer);
            if (isBackupValid)
            {
                MessageBoxService.ShowMessage($"The backup for {CurrentDatabase.Name} is valid", "Backup Verification Result",
                    MessageButton.OK, MessageIcon.Information);
            }
            else
            {
                MessageBoxService.ShowMessage($"Warning: The backup for {CurrentDatabase.Name} is invalid \n" +
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
                ApplyBackupProperties();
                ProgressMessage = "In Progress";
                StatusImageIndex = 1;
                BackupProcess.SqlBackup(App.Connection.CurrentServer);
            }
            catch (Exception e)
            {
                MessageBoxService.ShowMessage(e.Message, "Error Starting Backup", MessageButton.OK, MessageIcon.Error);
                StatusImageIndex = 2;
                ProgressMessage = "Error";
            }
        }

        private void ApplyBackupProperties()
        {
            BackupProcess.Action = BackupActionType.Database;
            BackupProcess.Database = CurrentDatabase.Name;
            BackupProcess.Devices.AddDevice(BackupName, DeviceType.File);
            BackupProcess.BackupSetName = CurrentDatabase.Name + " Full Database Backup";
            BackupProcess.BackupSetDescription = string.Empty;
            BackupProcess.Initialize = false;
            BackupProcess.Incremental = IncrementalBackupOption;
            BackupProcess.Checksum = PerformChecksum;
            BackupProcess.ContinueAfterError = ContinueAfterError;
            BackupProcess.CopyOnly = CopyOnly;
        }

        private void Test()
        {
            var database = App.Connection.CurrentDatabase;

            var backupSetFiles = database.EnumBackupSetFiles();
            var backupSets = database.EnumBackupSets();
            

        }


        public enum  WindowState
        {
            Open,
            Closed
        }
    }
}
