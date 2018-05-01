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

    public static class SQLServerInterface
    {
        /// <summary>
        ///     Sends a sql query to the sql server instance and database that are in the current connection string.
        ///     The sql query must be in the form of a string and can be anything such as select, update, etc.
        /// </summary>
        /// <param name="sqlQuery">A plain text sql query such as select * from tableName</param>
        /// <returns>QueryResult</returns>
        public static QueryResult SendQueryAndGetResult(string sqlQuery, string dataBase, SavedConnection connection)
        {
            var result = new QueryResult();
            try
            {
                var server = App.Connection.GetServerAtSpecificConnection(connection, dataBase);
                server.ConnectionContext.DatabaseName = dataBase;
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

            var instanceList = new List<SQLServerInstance>();
            foreach (var instance in instancesTable.AsEnumerable()
                .Select(x => new SQLServerInstance
                {
                    InstanceName = x.Field<string>("Instance"),
                    IsClustered = x.Field<bool>("IsClustered"),
                    Name = x.Field<string>("Name"),
                    ServerName = x.Field<string>("Server"),
                    Version = x.Field<string>("Version"),
                    Local = x.Field<bool>("IsLocal")
                }))
                instanceList.Add(instance);

            return instanceList;
        }
    }
}