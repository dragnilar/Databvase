using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media.Media3D;
using Databvase_Winforms.Globals;
using Databvase_Winforms.Utilities;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Models
{
    //TODO - When an exception occurs creating database nodes, we need to display a message so that the user does not cause the program to freeze from numerous mouse clicks.
    public class ObjectExplorerDataSourceModel
    {
        private int _nodeId;
        public BindingList<ObjectExplorerModel> ObjectExplorerDataSource { get; set; }
        private Dictionary<string, Action<ObjectExplorerModel>> _folderActionDictionary = null;

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
                           });
            }
        }

        public ObjectExplorerDataSourceModel()
        {
            ObjectExplorerDataSource = new BindingList<ObjectExplorerModel>();
        }

        public void GenerateInstances()
        {
            try
            {
                foreach (var instance in App.Connection.CurrentConnections.Select(x => x.Instance).ToList())
                {
                    if (InstanceAlreadyInDataSource(instance)) continue;
                    var serverInstance = App.Connection.GetServerAtSpecificInstance(instance);
                    ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), serverInstance));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private bool InstanceAlreadyInDataSource(string instance)
        {
            return ObjectExplorerDataSource.Any(x => x.InstanceName == instance);
        }


        public void CreateDatabaseNodes(ObjectExplorerModel model)
        {
            try
            {
                if (!(model.Data is Server server)) return;
                if (server.Databases.Count <= 0)
                {
                    CreateEmptyNode(model);
                    return;
                }

                foreach (Database db in server.Databases)
                    ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), model.Id, db));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }



        private void CreateViewNodes(ObjectExplorerModel model)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }

        private void CreateStoredProcedureNodes(ObjectExplorerModel model)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void CreateFunctionNodes(ObjectExplorerModel model)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void CreateColumnNodes(ObjectExplorerModel model)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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