using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWSqlQueryTool_Winforms.Models
{
    /// <summary>
    /// A class representing a SQL Server database's schema definition for a column.
    /// Schema information can be found here: https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-schema-collections
    /// </summary>
    public class SQLColumn
    {
        
        public string TableCatalog { get; set; }
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string OrdinalPosition { get; set; }
        public string ColumnDefault { get; set; }
        public string IsNullable { get; set; }
        public string DataType { get; set; }
        //TODO - Add other schema fields here if necessary



    }
}
