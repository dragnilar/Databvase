using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Models.Data_Providers
{
    public class ServerExplorerNode
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public bool IsFile { get; set; }


    }
}
