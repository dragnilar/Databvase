using System;
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


        /// <summary>
        /// Creates a new object for a Folder data type
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="folderType"></param>
        /// <param name="parentModel"></param>
        public ObjectExplorerModel(int folderId, string folderType, ObjectExplorerModel parentModel)
        {
            ParentId = parentModel.Id;
            Id = folderId;
            InstanceName = ((Database)parentModel.Data).Parent.Name;
            Type = GlobalStrings.ObjectExplorerTypes.Folder;
            Data = parentModel.Data;
            FullName = folderType;
            ParentName = parentModel.FullName;
            ImageIndex = 4;
            Properties = null;
        }

        /// <summary>
        /// Creates a new object for a View data type
        /// </summary>
        /// <param name="viewId"></param>
        /// <param name="folderId"></param>
        /// <param name="view"></param>
        public ObjectExplorerModel(int viewId, int folderId, View view)
        {
            ParentId = folderId;
            Id = viewId;
            InstanceName = view.Parent.Parent.Name;
            Type = GlobalStrings.ObjectExplorerTypes.View;
            Data = view;
            FullName = $"{view.Schema}.{view.Name}";
            ParentName = view.Parent.Name;
            ImageIndex = 5;
            Properties = string.Empty;
        }

        /// <summary>
        /// Creates a new object for a Stored Procedure data type
        /// </summary>
        /// <param name="storedProcedureId"></param>
        /// <param name="folderId"></param>
        /// <param name="storedProcedure"></param>
        public ObjectExplorerModel(int storedProcedureId, int folderId, StoredProcedure storedProcedure)
        {
            ParentId = folderId;
            Id = storedProcedureId;
            InstanceName = storedProcedure.Parent.Parent.Name;
            Type = GlobalStrings.ObjectExplorerTypes.View;
            Data = storedProcedure;
            FullName = $"{storedProcedure.Schema}.{storedProcedure.Name}";
            ParentName = storedProcedure.Parent.Name;
            ImageIndex = 5;
            Properties = string.Empty;
        }

        /// <summary>
        /// Creates a new object for a User Defined Function (Note: This is the same thing as a function in SQL)
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="folderId"></param>
        /// <param name="function"></param>
        public ObjectExplorerModel(int functionId, int folderId, UserDefinedFunction function)
        {
            ParentId = folderId;
            Id = functionId;
            InstanceName = function.Parent.Parent.Name;
            Type = GlobalStrings.ObjectExplorerTypes.View;
            Data = function;
            FullName = $"{function.Schema}.{function.Name}";
            ParentName = function.Parent.Name;
            ImageIndex = 5;
            Properties = string.Empty;
        }

        /// <summary>
        /// Creates a nothing/empty node to signify that nothing was found or is available (most likely due to login permissions)
        /// </summary>
        /// <param name="emptyNodeId"></param>
        /// <param name="parentModel"></param>
        public ObjectExplorerModel(int emptyNodeId, ObjectExplorerModel parentModel)
        {
            ParentId = parentModel.Id;
            Id = emptyNodeId;
            InstanceName = parentModel.InstanceName;
            Type = GlobalStrings.ObjectExplorerTypes.Nothing;
            Data = null;
            FullName = "Nothing available";
            ParentName = parentModel.FullName;
            ImageIndex = 0;
            Properties = string.Empty;
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