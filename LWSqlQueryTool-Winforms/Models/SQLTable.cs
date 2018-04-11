namespace Databvase_Winforms.Models
{
    /// <summary>
    ///     A class representing a SQL Sever database's schema definition for a table.
    ///     Schema information can be found here:
    ///     https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-schema-collections
    /// </summary>
    public class SQLTable
    {
        public string TableName { get; set; }
        public string TableSchema { get; set; }
        public string TableCatalog { get; set; }
        public string TableType { get; set; }
        public string TableFullName => this.TableSchema != "dbo" ? $"{this.TableSchema}.{this.TableName}" : this.TableName;
    }
}