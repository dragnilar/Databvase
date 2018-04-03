using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWSqlQueryTool_Winforms.Models
{
    public class SQLColumn
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string TableName { get; set; }
        public string ColumnOrder { get; set; }
    }
}
