using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LWSqlQueryTool_Winforms.Models;

namespace Databvase_Winforms.Models
{
    /// <summary>
    /// An object that contains lists of schema data for a SQL Server Database
    /// </summary>
    public class SQLSchema
    {
        
        public string InstanceName { get; set; }
        public List<SQLDatabase> Databases { get; set; }

        public SQLSchema()
        {
            InstanceName = String.Empty;
            Databases = new List<SQLDatabase>();
        }

    }
}
