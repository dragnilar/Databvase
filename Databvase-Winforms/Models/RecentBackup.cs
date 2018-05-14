using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Models
{
    public class RecentBackup
    {
        public string DatabaseName { get; set; }
        public DateTime BackupStartDate { get; set; }
        public DateTime BackupFinishTime { get; set; }
        public string PhysicalDeviceName { get; set; }
    }
}
