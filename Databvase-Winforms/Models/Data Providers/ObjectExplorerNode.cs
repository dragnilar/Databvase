using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Databvase_Winforms.Annotations;
using Databvase_Winforms.Extensions;
using Databvase_Winforms.Globals;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Models.Data_Providers
{
    //TODO - Possibly replace all these constructors with a builder???
    public class ObjectExplorerNode : INotifyPropertyChanged
    {
       
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string DisplayName { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }
        public string ParentNodeName { get; set; }
        public object Data { get; set; }
        public string InstanceName { get; set; }
        public int ImageIndex { get; set; }
        public string Properties {get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public Database GetDatabaseFromNode()
        {
            //TODO - This switch probably needs to be condensed...
            switch (Type)
            {
                case GlobalStrings.ObjectExplorerTypes.Instance:
                    return null;
                case GlobalStrings.ObjectExplorerTypes.Database:
                    return (Database)Data;
                case GlobalStrings.ObjectExplorerTypes.Folder when Data is Database database:
                    return database;
                case GlobalStrings.ObjectExplorerTypes.Folder:
                    return null;
                case GlobalStrings.ObjectExplorerTypes.Table:
                    return ((Table)Data).Parent;
                case GlobalStrings.ObjectExplorerTypes.Column:
                    var column = Data as Column;
                    return ((Table)column?.Parent)?.Parent;
                case GlobalStrings.ObjectExplorerTypes.Function:
                    return ((UserDefinedFunction)Data).Parent;
                case GlobalStrings.ObjectExplorerTypes.StoredProcedure:
                    return ((StoredProcedure)Data).Parent;
                case GlobalStrings.ObjectExplorerTypes.View:
                    return ((View)Data).Parent;
            }
            return null;
        }

        public Server GetInstanceFromNode()
        {
            //TODO - This switch probably needs to be condensed...
            switch (Type)
            {
                case GlobalStrings.ObjectExplorerTypes.Instance:
                    return (Server)Data;
                case GlobalStrings.ObjectExplorerTypes.Database:
                    return ((Database)Data).Parent;
                case GlobalStrings.ObjectExplorerTypes.Folder when Data is Database database:
                    return database.Parent;
                case GlobalStrings.ObjectExplorerTypes.Folder:
                    return GetInstanceFromFolderNode(Data);
                case GlobalStrings.ObjectExplorerTypes.Table:
                    return ((Table)Data).Parent.Parent;
                case GlobalStrings.ObjectExplorerTypes.Column:
                    var column = Data as Column;
                    return ((Table)column?.Parent)?.Parent.Parent;
            }
            return null;
        }

        private Server GetInstanceFromFolderNode(object nodeData)
        {
            switch (nodeData)
            {
                case View view:
                    return view.Parent.Parent;
                case UserDefinedFunction function:
                    return function.Parent.Parent;
                case StoredProcedure storedProcedure:
                    return storedProcedure.Parent.Parent;
                case Table table:
                    return table.Parent.Parent;
                default:
                    return null;

            }
        }

        public Column GetColumnFromNode()
        {
            if (Type == GlobalStrings.ObjectExplorerTypes.Column)
            {
                return Data as Column;
                
            }

            return null;
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}