using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Databvase_Winforms.Models;
using Databvase_Winforms.Services;
using LWSqlQueryTool_Winforms.Models;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.DAL
{
    public static class SQLServerInterface
    {
        /// <summary>
        ///     Sends a sql query to the sql server instance and database that are in the current connection string.
        ///     The sql query must be in the form of a string and can be anything such as select, update, etc.
        /// </summary>
        /// <param name="sqlQuery">A plain text sql query such as select * from tableName</param>
        /// <returns>QueryResult</returns>
        public static QueryResult SendQueryAndGetResult(string sqlQuery)
        {
            var result = new QueryResult();
            try
            {
                var server = ConnectionService.GetServerAtCurrentDatabase();
                server.ConnectionContext.DatabaseName = ConnectionService.CurrentDatabase;
                server.ConnectionContext.Connect();
                var dataset = server.ConnectionContext.ExecuteWithResults(sqlQuery);
                result = GetResult(dataset);
                server.ConnectionContext.Disconnect();
            }
            catch (SqlException ex)
            {
                result.HasErrors = true;
                result.ResultsMessage = ProcessSqlErrors(ex);
            }

            return result;
        }

        private static QueryResult GetResult(DataSet ds)
        {
            var result = new QueryResult();

            var numberOfRows = ds.Tables[0].Rows.Count;

            result.ResultsMessage = numberOfRows > 0
                ? numberOfRows + " row(s) affected."
                : "Command(s) completed successfully";

            result.ResultsSet = ds;
            result.HasErrors = false;

            return result;
        }

        private static string ProcessSqlErrors(SqlException ex)
        {
            var errorMessage = string.Empty;
            foreach (SqlError error in ex.Errors) errorMessage = $"{error.Message}\n";
            return errorMessage;
        }

        /// <summary>
        ///     Gets a list of instances on the same network as the computer that the application is running.
        ///     This method takes a long time to run.
        /// </summary>
        /// <returns></returns>
        public static List<SQLServerInstance> GetInstances()
        {
            var instancesTable = SmoApplication.EnumAvailableSqlServers(false);

            var instanceList = instancesTable.AsEnumerable().Select(x => new SQLServerInstance
            {
                InstanceName = x.Field<string>("Instance"),
                IsClustered = x.Field<string>("IsClustered"),
                Name = x.Field<string>("Name"),
                ServerName = x.Field<string>("Server"),
                Version = x.Field<string>("Version"),
                Local = x.Field<string>("IsLocal")
            }).ToList();

            return instanceList;
        }


        private static List<string> GetDatabases()
        {
            var server = ConnectionService.GetServer();
            var list = new List<string>();
            foreach (Database db in server.Databases) list.Add(db.Name);

            return list;
        }


        /// <summary>
        ///     Returns a sql schema object for the database specified in the connection string.
        /// </summary>
        /// <returns></returns>
        public static SQLSchema GetSqlSchema()
        {
            var server = ConnectionService.GetServer();
            var schema = new SQLSchema();
            server.ConnectionContext.Connect();

            schema.InstanceName = server.InstanceName;
            var dbList = GetDatabases();

            foreach (var dbName in dbList)
                schema.Databases.Add(new SQLDatabase
                {
                    DataBaseName = dbName,
                    Tables = GetDatabaseTables(dbName),
                    Columns = GetDatabaseColumns(dbName)
                });


            return schema;
        }

        private static List<SQLTable> GetDatabaseTables(string dbName)
        {
            var server = ConnectionService.GetServer(dbName);
            server.ConnectionContext.Connect();
            var result = server.ConnectionContext.ExecuteWithResults(
                "select * from INFORMATION_SCHEMA.TABLES");
            server.ConnectionContext.Disconnect();

            return result.Tables.Count > 0
                ? SQLServerInterfaceUtilities.ConvertTableDataTableToList(result.Tables[0])
                : new List<SQLTable>();
        }

        private static List<SQLColumn> GetDatabaseColumns(string dbName)
        {
            var server = ConnectionService.GetServer(dbName);
            server.ConnectionContext.Connect();
            var result = server.ConnectionContext.ExecuteWithResults(
                "select * from INFORMATION_SCHEMA.COLUMNS");
            server.ConnectionContext.Disconnect();

            return result.Tables.Count > 0
                ? SQLServerInterfaceUtilities.ConvertColumnsDataTableToList(result.Tables[0])
                : new List<SQLColumn>();
        }
    }
}