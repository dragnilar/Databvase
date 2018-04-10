using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Models;

namespace Databvase_Winforms.DAL
{
    internal static class SQLServerInterfaceUtilities
    {
        internal static List<SQLTable> ConvertTableDataTableToList(DataTable tablesDataTable)
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

        internal static List<SQLColumn> ConvertColumnsDataTableToList(DataTable columnsDataTable)
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
