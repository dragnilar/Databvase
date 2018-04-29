using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Databvase_Winforms.Globals;
using DevExpress.Data.Helpers;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Models
{
    public class ObjectExplorerDataSourceModel
    {
        private int _nodeId;
        public BindingList<ObjectExplorerModel> ObjectExplorerDataSource { get; set; }
        private Dictionary<string, Action<ObjectExplorerModel>> _folderActionDictionary = null;

        private List<string> systemDatabaseNames => new List<string>
        {
            "master",
            "model",
            "msdb",
            "tempdb"
        };

        private Dictionary<string, Action<ObjectExplorerModel>> FolderActionDictionary
        {
            get
            {
                return _folderActionDictionary ?? (_folderActionDictionary =
                           new Dictionary<string, Action<ObjectExplorerModel>>()
                           {
                               {GlobalStrings.FolderTypes.StoreProcedureFolder, CreateStoredProcedureNodes},
                               {GlobalStrings.FolderTypes.FunctionsFolder, CreateFunctionNodes},
                               {GlobalStrings.FolderTypes.TableFolder, CreateTableNodes},
                               {GlobalStrings.FolderTypes.ViewFolder, CreateViewNodes},
                               {GlobalStrings.FolderTypes.SystemDatabaseFolder, CreateSystemDatabaseNodes }
                           });
            }
        }

        public ObjectExplorerDataSourceModel()
        {
            ObjectExplorerDataSource = new BindingList<ObjectExplorerModel>();
        }

        public void GenerateInstances()
        {

            foreach (var instance in App.Connection.CurrentConnections.Select(x => x.Instance).ToList())
            {
                if (InstanceAlreadyInDataSource(instance)) continue;
                var serverInstance = App.Connection.GetServerAtSpecificInstance(instance);
                ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), serverInstance));
            }

        }

        private bool InstanceAlreadyInDataSource(string instance)
        {
            return ObjectExplorerDataSource.Any(x => x.InstanceName == instance);
        }


        public void CreateUserDatabaseNodes(ObjectExplorerModel model)
        {

            if (!(model.Data is Server server)) return;
            if (server.Databases.Count <= 0)
            {
                CreateEmptyNode(model);
                return;
            }

            ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), GlobalStrings.FolderTypes.SystemDatabaseFolder, model));

            foreach (Database db in server.Databases) //TODO - This is probably not the most elegant way to handle this...
            {
                if (!systemDatabaseNames.Contains(db.Name))
                {
                    ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), model.Id, db));
                }
            }
        }

        private void CreateSystemDatabaseNodes(ObjectExplorerModel model)
        {
            if (!(model.Data is Server server)) return;
            foreach (Database db in server.Databases)
            {
                if (systemDatabaseNames.Contains(db.Name)) //TODO - This is probably not the most elegant way to handle this...
                {
                    ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), model.Id, db));
                }
            }
        }

        public void CreateFolderNodesForDatabase(ObjectExplorerModel model)
        {
            if (!(model.Data is Database)) return;
            ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), GlobalStrings.FolderTypes.TableFolder,
                model));
            ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), GlobalStrings.FolderTypes.ViewFolder,
                model));
            ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(),
                GlobalStrings.FolderTypes.StoreProcedureFolder, model));
            ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(),
                GlobalStrings.FolderTypes.FunctionsFolder, model));
        }

        
        public void CreateFolderChildrenNodes(ObjectExplorerModel model)
        {
            var createFolderNodeAction = FolderActionDictionary[model.FullName];
            createFolderNodeAction.Invoke(model);
        }

        private void CreateTableNodes(ObjectExplorerModel model)
        {

            if (!(model.Data is Database database)) return;
            if (database.Tables.Count <= 0)
            {
                CreateEmptyNode(model);
                return;
            }

            foreach (Table table in database.Tables)
                ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), model.Id, table));
        }



        private void CreateViewNodes(ObjectExplorerModel model)
        {
            if (!(model.Data is Database database)) return;
            if ((database.Views.Count <= 0))
            {
                CreateEmptyNode(model);
                return;
            }

            foreach (View view in database.Views)
                ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), model.Id, view));
        }

        private void CreateStoredProcedureNodes(ObjectExplorerModel model)
        {

            if (!(model.Data is Database database)) return;
            if ((database.StoredProcedures.Count <= 0))
            {
                CreateEmptyNode(model);
                return;
            }

            foreach (StoredProcedure storedProcedure in database.StoredProcedures)
                ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), model.Id, storedProcedure));

        }

        private void CreateFunctionNodes(ObjectExplorerModel model)
        {

            if (!(model.Data is Database database)) return;
            if ((database.UserDefinedFunctions.Count <= 0))
            {
                CreateEmptyNode(model);
                return;
            }

            foreach (UserDefinedFunction function in database.UserDefinedFunctions)
                ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), model.Id, function));

        }

        public void CreateColumnNodes(ObjectExplorerModel model)
        {

            if (!(model.Data is Table table)) return;
            if (table.Columns.Count <= 0)
            {
                CreateEmptyNode(model);
                return;
            }

            foreach (Column column in table.Columns)
                ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), model.Id, column));


        }

        private void CreateEmptyNode(ObjectExplorerModel model)
        {
            ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), model));
        }




        private int GetNewNodeId()
        {
            _nodeId++;
            return _nodeId;
        }
    }

}