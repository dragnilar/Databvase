using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using LWSqlQueryTool_Winforms.Models;
using LWSqlQueryTool_Winforms.Services;

namespace LWSqlQueryTool_Winforms.DAL
{
    public static class SQLServerInterface
    {
        /// <summary>
        /// Sends a sql query to the sql server instance and database that are in the current connection string.
        /// The sql query must be in the form of a string and can be anything such as select, update, etc.
        /// </summary>
        /// <param name="sqlQuery">A plain text sql query such as select * from tableName</param>
        /// <returns>QueryResult</returns>
        public static QueryResult SendQueryAndGetResult(string sqlQuery)
        {
            var result = new QueryResult();
            try
            {
                using (var connection = new SqlConnection(ConnectionStringService.CurrentConnectionString))
                {
                    connection.Open();
                    var cmd = new SqlCommand
                    {
                        CommandText = sqlQuery,
                        CommandType = CommandType.Text,
                        Connection = connection
                    };
                    var adapter = new SqlDataAdapter(cmd);
                    result = GetResult(adapter);
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                result.HasErrors = true;
                result.ResultsMessage = ProcessSqlErrors(ex);
            }
            return result;
        }

        private static QueryResult GetResult(SqlDataAdapter adapter)
        {
            var result = new QueryResult();
            var ds = new DataSet();

            var numberOfRows = adapter.Fill(ds);

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
            foreach (SqlError error in ex.Errors) errorMessage = $"ERROR: {error.Message}\n";
            return errorMessage;
        }

        /// <summary>
        /// Tests a connection to SQL Server using the specified connection string.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>True or False</returns>
        public static bool TestConnection(string connectionString)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var command = new SqlCommand())
                    {
                        command.CommandText = "SELECT 1";
                        command.Connection = conn;
                        command.ExecuteScalar();
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets a list of instances on the same network as the computer that the application is running.
        /// This method takes a long time to run.
        /// </summary>
        /// <returns></returns>
        public static List<SQLServerInstance> GetInstances()
        {
            var instance = SqlDataSourceEnumerator.Instance;

            var table = instance.GetDataSources();

            var instanceList = table.AsEnumerable().Select(x => new SQLServerInstance
            {
                InstanceName = x.Field<string>("InstanceName"),
                IsClustered = x.Field<string>("IsClustered"),
                ServerName = x.Field<string>("ServerName"),
                Version = x.Field<string>("Version")
            }).ToList();

            return instanceList;
        }


        /// <summary>
        /// Returns a sql schema object for the database specified in the connection string.
        /// </summary>
        /// <returns></returns>
        public static SQLSchema GetSqlSchema()
        {
            var schema = new SQLSchema();
            using (var goNecction = new SqlConnection(ConnectionStringService.CurrentConnectionString))
            {
                goNecction.Open();

                var tables = goNecction.GetSchema("Tables");
                var columns = goNecction.GetSchema("Columns");
                var dbName = goNecction.Database;

                schema = new SQLSchema
                {
                    DatabaseName = dbName,
                    Tables = ConvertTableDataTableToList(tables),
                    Columns = ConvertColumnsDataTableToList(columns)
                };

                goNecction.Close();
            }

            return schema;
        }

        private static List<SQLTable> ConvertTableDataTableToList(DataTable tablesDataTable)
        {
            var tableList = new List<SQLTable>();

            foreach (var table in tablesDataTable.AsEnumerable().Select(row => new SQLTable
            {
                TableName = Convert.ToString(row["TABLE_NAME"]),
                TableSchema = Convert.ToString(row["TABLE_SCHEMA"]),
                TableCatalog = Convert.ToString(row["TABLE_CATALOG"]),
                TableType = Convert.ToString(row["TABLE_TYPE"])
            }))
                tableList.Add(table);

            return tableList;
        }

        private static List<SQLColumn> ConvertColumnsDataTableToList(DataTable columnsDataTable)
        {
            var columnList = new List<SQLColumn>();

            foreach (var column in columnsDataTable.AsEnumerable().Select(row => new SQLColumn
            {
                TableName = Convert.ToString(row["TABLE_NAME"]),
                TableSchema = Convert.ToString(row["TABLE_SCHEMA"]),
                TableCatalog = Convert.ToString(row["TABLE_CATALOG"]),
                ColumnDefault = Convert.ToString(row["COLUMN_DEFAULT"]),
                ColumnName = Convert.ToString(row["COLUMN_NAME"]),
                DataType = Convert.ToString(row["DATA_TYPE"]),
                IsNullable = Convert.ToString(row["IS_NULLABLE"]),
                OrdinalPosition = Convert.ToString(row["ORDINAL_POSITION"])
            }))
                columnList.Add(column);

            return columnList;
        }
    }
}