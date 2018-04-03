namespace LWSqlQueryTool_Winforms.Models
{
    public class SQLTable
    {
        public string TableName { get; set; }
        public string TableSchema { get; set; }
        public string FullName => TableSchema + "." + TableName;
    }
}
