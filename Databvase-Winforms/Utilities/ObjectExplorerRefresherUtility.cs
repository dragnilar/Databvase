using System.Collections.Generic;
using System.Linq;
using Databvase_Winforms.Extensions;
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

        public void RefreshNode(ObjectExplorerNode selectedNode)
        {
            if (selectedNode.Type == GlobalStrings.ObjectExplorerTypes.Column ||
                selectedNode.Type == GlobalStrings.ObjectExplorerTypes.Function ||
                selectedNode.Type == GlobalStrings.ObjectExplorerTypes.StoredProcedure ||
                selectedNode.Type == GlobalStrings.ObjectExplorerTypes.Nothing)
            {
                ReloadSelectedNode(selectedNode);
            }
            else
            {
                RemoveAllChildrenNodesOfNode(selectedNode);
            }
        }

        private void ReloadSelectedNode(ObjectExplorerNode selectedNode)
        {
            var nodeToReplace = _objectExplorerDataSource.DataSource.FirstOrDefault(x => x.Id == selectedNode.Id);
            var indexOfNodeToReplace = _objectExplorerDataSource.DataSource.IndexOf(nodeToReplace);

            if (indexOfNodeToReplace != -1)
            {
                switch (selectedNode.Type)
                {
                    case GlobalStrings.ObjectExplorerTypes.Column:
                        RefreshColumn(selectedNode, indexOfNodeToReplace);
                        break;
                    case GlobalStrings.ObjectExplorerTypes.Function:
                        RefreshFunction(selectedNode, indexOfNodeToReplace);
                        break;
                    case GlobalStrings.ObjectExplorerTypes.StoredProcedure:
                        RefreshStoredProcedure(selectedNode, indexOfNodeToReplace);
                        break;
                    default:
                        break;
                }
            }


        }
        #region Refresh Individual Nodes
        private void RefreshColumn(ObjectExplorerNode selectedNode, int indexOfNodeToReplace)
        {
            if (selectedNode.Data is Column column)
            {
                column.Refresh();
                _objectExplorerDataSource.DataSource[indexOfNodeToReplace] = new ObjectExplorerNode(
                    selectedNode.Id, selectedNode.ParentId,
                    column);
            }
        }

        private void RefreshFunction(ObjectExplorerNode selectedNode, int indexOfNodeToReplace)
        {
            if (selectedNode.Data is UserDefinedFunction function)
            {
                function.Refresh();
                _objectExplorerDataSource.DataSource[indexOfNodeToReplace] = new ObjectExplorerNode(
                    selectedNode.Id, selectedNode.ParentId,
                    function);
            }

        }

        private void RefreshStoredProcedure(ObjectExplorerNode selectedNode, int indexOfNodeToReplace)
        {
            if (selectedNode.Data is StoredProcedure storedProcedure)
            {
                storedProcedure.Refresh();
                _objectExplorerDataSource.DataSource[indexOfNodeToReplace] = new ObjectExplorerNode(
                    selectedNode.Id, selectedNode.ParentId,
                    storedProcedure);
            }

        }
        #endregion


        private void RemoveAllChildrenNodesOfNode(ObjectExplorerNode selectedNode)
        {
            switch (selectedNode.Type)
            {
                case GlobalStrings.ObjectExplorerTypes.Instance:
                    RefreshServer(selectedNode.Data as Server);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Database:
                    RefreshDatabase(selectedNode.Data as Database);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Folder:
                    RefreshFolderNode(selectedNode);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Table:
                    RefreshTable(selectedNode.Data as Table);
                    break;
            }
        }

        private void RefreshDatabase(Database database)
        {
            database.RemoveNodesForDatabase(_objectExplorerDataSource);
            database?.Refresh();
        }

        private void RefreshTable(Table table)
        {
            table.RemoveNodesForTable(_objectExplorerDataSource);
            table?.Refresh();
        }

        private void RefreshFolderNode(ObjectExplorerNode selectedFolderNode)
        {
            switch (selectedFolderNode.DisplayName)
            {
                case GlobalStrings.FolderTypes.StoreProcedureFolder:
                    RefreshAllStoredProcedures(selectedFolderNode);
                    break;
                case GlobalStrings.FolderTypes.SystemStoredProcedureFolder:
                    RefreshSystemStoredProcedures(selectedFolderNode);
                    break;
                case GlobalStrings.FolderTypes.FunctionsFolder:
                    //TODO - Add refresh functions
                    break;
                case GlobalStrings.FolderTypes.SystemDatabaseFolder:
                    //TODO - Add refresh system databases
                    break;
                case GlobalStrings.FolderTypes.TableFolder:
                    //TODO - Add refresh tables
                    break;
                case GlobalStrings.FolderTypes.ViewFolder:
                    RefreshViewsForDatabase(selectedFolderNode);
                    break;
            }
        }

        private void RefreshAllStoredProcedures(ObjectExplorerNode selectedFolderNode)
        {
            var database = selectedFolderNode.GetDatabaseFromNode();
            database.RemoveAllStoredProceduresNodesForDatabase(_objectExplorerDataSource);
            database.StoredProcedures.Refresh(true);
        }

        private void RefreshSystemStoredProcedures(ObjectExplorerNode selectedFolderNode)
        {
            var database = selectedFolderNode.GetDatabaseFromNode();
            var nodesToRemove = _objectExplorerDataSource.DataSource.Where(r =>
                r.Type == GlobalStrings.ObjectExplorerTypes.StoredProcedure
                && r.GetDatabaseFromNode().Name == database.Name && r.ParentId == selectedFolderNode.Id).ToList();
            _objectExplorerDataSource.RemoveListOfNodes(nodesToRemove);
            database.StoredProcedures.Refresh(true);
        }

        private void RefreshViewsForDatabase(ObjectExplorerNode selectedFolderNode)
        {
            var database = selectedFolderNode.GetDatabaseFromNode();
            var nodesToRemove = _objectExplorerDataSource.DataSource.Where(r =>
                r.Type == GlobalStrings.ObjectExplorerTypes.View &&
                r.GetDatabaseFromNode().Name == database.Name);
            _objectExplorerDataSource.RemoveListOfNodes(nodesToRemove);
            database.Views.Refresh(true);

        }

        private void RefreshServer(Server server)
        {
            RemoveAllDatabasesForServerInstance(server);
            RemoveAllFoldersForServerInstance(server);
            server.Refresh();
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
            _objectExplorerDataSource.RemoveListOfNodes(foldersToRemove);
        }

        private void RemoveDatabaseForServer(Database database)
        {
            database.RemoveNodesForDatabase(_objectExplorerDataSource);
            _objectExplorerDataSource.DataSource.Remove(r =>
                r.Type == GlobalStrings.ObjectExplorerTypes.Database && r.GetDatabaseFromNode().Name == database.Name);
        }
    }
}