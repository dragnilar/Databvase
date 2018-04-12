using System.Collections;
using DevExpress.XtraTreeList;

namespace Databvase_Winforms.Models
{
    /// <summary>
    ///     A class that is used for populating data in the object explorer
    /// </summary>
    public class ObjectExplorerTreeListObject 
    {
        
        public string Name { get; set; }
        public string Type { get; set; }
        public string ParentName { get; set; }
        public string FullName { get; set; }
        public override string ToString()
        {
            return Type;
        }
    }
}