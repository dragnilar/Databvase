using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Databvase_Winforms.Globals;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Models;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class ObjectExplorerViewModel
    {
        private int NodeId;

        public ObjectExplorerViewModel()
        {
            GetSelectTopDescriptionForPopupMenu();
            RegisterForMessages();
            ObjectExplorerSource = new BindingList<ObjectExplorerModel>();
        }

        public virtual string SelectTopContextMenuItemDescription { get; set; }
        public virtual BindingList<ObjectExplorerModel> ObjectExplorerSource { get; set; }

        private int GetNewNodeId()
        {
            NodeId++;
            return NodeId;
        }

        private void GetSelectTopDescriptionForPopupMenu()
        {
            SelectTopContextMenuItemDescription =
                $"Generate Select Top {App.Config.NumberOfRowsForTopSelectScript} Rows";
        }

        private void RegisterForMessages()
        {
            Messenger.Default.Register<SettingsUpdatedMessage>(this, SettingsUpdatedMessage.SettingsUpdatedSender,
                OnSettingsUpdated);
            Messenger.Default.Register<InstanceConnectedMessage>(this, InstanceConnectedMessage.ConnectInstanceSender,
                InitInstances);
            Messenger.Default.Register<DisconnectInstanceMessage>(this,
                DisconnectInstanceMessage.DisconnectInstanceSender, DisconnectInstance);
        }

        private void OnSettingsUpdated(SettingsUpdatedMessage settingsUpdated)
        {
            if (settingsUpdated.Type == SettingsUpdatedMessage.SettingsUpdateType.NumberOfRowsForTopSelectScript)
                GetSelectTopDescriptionForPopupMenu();
        }

        private void DisconnectInstance(DisconnectInstanceMessage message)
        {
            if (message == null) return;
            App.Connection.DisconnectCurrentInstance(); //TODO - See if there's a better way to do this...
            var instanceTree = ObjectExplorerSource.Where(r => r.InstanceName == message.InstanceName).ToList();
            foreach (var item in instanceTree) ObjectExplorerSource.Remove(item);
        }


        public void FocusedNodeChanged(FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            if (e.OldNode == null) return;
            var instanceName = e.Node.GetValue(4) as string;

            var database = GetDatabaseFromNode(e.Node);
            if (instanceName == App.Connection.InstanceTracker.InstanceName)
                if (database != null)
                    if (database.Name == App.Connection.InstanceTracker.DatabaseObject?.Name)
                        return;
            SendInstanceNameChangedMessage(instanceName, database);
        }

        private Database GetDatabaseFromNode(TreeListNode node)
        {
            if (node == null) return null;
            var model = GetModelForNode(node);
            switch (model.Type)
            {
                case GlobalStrings.ObjectExplorerTypes.Instance:
                    return null;
                case GlobalStrings.ObjectExplorerTypes.Database:
                    return (Database) model.Data;
                case GlobalStrings.ObjectExplorerTypes.Table:
                    return ((Table) model.Data).Parent;
                case GlobalStrings.ObjectExplorerTypes.Column:
                    var column = model.Data as Column;
                    return ((Table) column?.Parent)?.Parent;
            }
            return null;
        }

        private void SendInstanceNameChangedMessage(string instanceName, Database database)
        {
            if (instanceName == null) return;
            var tracker = new InstanceAndDatabaseTracker
            {
                InstanceName = instanceName,
                DatabaseObject = database
            };
            Messenger.Default.Send(new InstanceNameChangeMessage(tracker),
                InstanceNameChangeMessage.NewInstanceNameSender);
        }

        public List<string> GetInstancesList()
        {
            var instancesList = new List<string>();

            foreach (var connection in App.Connection.CurrentConnections) instancesList.Add(connection.Instance);
            return instancesList;
        }


        #region Adding Instance Node Methods

        private void InitInstances(InstanceConnectedMessage message)
        {
            if (message == null) return;
            GenerateInstances();
        }

        private void GenerateInstances()
        {
            try
            {
                foreach (var instance in GetInstancesList())
                {
                    if (InstanceAlreadyOnTree(instance)) continue;

                    CreateInstanceNode(instance);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void CreateInstanceNode(string instance)
        {
            ObjectExplorerSource.Add(new ObjectExplorerModel
            {
                ParentId = 0,
                Id = GetNewNodeId(),
                InstanceName = instance,
                Type = GlobalStrings.ObjectExplorerTypes.Instance,
                Data = App.Connection.GetServerAtSpecificInstance(instance),
                FullName = instance,
                ParentName = string.Empty,
                ImageIndex = 0
            });
        }

        private bool InstanceAlreadyOnTree(string instance)
        {
            return ObjectExplorerSource.Any(x => x.InstanceName == instance);
        }

        #endregion

        #region Object Explorer On Demand Data Methods

        public void ObjectExplorer_OnBeforeExpand(BeforeExpandEventArgs e)
        {
            if (e.Node.Nodes.Count > 0) return;
            var model = GetModelForNode(e.Node);
            switch (e.Node.GetValue(1))
            {
                case GlobalStrings.ObjectExplorerTypes.Instance:
                    InitDatabases(model);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Database:
                    InitTables(model);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Table:
                    InitColumns(model);
                    break;
            }
        }

        private ObjectExplorerModel GetModelForNode(TreeListNode node)
        {
            var model = node.TreeList.GetRow(node.Id) as ObjectExplorerModel;
            return model;
        }

        private void InitDatabases(ObjectExplorerModel model)
        {
            try
            {
                if (!(model.Data is Server server)) return;
                if (server.Databases.Count <= 0) return;
                foreach (Database db in server.Databases) CreateDatabaseNode(model, server, db);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void CreateDatabaseNode(ObjectExplorerModel model, Server server, Database db)
        {
            ObjectExplorerSource.Add(new ObjectExplorerModel
            {
                ParentId = model.Id,
                Id = GetNewNodeId(),
                InstanceName = server.Name,
                Type = GlobalStrings.ObjectExplorerTypes.Database,
                Data = db,
                FullName = db.Name,
                ParentName = server.Name,
                ImageIndex = 1
            });
        }

        private void InitTables(ObjectExplorerModel model)
        {
            try
            {
                if (!(model.Data is Database database)) return;
                if (database.Tables.Count <= 0) return;
                foreach (Table table in database.Tables) CreateTableNode(table, model.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void CreateTableNode(Table table, int databaseId)
        {
            ObjectExplorerSource.Add(new ObjectExplorerModel
            {
                ParentId = databaseId,
                Id = GetNewNodeId(),
                InstanceName = table.Parent.Parent.Name,
                Type = GlobalStrings.ObjectExplorerTypes.Table,
                Data = table,
                FullName = table.Schema != "dbo" ? $"{table.Schema}.{table.Name}" : table.Name,
                ParentName = table.Parent.Name,
                ImageIndex = 2
            });
        }

        private void InitColumns(ObjectExplorerModel model)
        {
            try
            {
                if (!(model.Data is Table table)) return;
                if (table.Columns.Count <= 0) return;
                var tableFullName = table.Schema != "dbo" ? $"{table.Schema}.{table.Name}" : table.Name;
                if (table.Columns.Count <= 0) return;
                foreach (Column column in table.Columns) CreateColumnNode(column, tableFullName, model.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void CreateColumnNode(Column column, string tableFullName, int tableId)
        {
            ObjectExplorerSource.Add(new ObjectExplorerModel
            {
                ParentId = tableId,
                Id = GetNewNodeId(),
                InstanceName = ((Table) column.Parent).Parent.Parent.Name,
                Type = GlobalStrings.ObjectExplorerTypes.Column,
                Data = column,
                FullName = column.Name,
                ParentName = tableFullName,
                ImageIndex = 3
            });
        }

        #endregion

        #region Scripting

        public void ScriptSelectAllForTable(Table selectedTable)
        {
            var selectStatement = new ScriptGeneratorService().GenerateSelectAllStatement(selectedTable);
            var scriptMessage = new NewScriptMessage(selectStatement, selectedTable.Parent.Name);
            SendNewScriptMessage(scriptMessage);
        }

        public void ScriptSelectTopForTable(Table selectedTable)
        {
            var selectStatement = new ScriptGeneratorService().GenerateSelectTopStatement(selectedTable);
            var scriptMessage = new NewScriptMessage(selectStatement, selectedTable.Parent.Name);
            SendNewScriptMessage(scriptMessage);
        }

        private void SendNewScriptMessage(NewScriptMessage message)
        {
            Messenger.Default.Send(message, NewScriptMessage.NewScriptSender);
        }

        #endregion
    }
}