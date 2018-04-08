using System.Data;

namespace LWSqlQueryTool_Winforms.Models
{
    public class QueryResult
    {
        public DataSet ResultsSet { get; set; }
        public string ResultsMessage { get; set; }
        public bool HasErrors { get; set; }
    }
}
