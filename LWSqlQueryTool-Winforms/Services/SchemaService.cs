using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Charts.Native;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using LWSqlQueryTool_Winforms.Models;

namespace LWSqlQueryTool_Winforms.Services
{
    /// <summary>
    /// A class that retreives, converts and returns schema information from the current SQL Server database specified in the
    /// current connection string. 
    /// </summary>
    public static class SchemaService
    {
        /// <summary>
        /// Returns a SQL schema object. Uses the database speciified in the connection string manager's current connection string.
        /// </summary>
        /// <returns></returns>
        public static SQLSchema GetSchema()
        {
            SQLSchema schema;
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
