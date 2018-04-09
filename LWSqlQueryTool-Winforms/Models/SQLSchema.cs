using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Models
{
    /// <summary>
    /// An object that contains lists of schema data for a SQL Server Database
    /// </summary>
    public class SQLSchema
    {
        public string DatabaseName { get; set; }
        public List<SQLColumn> Columns { get; set; }
        public List<SQLTable> Tables { get; set; }
    }
}
