using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Models;

namespace LWSqlQueryTool_Winforms.Models
{
    public class SQLDatabase
    {
        public string DataBaseName { get; set; }
        public List<SQLColumn> Columns { get; set; }
        public List<SQLTable> Tables { get; set; }
    }
}
