using Databvase_Winforms.Extensions;
using Databvase_Winforms.Globals;
using Databvase_Winforms.Models.Data_Providers;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Factories
{
    /// <summary>
    /// A factory that produces object explorer nodes
    /// </summary>
    public static class ObjectExplorerNodeFactory
    {
        /// <summary>
        /// Creates a new server/instance node for the object explorer
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="serverInstance"></param>
        /// <returns></returns>
        public static ObjectExplorerNode CreateServerNode(int instanceId, Server serverInstance)
        {
            return new ObjectExplorerNode
            {
                ParentId = 0,
                Id = instanceId,
                InstanceName = serverInstance.Name,
                Type = GlobalStrings.ObjectExplorerTypes.Instance,
                Data = serverInstance,
                DisplayName = serverInstance.Name,
                FullName = serverInstance.Name,
                ParentNodeName = string.Empty,
                ImageIndex = 0,
                Properties = serverInstance.Edition
        };
        }

        /// <summary>
        /// Creates a new database node for the object explorer
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="instanceId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static ObjectExplorerNode CreateDatabaseNode(int databaseId, int instanceId, Database db)
        {
            var instanceName = db.Parent.Name;
            return new ObjectExplorerNode
            {
                ParentId = instanceId,
                Id = databaseId,
                InstanceName = instanceName,
                Type = GlobalStrings.ObjectExplorerTypes.Database,
                Data = db,
                DisplayName = db.Name,
                FullName = db.Name,
                ParentNodeName = instanceName + " " + GlobalStrings.FolderTypes.SystemDatabaseFolder + " " + "folder",
                ImageIndex = 1,
                Properties = string.Empty
            };
        }

        /// <summary>
        /// Creates a new table node for the object explorer
        /// </summary>
        /// <param name="tableId"></param>
        /// <param name="databaseId"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static ObjectExplorerNode CreateTableNode(int tableId, int databaseId, Table table)
        {
            var instanceName = table.Parent.Parent.Name;
            return new ObjectExplorerNode
            {
                ParentId = databaseId,
                Id = tableId,
                InstanceName = instanceName,
                Type = GlobalStrings.ObjectExplorerTypes.Table,
                Data = table,
                DisplayName = GetTableFullName(table),
                FullName = table.Name,
                ParentNodeName = instanceName + " " + GlobalStrings.FolderTypes.TableFolder + " " + "folder",
                ImageIndex = 2,
                Properties = string.Empty,
            };
        }

        /// <summary>
        /// Creates a new column node for the object explorer
        /// </summary>
        /// <param name="columnId"></param>
        /// <param name="tableId"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static ObjectExplorerNode CreateColumnNode(int columnId, int tableId, Column column)
        {
            var columnProperties = column.GetDataTypeAndSizeForColumn();

            return new ObjectExplorerNode
            {

                ParentId = tableId,
                Id = columnId,
                InstanceName = ((Table) column.Parent).Parent.Parent.Name,
                Type = GlobalStrings.ObjectExplorerTypes.Column,
                Data = column,
                DisplayName = column.Name + " " + columnProperties,
                FullName = column.Name,
                ParentNodeName = GetTableFullName((Table) column.Parent),
                ImageIndex = 3,
                Properties = columnProperties,
            };
        }

        /// <summary>
        /// Creates a new folder node for the object explorer that can be used to house other child nodes (I.E. Functions, etc)
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="folderType"></param>
        /// <param name="parentModel"></param>
        /// <returns></returns>
        public static ObjectExplorerNode CreateFolderNode(int folderId, string folderType, ObjectExplorerNode parentModel)
        {
            return new ObjectExplorerNode
            {
                ParentId = parentModel.Id,
                Id = folderId,
                InstanceName = parentModel.InstanceName,
                Type = GlobalStrings.ObjectExplorerTypes.Folder,
                Data = parentModel.Data,
                DisplayName = folderType,
                FullName = GetFolderFullName(folderType, parentModel),
                ParentNodeName = parentModel.FullName,
                ImageIndex = 4,
                Properties = null,
            };
        }

        /// <summary>
        /// Creates a new view node for the object explorer
        /// </summary>
        /// <param name="viewId"></param>
        /// <param name="folderId"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public static ObjectExplorerNode CreateViewNode(int viewId, int folderId, View view)
        {
            var instanceName = view.Parent.Parent.Name;
            return new ObjectExplorerNode
            {
                ParentId = folderId,
                Id = viewId,
                InstanceName = instanceName,
                Type = GlobalStrings.ObjectExplorerTypes.View,
                Data = view,
                DisplayName = $"{view.Schema}.{view.Name}",
                FullName = $"{view.Schema}.{view.Name}",
                ParentNodeName = instanceName + " " + GlobalStrings.FolderTypes.ViewFolder + " " + "folder",
                ImageIndex = 5,
                Properties = string.Empty,
            };
        }

        /// <summary>
        /// Creates a new function node for the object explorer
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="folderId"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static ObjectExplorerNode CreateFunctionNode(int functionId, int folderId, UserDefinedFunction function)
        {
            var instanceName = function.Parent.Parent.Name;

            return new ObjectExplorerNode
            {
                ParentId = folderId,
                Id = functionId,
                InstanceName = function.Parent.Parent.Name,
                Type = GlobalStrings.ObjectExplorerTypes.Function,
                Data = function,
                DisplayName = $"{function.Schema}.{function.Name}",
                FullName = $"{function.Schema}.{function.Name}",
                ParentNodeName = instanceName + " " + GlobalStrings.FolderTypes.FunctionsFolder + " " + "folder",
                ImageIndex = 6,
                Properties = string.Empty,
            };
        }

        /// <summary>
        /// Creates a new stored procedure node for the object explorer.
        /// </summary>
        /// <param name="storedProcedureId"></param>
        /// <param name="folderId"></param>
        /// <param name="storedProcedure"></param>
        /// <returns></returns>
        public static ObjectExplorerNode CreateStoredProcedureNode(int storedProcedureId, int folderId, StoredProcedure storedProcedure)
        {
            var instanceName = storedProcedure.Parent.Parent.Name;
            return new ObjectExplorerNode
            {
                ParentId = folderId,
                Id = storedProcedureId,
                InstanceName = instanceName,
                Type = GlobalStrings.ObjectExplorerTypes.StoredProcedure,
                Data = storedProcedure,
                DisplayName = $"{storedProcedure.Schema}.{storedProcedure.Name}",
                FullName = $"{storedProcedure.Schema}.{storedProcedure.Name}",
                ParentNodeName = instanceName + " " + GlobalStrings.FolderTypes.StoreProcedureFolder + " " + "folder",
                ImageIndex = 7,
                Properties = string.Empty,
            };
        }

        /// <summary>
        /// Creates a "nothing node" that is used to represents a node where nothing is found in the object explorer. This is
        /// typically used in situations where you have errors occur retrieving nodes and need to indicate to the user that
        /// nothing was retrieved when expanding a node. 
        /// </summary>
        /// <param name="emptyNodeId">The internal id of the node itself</param>
        /// <param name="parentNode">The parent node of the node that is returned</param>
        /// <returns></returns>
        public static ObjectExplorerNode CreateNothingNode(int emptyNodeId, ObjectExplorerNode parentNode)
        {
            return new ObjectExplorerNode
            {
                ParentId = parentNode.Id,
                Id = emptyNodeId,
                InstanceName = parentNode.InstanceName,
                Type = GlobalStrings.ObjectExplorerTypes.Nothing,
                Data = null,
                DisplayName = "Nothing available",
                FullName = parentNode.FullName + " " + "Empty Child Node",
                ParentNodeName = parentNode.FullName,
                ImageIndex = 8,
                Properties = string.Empty
            };
        }


        /// <summary>
        /// Returns the full name of a table object.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private static string GetTableFullName(Table table)
        {
            return table.Schema != "dbo" ? $"{table.Schema}.{table.Name}" : table.Name;
        }
        
        /// <summary>
        /// Returns the full name of a child folder that belongs to a particular node.
        /// </summary>
        /// <param name="folderType"></param>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private static string GetFolderFullName(string folderType, ObjectExplorerNode parentNode)
        {
            return parentNode.InstanceName + " " + folderType + " " + "folder";
        }
    }
}
