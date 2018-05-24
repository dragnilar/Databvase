using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Messages;
using DevExpress.Mvvm;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Models
{
    public class SMOBackupProcess
    {
        public Backup CurrentBackup { get; set; }
        private Database _currentDatabase;
        public string BackupPath { get; set; }
        public bool IncrementalBackupOption { get; set; }
        public bool UseExpireAfterDays { get; set; }
        public int ExpireAfterDays { get; set; }
        public DateTime ExpireDate { get; set; }
        public string RecoveryModelString => _currentDatabase.RecoveryModel.ToString();

        public Database CurrentDatabase
        {
            get => _currentDatabase;
            set => SetCurrentDatabase(value);
        }

        private void SetCurrentDatabase(Database value)
        {
            _currentDatabase = value;
            GetCurrentDatabaseMostRecentBackupPath();
        }

        private void GetCurrentDatabaseMostRecentBackupPath()
        {

            if (CurrentDatabase != null)
            {
                BackupPath = new RecentBackupRepository().GetMostRecentBackupsForDatabase(CurrentDatabase.Name).FirstOrDefault()
                    ?.PhysicalDeviceName;
            }
        }

        public SMOBackupProcess()
        {
            CurrentBackup = new Backup();
            BackupPath = string.Empty;
            IncrementalBackupOption = false;
            UseExpireAfterDays = false;
            ExpireDate = DateTime.Now;
        }

        public void RunCurrentBackup()
        {
            ApplyBackupProperties();
            CurrentBackup.SqlBackup(App.Connection.CurrentServer);
        }

        private void ApplyBackupProperties()
        {
            CurrentBackup.Action = BackupActionType.Database;
            CurrentBackup.Database = CurrentDatabase.Name;
            CurrentBackup.Devices.AddDevice(BackupPath, DeviceType.File);
            CurrentBackup.Initialize = false;
            CurrentBackup.Incremental = IncrementalBackupOption;
            GetBackupExpirationDate();
        }

        private void GetBackupExpirationDate()
        {
            if (UseExpireAfterDays)
            {
                if (ExpireAfterDays > 0)
                {
                    CurrentBackup.ExpirationDate = DateTime.Now.AddDays(ExpireAfterDays);
                }
            }
            else
            {
                CurrentBackup.ExpirationDate = ExpireDate;
            }
        }

        public bool VerifyBackup()
        {
            var verificationRestore = new Restore();
            verificationRestore.Devices.AddDevice(BackupPath, DeviceType.File);
            verificationRestore.Database = CurrentDatabase.Name;
            return verificationRestore.SqlVerify(App.Connection.CurrentServer);
        }
    }
}
