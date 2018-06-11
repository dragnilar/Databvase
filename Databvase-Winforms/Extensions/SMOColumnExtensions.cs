using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Extensions
{

    public static class SMOColumnExtensions
    {

        public static string GetDataTypeAndSizeForColumn(this Column column)
        {
            var columnDataTypeBuilder = new StringBuilder();

            columnDataTypeBuilder.Append(GetKeyNotation(column));
            columnDataTypeBuilder.Append(column.DataType.SqlDataType);
            columnDataTypeBuilder.Append(column.GetColumnSize());
            columnDataTypeBuilder.Append(",");
            columnDataTypeBuilder.Append(column.Nullable ? " null" : " not null");

            return columnDataTypeBuilder.ToString();
        }

        /// <summary>
        /// Returns a string indicating the columns size/length (I.E. Numeric Precision/Scale or Maximum Length). Returns empty string if
        /// the column is not applicable.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string GetColumnSize(this Column column)
        {

            if (column.DataType.IsNumericType)
            {
                return GetColumnSizeForNumericType(column);
            }

            if (column.DataType.IsStringType || column.DataType.IsBinary())
            {
                return GetColumnSizeForStringOrBinaryType(column);
            }

            if (column.DataType.IsSysName())
            {
                return GetColumnSizeForSysNameType(column);
            }

            return column.DataType.IsDateTimeType() ? GetColumnSizeForDateType(column) : string.Empty;

            //TODO - We will assume the data type doesn't have a "size" and return nothing. This case can be expanded if we find other types have sizes...
        }



        private static string GetColumnSizeForStringOrBinaryType(Column column)
        {
            var columnSizeBuilder = new StringBuilder();
            columnSizeBuilder.Append("(");
            if (column.DataType.MaximumLength < 0)
            {
                columnSizeBuilder.Append("max");
            }
            else
            {
                columnSizeBuilder.Append(column.DataType.MaximumLength);
            }

            columnSizeBuilder.Append(")");
            return columnSizeBuilder.ToString();
        }

        private static string GetColumnSizeForNumericType(Column column)
        {
            var columnSizeBuilder = new StringBuilder();

            switch (column.DataType.SqlDataType)
            {
                case SqlDataType.Decimal:
                case SqlDataType.Float:
                    columnSizeBuilder.Append("(");
                    columnSizeBuilder.Append(column.DataType.NumericPrecision);
                    columnSizeBuilder.Append(",");
                    columnSizeBuilder.Append(column.DataType.NumericScale);
                    columnSizeBuilder.Append(")");
                    break;
            }

            return columnSizeBuilder.ToString();
        }

        private static string GetColumnSizeForDateType(Column column)
        {
            var columnSizeBuilder = new StringBuilder();

            switch (column.DataType.SqlDataType)
            {
                case SqlDataType.Time:
                case SqlDataType.DateTime2:
                case SqlDataType.DateTimeOffset:
                    columnSizeBuilder.Append("(");
                    columnSizeBuilder.Append(column.DataType.NumericScale);
                    columnSizeBuilder.Append(")");
                    break;
            }

            return columnSizeBuilder.ToString();
        }

        private static string GetColumnSizeForSysNameType(Column column)
        {
            var columnSizeBuilder = new StringBuilder();
            columnSizeBuilder.Append("(nvarchar(128))");
            return columnSizeBuilder.ToString();
        }

        /// <summary>
        /// Returns PK if the column is a primary key, FK if the column is a Foreign Key and empty string if the column is neither.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private static string GetKeyNotation(Column column)
        {
            if (column.InPrimaryKey)
            {
                return "PK ";
            }

            return column.IsForeignKey ? "FK " : string.Empty;
        }
    }

}
