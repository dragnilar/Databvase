using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Messages;
using DevExpress.Mvvm;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Models
{
    public class BackupContainer
    {
        public Backup CurrentBackup { get; set; }
        public Database CurrentDatabase { get; set; }
        public string BackupPath { get; set; }
        public bool IncrementalBackupOption { get; set; }


        public BackupContainer()
        {
            CurrentBackup = new Backup();
            CurrentDatabase = App.Connection.CurrentDatabase;
            BackupPath = string.Empty;
            IncrementalBackupOption = false;
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
            CurrentBackup.BackupSetName = CurrentDatabase.Name + " Full Database Backup";
            CurrentBackup.BackupSetDescription = string.Empty;
            CurrentBackup.Initialize = false;
            CurrentBackup.Incremental = IncrementalBackupOption;
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
