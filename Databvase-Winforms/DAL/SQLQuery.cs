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

    public class SQLQuery
    {
        /// <summary>
        ///     Sends a sql query to the sql server instance and database that are in the current connection string.
        ///     The sql query must be in the form of a string and can be anything such as select, update, etc.
        /// </summary>
        /// <param name="sqlQuery">A plain text sql query such as select * from tableName</param>
        /// <returns>QueryResult</returns>
        public QueryResult SendQueryAndGetResult(string sqlQuery, string dataBase, SavedConnection connection)
        {
            var result = new QueryResult();
            try
            {
                result = Query(sqlQuery, dataBase, connection);
            }
            catch (SqlException ex)
            {
                result.HasErrors = true;
                result.ResultsMessage = ProcessSqlErrors(ex);
            }
            catch (Exception ex)
            {
                result.HasErrors = true;
                result.ResultsMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return result;
        }

        private QueryResult Query(string sqlQuery, string dataBaseName, SavedConnection connection)
        {
            var server = connection.GetServer(dataBaseName);
            server.ConnectionContext.DatabaseName = dataBaseName;
            server.ConnectionContext.Connect();
            var queryDataSet = server.ConnectionContext.ExecuteWithResults(sqlQuery);
            var result = GetResult(queryDataSet);
            server.ConnectionContext.Disconnect();
            return result;
        }

        private QueryResult GetResult(DataSet ds)
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

        private string ProcessSqlErrors(SqlException ex)
        {
            var errorMessage = string.Empty;
            foreach (SqlError error in ex.Errors) errorMessage = $"{error.Message}\n";
            return errorMessage;
        }
    }
}