using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Models
{
    /// <summary>
    /// A class that represents a SQL Server instance returned by the SqlDataSourceEnumerator.GetDataSources() method.
    /// Documentation can be found here: https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/enumerating-instances-of-sql-server
    /// </summary>
    public class SQLServerInstance
    {
        public string ServerName { get; set; }
        public string InstanceName { get; set; }
        public string IsClustered { get; set; }
        public string Version { get; set; }

        public override string ToString()
        {
            return ServerName + @"\" + InstanceName;
        }
    }
}
