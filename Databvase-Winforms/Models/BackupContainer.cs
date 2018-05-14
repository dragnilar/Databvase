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

        public void GetMostRecentBackupsFromSQL()
        {
            var sqlQuery = new SQLQuery();
            var queryString =
                "SELECT\r\n    bs.database_name,\r\n    bs.backup_start_date,\r\n\tbs.backup_finish_date,\r\n    bmf.physical_device_name\r\nFROM\r\n    " +
                "msdb.dbo.backupmediafamily bmf\r\n    JOIN\r\n    msdb.dbo.backupset bs ON bs.media_set_id = bmf.media_set_id\r\nWHERE\r\n   " +
                " bs.database_name = \'InsignificantDatabase\'\r\nORDER BY\r\n    bmf.media_set_id DESC;";

            var result = sqlQuery.SendQueryAndGetResult(queryString, CurrentDatabase.Name, App.Connection.GetCurrentConnection());

            if (!result.HasErrors)
            {
                var list = ConvertResultsToObjects(result.ResultsSet.Tables[0]);
                Debug.WriteLine(list.First().PhysicalDeviceName);
            }

        }

        private List<RecentBackup> ConvertResultsToObjects(DataTable table)
        {
            List<RecentBackup> backupList = new List<RecentBackup>();
            foreach (var recentBackup in table.AsEnumerable().Select(x=> new RecentBackup
            {
                DatabaseName = x.Field<string>("database_name"),
                BackupStartDate = x.Field<DateTime>("backup_start_date"),
                BackupFinishTime = x.Field<DateTime>("backup_finish_date"),
                PhysicalDeviceName = x.Field<string>("physical_device_name")
            }))
                backupList.Add(recentBackup);


            return backupList;
        }
    }
}
