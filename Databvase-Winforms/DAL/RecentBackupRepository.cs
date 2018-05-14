using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Models;

namespace Databvase_Winforms.DAL
{
    //TODO - This probably isn't the most elegant or whatever way of doing a repository
    public class RecentBackupRepository 
    {

        public List<RecentBackup> GetMostRecentBackupsForDatabase(string databaseName)
        {
            var sqlQuery = new SQLQuery();
            var queryString =
                "SELECT\r\n    bs.database_name,\r\n    bs.backup_start_date,\r\n\tbs.backup_finish_date,\r\n    bmf.physical_device_name\r\nFROM\r\n    " +
                "msdb.dbo.backupmediafamily bmf\r\n    JOIN\r\n    msdb.dbo.backupset bs ON bs.media_set_id = bmf.media_set_id\r\nWHERE\r\n   " +
                $" bs.database_name = \'{databaseName}\'\r\nORDER BY\r\n    bs.backup_finish_date DESC;";

            var result = sqlQuery.SendQueryAndGetResult(queryString, databaseName, App.Connection.GetCurrentConnection());

            return !result.HasErrors ? MapResultsToObjects(result.ResultsSet.Tables[0]) : null; //TODO - We probably need to return the error...
        }


        private List<RecentBackup> MapResultsToObjects(DataTable table)
        {
            List<RecentBackup> backupList = new List<RecentBackup>();
            foreach (var recentBackup in table.AsEnumerable().Select(x => new RecentBackup
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
