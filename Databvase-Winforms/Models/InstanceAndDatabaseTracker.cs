using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Models
{
    public class InstanceAndDatabaseTracker
    {
        public string InstanceName { get; set; }
        public Database DatabaseObject { get; set; }
    }

}
