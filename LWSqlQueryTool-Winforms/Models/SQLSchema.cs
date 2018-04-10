using System.Collections.Generic;
using LWSqlQueryTool_Winforms.Models;

namespace Databvase_Winforms.Models
{
    /// <summary>
    ///     An object that contains lists of schema data for a SQL Server Database
    /// </summary>
    public class SQLSchema
    {
        public SQLSchema()
        {
            InstanceName = string.Empty;
            Databases = new List<SQLDatabase>();
        }

        public string InstanceName { get; set; }
        public List<SQLDatabase> Databases { get; set; }
    }
}