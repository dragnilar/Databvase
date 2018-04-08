using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LWSqlQueryTool_Winforms.Models;
using LWSqlQueryTool_Winforms.Services;

namespace LWSqlQueryTool_Winforms.DAL
{
    public static class SQLServerInterface
    {
        public static QueryResult SendQueryStringAndGetResult(string sqlQuery)
        {
            var result = new QueryResult();
            try
            {
                var goNecction =
                    new SqlConnection(ConnectionStringService.CurrentConnectionString);

                var cmd = new SqlCommand();
                SqlDataReader reader;
                cmd.CommandText = sqlQuery;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = goNecction;

                goNecction.Open();
                reader = cmd.ExecuteReader();

                if (reader.VisibleFieldCount > 0)
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    result.ResultsTable = dataTable;
                    var stats = goNecction.RetrieveStatistics();
                    result.ResultsMessage = "Row(s) Affected " + stats["SelectRows"];

                }
                else
                {
                    result.ResultsMessage = "Command(s) Completed Successfully";
                }

                result.HasErrors = false;
                reader.Dispose();
                goNecction.Close();
            }
            catch (Exception ex)
            {
                result.HasErrors = true;
                result.ResultsMessage = ex.Message;
            }

            return result; 
        }

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
            catch (Exception ex)
            {

                return false;
            }

            return true;
        }

        public static List<SQLServerInstance> GetInstances()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;

            var table = instance.GetDataSources();

            var instanceList = table.AsEnumerable().Select(x => new SQLServerInstance()
            {
                InstanceName = x.Field<string>("InstanceName"),
                IsClustered = x.Field<string>("IsClustered"),
                ServerName = x.Field<string>("ServerName"),
                Version = x.Field<string>("Version")
            }).ToList();

            return instanceList;
        }

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

            foreach (var table in (tablesDataTable.AsEnumerable()).Select(row => new SQLTable
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

            foreach (var column in (columnsDataTable.AsEnumerable()).Select(row => new SQLColumn
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
