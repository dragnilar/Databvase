using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Models
{
    /// <summary>
    /// A class that is used for populating data in the object explorer
    /// </summary>
    public class ObjectExplorerTreeListObject
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public TypeOfNode NodeType { get; set; }
        public int ImageIndex => (int) NodeType;

        public enum TypeOfNode
        {
            Instance,
            Database,
            Table,
            Column
        }

    }
}
