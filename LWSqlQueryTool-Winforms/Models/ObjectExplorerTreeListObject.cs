namespace Databvase_Winforms.Models
{
    /// <summary>
    ///     A class that is used for populating data in the object explorer
    /// </summary>
    public class ObjectExplorerTreeListObject
    {
        public enum TypeOfNode
        {
            Instance,
            Database,
            Table,
            Column
        }

        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public TypeOfNode NodeType { get; set; }
        public int ImageIndex => (int) NodeType;
    }
}