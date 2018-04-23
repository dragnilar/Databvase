using System;
using System.ComponentModel;
using System.Linq;
using Databvase_Winforms.Globals;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Models
{
    public class ObjectExplorerDataSourceModel
    {
        private int _nodeId;
        public BindingList<ObjectExplorerModel> ObjectExplorerDataSource { get; set; }

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
                if (server.Databases.Count <= 0) return;
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
        { //TODO - See if there is a way to make this more "generic"
            switch (model.FullName)
            {
                case GlobalStrings.FolderTypes.TableFolder:
                    CreateTableNodes(model);
                    break;
                case GlobalStrings.FolderTypes.ViewFolder:
                    CreateViewNodes(model);
                    break;
                case GlobalStrings.FolderTypes.StoreProcedureFolder:
                    break;
                case GlobalStrings.FolderTypes.FunctionsFolder:
                    break;
            }
        }

        private void CreateTableNodes(ObjectExplorerModel model)
        {
            try
            {
                if (!(model.Data is Database database)) return;
                if (database.Tables.Count <= 0) return;
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
                if ((database.Views.Count <= 0)) return;
                foreach (View view in database.Views)
                    ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), model.Id, view));
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
                if (table.Columns.Count <= 0) return;
                foreach (Column column in table.Columns)
                    ObjectExplorerDataSource.Add(new ObjectExplorerModel(GetNewNodeId(), model.Id, column));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        private int GetNewNodeId()
        {
            _nodeId++;
            return _nodeId;
        }
    }

}