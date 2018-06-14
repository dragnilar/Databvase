using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Databvase_Winforms.Factories;
using Databvase_Winforms.Globals;
using Databvase_Winforms.Utilities;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Models.Data_Providers
{
    public class ObjectExplorerDataSource
    {
        private int _nodeId;
        public BindingList<ObjectExplorerNode> DataSource { get; set; }
        private Dictionary<string, Action<ObjectExplorerNode>> _folderActionDictionary = null;
        private readonly ObjectExplorerRefresherUtility _objectExplorerRefresher;

        private List<string> systemDatabaseNames => new List<string>
        {
            "master",
            "model",
            "msdb",
            "tempdb"
        };

        private Dictionary<string, Action<ObjectExplorerNode>> FolderActionDictionary
        {
            get
            {
                return _folderActionDictionary ?? (_folderActionDictionary =
                           new Dictionary<string, Action<ObjectExplorerNode>>()
                           {
                               {GlobalStrings.FolderTypes.StoreProcedureFolder, CreateStoredProcedureNodes},
                               {GlobalStrings.FolderTypes.FunctionsFolder, CreateFunctionNodes},
                               {GlobalStrings.FolderTypes.TableFolder, CreateTableNodes},
                               {GlobalStrings.FolderTypes.ViewFolder, CreateViewNodes},
                               {GlobalStrings.FolderTypes.SystemDatabaseFolder, CreateSystemDatabaseNodes },
                               {GlobalStrings.FolderTypes.SystemStoredProcedureFolder, CreateSystemStoredProcedureNodes }
                           });
            }
        }

        public ObjectExplorerDataSource()
        {
            DataSource = new BindingList<ObjectExplorerNode>();
            _objectExplorerRefresher = new ObjectExplorerRefresherUtility(this);
        }

        public void GenerateInstances()
        {

            foreach (var instance in App.Connection.CurrentConnections.Select(x => x.Instance).ToList())
            {
                if (InstanceAlreadyInDataSource(instance)) continue;
                var serverInstance = App.Connection.GetServerAtInstanceName(instance);
                DataSource.Add(ObjectExplorerNodeFactory.CreateServerNode(GetNewNodeId(), serverInstance));
                
            }

        }

        private bool InstanceAlreadyInDataSource(string instance)
        {
            return DataSource.Any(x => x.InstanceName == instance);
        }


        public void GetNodes(ObjectExplorerNode selectedNode)
        {
            switch (selectedNode.Type)
            {
                case GlobalStrings.ObjectExplorerTypes.Instance:
                    CreateUserDatabaseNodes(selectedNode);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Database:
                    CreateFolderNodesForDatabase(selectedNode);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Folder:
                    CreateFolderChildrenNodes(selectedNode);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Table:
                    CreateColumnNodes(selectedNode);
                    break;
            }
        }


        private void CreateUserDatabaseNodes(ObjectExplorerNode model)
        {

            if (!(model.Data is Server server)) return;
            if (server.Databases.Count <= 0)
            {
                CreateEmptyNode(model);
                return;
            }

            DataSource.Add(ObjectExplorerNodeFactory.CreateFolderNode(GetNewNodeId(), GlobalStrings.FolderTypes.SystemDatabaseFolder, model));

            foreach (Database db in server.Databases) //TODO - This is probably not the most elegant way to handle this...
            {
                if (!systemDatabaseNames.Contains(db.Name))
                {
                    DataSource.Add(ObjectExplorerNodeFactory.CreateDatabaseNode(GetNewNodeId(), model.Id, db));
                }
            }
        }

        private void CreateSystemDatabaseNodes(ObjectExplorerNode model)
        {
            if (!(model.Data is Server server)) return;
            foreach (Database db in server.Databases)
            {
                if (systemDatabaseNames.Contains(db.Name)) //TODO - This is probably not the most elegant way to handle this...
                {
                    DataSource.Add(ObjectExplorerNodeFactory.CreateDatabaseNode(GetNewNodeId(), model.Id, db));
                }
            }
        }

        private void CreateFolderNodesForDatabase(ObjectExplorerNode model)
        {
            if (!(model.Data is Database)) return;
            DataSource.Add(ObjectExplorerNodeFactory.CreateFolderNode(GetNewNodeId(), GlobalStrings.FolderTypes.TableFolder,
                model));
            DataSource.Add(ObjectExplorerNodeFactory.CreateFolderNode(GetNewNodeId(), GlobalStrings.FolderTypes.ViewFolder,
                model));
            DataSource.Add(ObjectExplorerNodeFactory.CreateFolderNode(GetNewNodeId(),
                GlobalStrings.FolderTypes.StoreProcedureFolder, model));
            DataSource.Add(ObjectExplorerNodeFactory.CreateFolderNode(GetNewNodeId(),
                GlobalStrings.FolderTypes.FunctionsFolder, model));
        }


        private void CreateFolderChildrenNodes(ObjectExplorerNode model)
        {
            var createFolderNodeAction = FolderActionDictionary[model.DisplayName];
            createFolderNodeAction.Invoke(model);
        }

        private void CreateTableNodes(ObjectExplorerNode model)
        {

            if (!(model.Data is Database database)) return;
            if (database.Tables.Count <= 0)
            {
                CreateEmptyNode(model);
                return;
            }

            foreach (Table table in database.Tables)
                DataSource.Add(ObjectExplorerNodeFactory.CreateTableNode(GetNewNodeId(), model.Id, table));
            
        }



        private void CreateViewNodes(ObjectExplorerNode model)
        {
            if (!(model.Data is Database database)) return;
            if ((database.Views.Count <= 0))
            {
                CreateEmptyNode(model);
                return;
            }

            foreach (View view in database.Views)
                DataSource.Add(ObjectExplorerNodeFactory.CreateViewNode(GetNewNodeId(), model.Id, view));
        }

        private void CreateStoredProcedureNodes(ObjectExplorerNode model)
        {
            if (!(model.Data is Database database)) return;
            if ((database.StoredProcedures.Count <= 0))
            {
                CreateEmptyNode(model);
                return;
            }

            DataSource.Add(ObjectExplorerNodeFactory.CreateFolderNode(GetNewNodeId(), GlobalStrings.FolderTypes.SystemStoredProcedureFolder, model));

            var nonSystemStoredProcedures = database.StoredProcedures.Cast<StoredProcedure>()
                .Where(r => r.IsSystemObject == false).ToList();

            foreach (var storedProcedure in nonSystemStoredProcedures)
            {
                DataSource.Add(ObjectExplorerNodeFactory.CreateStoredProcedureNode(GetNewNodeId(), model.Id, storedProcedure));
            }
        }

        private void CreateSystemStoredProcedureNodes(ObjectExplorerNode model)
        {
            if (!(model.Data is Database database)) return;
            if ((database.StoredProcedures.Count <= 0))
            {
                CreateEmptyNode(model);
                return;
            }

            foreach (StoredProcedure storedProcedure in database.StoredProcedures.Cast<StoredProcedure>().Where(r => r.IsSystemObject))
            {
                DataSource.Add(ObjectExplorerNodeFactory.CreateStoredProcedureNode(GetNewNodeId(), model.Id, storedProcedure));
            }
        }

        private void CreateFunctionNodes(ObjectExplorerNode model)
        {

            if (!(model.Data is Database database)) return;
            if ((database.UserDefinedFunctions.Count <= 0))
            {
                CreateEmptyNode(model);
                return;
            }

            foreach (UserDefinedFunction function in database.UserDefinedFunctions)
                DataSource.Add(ObjectExplorerNodeFactory.CreateFunctionNode(GetNewNodeId(), model.Id, function));

        }

        private void CreateColumnNodes(ObjectExplorerNode model)
        {

            if (!(model.Data is Table table)) return;
            if (table.Columns.Count <= 0)
            {
                CreateEmptyNode(model);
                return;
            }

            foreach (Column column in table.Columns)
                DataSource.Add(ObjectExplorerNodeFactory.CreateColumnNode(GetNewNodeId(), model.Id, column));


        }

        public void CreateEmptyNode(ObjectExplorerNode model)
        {
            DataSource.Add(ObjectExplorerNodeFactory.CreateNothingNode(GetNewNodeId(), model));
        }

        public void RefreshNode(ObjectExplorerNode selectedNode)
        {
            _objectExplorerRefresher.RefreshNode(selectedNode);
            
        }

        public void RemoveListOfNodes(IEnumerable<ObjectExplorerNode> nodesToRemove)
        {
            foreach (var removable in nodesToRemove.ToList())
            {
                DataSource.Remove(removable);
            }
        }


        private int GetNewNodeId()
        {
            _nodeId++;
            return _nodeId;
        }
    }

}