using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Databvase_Winforms.Models;
using DevExpress.Data.Helpers;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.DAL
{
    public class InClassName
    {
        public InClassName(string tableName, string databaseName)
        {
            TableName = tableName;
            DatabaseName = databaseName;
        }

        public string TableName { get; private set; }
        public string DatabaseName { get; private set; }
    }

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
                var server = App.Connection.GetServerAtCurrentDatabase();
                server.ConnectionContext.DatabaseName = App.Connection.CurrentDatabase;
                server.ConnectionContext.Connect();
                var dataset = server.ConnectionContext.ExecuteWithResults(sqlQuery);
                result = GetResult(dataset);
                server.ConnectionContext.Disconnect();
            }
            catch (Exception ex)
            {
                //TODO - Need to get back to better handling of the sql exceptions, this is just a hack
                result.HasErrors = true;
                result.ResultsMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return result;
        }

        private static QueryResult GetResult(DataSet ds)
        {
            var result = new QueryResult();
            var numberOfRows = 0;
            if (ds.Tables.Count > 0)
            {
               numberOfRows = ds.Tables[0].Rows.Count;
            }


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
                IsClustered = x.Field<bool>("IsClustered"),
                Name = x.Field<string>("Name"),
                ServerName = x.Field<string>("Server"),
                Version = x.Field<string>("Version"),
                Local = x.Field<bool>("IsLocal")
            }).ToList();

            return instanceList;
        }


        public static string GetServerName()
        {
            var server = App.Connection.GetServerAtCurrentConnection();
            return server.Name;
        }

        public static List<string> GetDatabaseNames()
        {
            var server = App.Connection.GetServerAtCurrentConnection();
            var list = new List<string>();
            foreach (Database db in server.Databases) list.Add(db.Name);

            return list;
        }

        public static List<Table> GetTables(string databaseName)
        {
            var dbList = GetDatabases();
            var db = dbList.First(r => r.Name == databaseName);
            var tablesList = new List<Table>();
            foreach (Table table in db.Tables)
            {
                tablesList.Add(table);
            }
            return tablesList;
        }

        public static List<Column> GetColumns(string tableName, string  databaseName)
        {
            var tablesList = GetTables(databaseName);
            var table = tablesList.First(r => r.Name == tableName);
            var columnsList = new List<Column>();
            foreach (Column col in table.Columns)
            {
                columnsList.Add(col);
            }

            return columnsList;
        }


        public static List<Database> GetDatabases()
        {
            var server = App.Connection.GetServerAtCurrentConnection();
            var list = new List<Database>();
            foreach (Database db in server.Databases)
            {
                list.Add(db);
            }

            return list;
        }




    }
}