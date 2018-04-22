using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Databvase_Winforms.Annotations;
using Databvase_Winforms.Globals;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Models
{
    public class ObjectExplorerModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Creates a new object for a Server/Instance data type
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="serverInstance"></param>
        public ObjectExplorerModel(int instanceId, Server serverInstance)
        {
            ParentId = 0;
            Id = instanceId;
            InstanceName = serverInstance.Name;
            Type = GlobalStrings.ObjectExplorerTypes.Instance;
            Data = serverInstance;
            FullName = serverInstance.Name;
            ParentName = string.Empty;
            ImageIndex = 0;
            Properties = serverInstance.Edition;

        }


        /// <summary>
        ///   Creates a new object for a Database data type
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="instanceId"></param>
        /// <param name="db"></param>
        public ObjectExplorerModel(int databaseId, int instanceId, Database db)
        {
            ParentId = instanceId;
            Id = databaseId;
            InstanceName = db.Parent.Name;
            Type = GlobalStrings.ObjectExplorerTypes.Database;
            Data = db;
            FullName = db.Name;
            ParentName = db.Parent.Name;
            ImageIndex = 1;
            Properties = string.Empty;
        }

        /// <summary>
        ///     Creates a new object for a Table data type
        /// </summary>
        /// <param name="tableId"></param>
        /// <param name="databaseId"></param>
        /// <param name="table"></param>
        public ObjectExplorerModel(int tableId, int databaseId, Table table)
        {
            ParentId = databaseId;
            Id = tableId;
            InstanceName = table.Parent.Parent.Name;
            Type = GlobalStrings.ObjectExplorerTypes.Table;
            Data = table;
            FullName = GetTableFullName(table);
            ParentName = table.Parent.Name;
            ImageIndex = 2;
            Properties = string.Empty;
        }

        /// <summary>
        ///     Creates a new object for a Column data type
        /// </summary>
        /// <param name="columnId"></param>
        /// <param name="tableId"></param>
        /// <param name="column"></param>
        public ObjectExplorerModel(int columnId, int tableId, Column column)
        {
            ParentId = tableId;
            Id = columnId;
            InstanceName = ((Table) column.Parent).Parent.Parent.Name;
            Type = GlobalStrings.ObjectExplorerTypes.Column;
            Data = column;
            FullName = column.Name;
            ParentName = GetTableFullName((Table) column.Parent);
            ImageIndex = 3;
            Properties = BuildColumnProperties(column);
        }

        public int Id { get; set; }
        public int ParentId { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }
        public string ParentName { get; set; }
        public object Data { get; set; }
        public string InstanceName { get; set; }
        public int ImageIndex { get; set; }
        public string Properties {get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string GetTableFullName(Table table)
        {
            return table.Schema != "dbo" ? $"{table.Schema}.{table.Name}" : table.Name;
        }

        private string BuildColumnProperties(Column column)
        {
            var propertiesBuilder = new StringBuilder();

            if (column.InPrimaryKey)
            {
                propertiesBuilder.Append("PK ");
            }

            if (column.IsForeignKey)
            {
                propertiesBuilder.Append("FK ");
            }

            propertiesBuilder.Append(column.DataType); 
            propertiesBuilder.Append(","); 
            propertiesBuilder.Append(column.Nullable ? " null" : " not null");

            return propertiesBuilder.ToString();
        }
    }
}