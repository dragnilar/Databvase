using System.Collections.Generic;
using System.Linq;
using Databvase_Winforms.Globals;
using Databvase_Winforms.Models.Data_Providers;
using DevExpress.Utils.Extensions;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Utilities
{
    public class ObjectExplorerRefresherUtility
    {
        private readonly ObjectExplorerDataSource _objectExplorerDataSource;

        public ObjectExplorerRefresherUtility(ObjectExplorerDataSource objectExplorerDataSource)
        {
            _objectExplorerDataSource = objectExplorerDataSource;
        }

        public void RemoveAllChildrenNodesOfNode(ObjectExplorerNode selectedNode)
        {
            switch (selectedNode.Type)
            {
                case GlobalStrings.ObjectExplorerTypes.Instance:
                    RemoveAllNodesForServerInstance(selectedNode.Data as Server);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Database:
                    RemoveNodesForDatabase(selectedNode.Data as Database);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Folder:
                    //CreateFolderChildrenNodes(selectedNode);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Table:
                    RemoveAllColumnsForTable(selectedNode.Data as Table);
                    break;
            }
        }

        private void RemoveAllNodesForServerInstance(Server server)
        {
            RemoveAllDatabasesForServerInstance(server);
            RemoveAllFoldersForServerInstance(server);
        }

        private void RemoveAllDatabasesForServerInstance(Server server)
        {
            foreach (Database database in server.Databases)
            {
                RemoveDatabaseForServer(database);
            }

        }

        private void RemoveAllFoldersForServerInstance(Server server)
        {
            var foldersToRemove = _objectExplorerDataSource.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.Folder &&
                                                                                  r.InstanceName == server.Name);
            RemoveListOfNodes(foldersToRemove);
        }

        private void RemoveDatabaseForServer(Database database)
        {
            RemoveNodesForDatabase(database);
            _objectExplorerDataSource.DataSource.Remove(r =>
                r.Type == GlobalStrings.ObjectExplorerTypes.Database && r.GetDatabaseFromNode().Name == database.Name);
        }

        private void RemoveNodesForDatabase(Database database)
        {
            RemoveAllColumnsForDatabase(database);
            RemoveAllTablesForDatabase(database);
            RemoveAllViewsForDatabase(database);
            RemoveAllFunctionsForDatabase(database);
            RemoveAllStoredProceduresForDatabase(database);
            RemoveAllFoldersForDatabase(database);
        }

        private void RemoveAllColumnsForDatabase(Database database)
        {
            var columnsToRemove = _objectExplorerDataSource.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.Column &&
                                                                                  r.GetDatabaseFromNode().Name == database.Name);
            RemoveListOfNodes(columnsToRemove);
        }

        private void RemoveAllTablesForDatabase(Database database)
        {
            var tablesToRemove = _objectExplorerDataSource.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.Table &&
                                                                                 r.GetDatabaseFromNode().Name == database.Name);
            RemoveListOfNodes(tablesToRemove);
        }

        private void RemoveAllViewsForDatabase(Database database)
        {
            var viewsToRemove = _objectExplorerDataSource.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.View &&
                                                                                r.GetDatabaseFromNode().Name == database.Name);
            RemoveListOfNodes(viewsToRemove);
        }

        private void RemoveAllFunctionsForDatabase(Database database)
        {
            var functionsToRemove = _objectExplorerDataSource.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.Function &&
                                                                                    r.GetDatabaseFromNode().Name == database.Name);
            RemoveListOfNodes(functionsToRemove);
        }

        private void RemoveAllStoredProceduresForDatabase(Database database)
        {
            var storedProceduresToRemove = _objectExplorerDataSource.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.StoredProcedure &&
                                                                                           r.GetDatabaseFromNode().Name == database.Name);
            RemoveListOfNodes(storedProceduresToRemove);
        }

        private void RemoveAllFoldersForDatabase(Database database)
        {
            var functionsToRemove = _objectExplorerDataSource.DataSource.Where(r => IsFolderForDatabase(r) &&
                                                                                    r.GetDatabaseFromNode().Name == database.Name);
            RemoveListOfNodes(functionsToRemove);
        }

        private bool IsFolderForDatabase(ObjectExplorerNode node)
        {
            if (node.Type != GlobalStrings.ObjectExplorerTypes.Folder) return false;
            return node.DisplayName == GlobalStrings.FolderTypes.FunctionsFolder ||
                   node.DisplayName == GlobalStrings.FolderTypes.StoreProcedureFolder ||
                   node.DisplayName == GlobalStrings.FolderTypes.TableFolder ||
                   node.DisplayName == GlobalStrings.FolderTypes.ViewFolder;
        }

        private void RemoveListOfNodes(IEnumerable<ObjectExplorerNode> nodesToRemove)
        {
            foreach (var removable in nodesToRemove.ToList())
            {
                _objectExplorerDataSource.DataSource.Remove(removable);
            }
        }

        private void RemoveAllColumnsForTable(Table table)
        {
            var columnsToRemove = _objectExplorerDataSource.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.Column &&
                                                                                  ((Table)r.GetColumnFromNode().Parent) == table).ToList();
            foreach (var removable in columnsToRemove)
            {
                _objectExplorerDataSource.DataSource.Remove(removable);
            }
        }
    }
}