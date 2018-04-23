using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
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

        private ObjectExplorerDataSourceModel _dataSourceModel;
        private bool Disconnecting = false;
        public virtual string SelectTopContextMenuItemDescription { get; set; }
        public virtual BindingList<ObjectExplorerModel> ObjectExplorerSource { get; set; }

        public ObjectExplorerViewModel()
        {
            GetSelectTopDescriptionForPopupMenu();
            RegisterForMessages();
            _dataSourceModel = new ObjectExplorerDataSourceModel();
            ObjectExplorerSource = _dataSourceModel.ObjectExplorerDataSource;
        }

        private void GetSelectTopDescriptionForPopupMenu()
        {
            SelectTopContextMenuItemDescription =
                $"Generate Select Top {App.Config.NumberOfRowsForTopSelectScript} Rows";
        }

        private void RegisterForMessages()
        {
            Messenger.Default.Register<SettingsUpdatedMessage>(this, typeof(SettingsUpdatedMessage).Name,
                OnSettingsUpdated);
            Messenger.Default.Register<InstanceConnectedMessage>(this, typeof(InstanceConnectedMessage).Name,
                GetInstances);
            Messenger.Default.Register<DisconnectInstanceMessage>(this,
                typeof(DisconnectInstanceMessage).Name, DisconnectInstance);
        }

        private void OnSettingsUpdated(SettingsUpdatedMessage settingsUpdated)
        {
            if (settingsUpdated.Type == SettingsUpdatedMessage.SettingsUpdateType.NumberOfRowsForTopSelectScript)
                GetSelectTopDescriptionForPopupMenu();
        }

        private void DisconnectInstance(DisconnectInstanceMessage message)
        {
            if (message == null) return;
            Disconnecting = true;
            App.Connection.DisconnectCurrentInstance(); //TODO - See if there's a better way to do this...
            var instanceTree =  _dataSourceModel.ObjectExplorerDataSource.Where(r => r.InstanceName == message.InstanceName).ToList();
            foreach (var item in instanceTree)  _dataSourceModel.ObjectExplorerDataSource.Remove(item);
            Disconnecting = false;
        }

        //TODO - This doesn't work, need to look into a way to update the tree list faster when disconnecting...
        //private async void DisconnectAsync(DisconnectInstanceMessage message)
        //{
        //    if (message == null) return;
        //    Disconnecting = true;
        //    App.Connection.DisconnectCurrentInstance();
        //    await Task.Run(() =>
        //    {
        //        var instanceTree = _dataSourceModel.ObjectExplorerDataSource.Where(r => r.InstanceName == message.InstanceName).ToList();
        //        foreach (var item in instanceTree) _dataSourceModel.ObjectExplorerDataSource.Remove(item);
        //    });
        //    Disconnecting = false;
        //}

        #region Object Explorer On Demand Data Methods

        private void GetInstances(InstanceConnectedMessage message)
        {
            if (message == null) return;
            _dataSourceModel.GenerateInstances();
        }

        public void ObjectExplorer_OnBeforeExpand(BeforeExpandEventArgs e)
        {
            if (e.Node.Nodes.Count > 0 || Disconnecting) return;
            var model = GetModelForNode(e.Node);
            switch (model.Type)
            {
                case GlobalStrings.ObjectExplorerTypes.Instance:
                    _dataSourceModel.CreateDatabaseNodes(model);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Database:
                    _dataSourceModel.CreateFolderNodesForDatabase(model);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Folder:
                    _dataSourceModel.CreateFolderChildrenNodes(model);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Table:
                    _dataSourceModel.CreateColumnNodes(model);
                    break;
            }
        }


        private ObjectExplorerModel GetModelForNode(TreeListNode node)
        {
            var model = node.TreeList.GetRow(node.Id) as ObjectExplorerModel;
            return model;
        }



        #endregion

        #region Scripting


        public void ScriptSelectTopForObjectExplorerData(object objectExplorerModelData)
        {
            var response = new ScriptGeneratorService().GenerateSelectTopStatement(objectExplorerModelData);
            new NewScriptMessage(response.script, response.parentName);
        }

        public void ScriptSelectAllForObjectExplorerData(object objectExplorerModelData)
        {
            var response = new ScriptGeneratorService().GenerateSelectAllStatement(objectExplorerModelData);
            new NewScriptMessage(response.script, response.parentName);
        }

        public void NewQueryScript(Database selectedDatabase)
        {
            var selectedDatabaseName = selectedDatabase == null ? string.Empty : selectedDatabase.Name;
            new NewScriptMessage(string.Empty, selectedDatabaseName);
        }

        #endregion

        #region Focused Node Changed

        public void FocusedNodeChanged(FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            if (e.OldNode == null) return;
            var instanceName = GetInstanceNameFromNode(e.Node);

            var database = GetDatabaseFromNode(e.Node);
            if (instanceName == App.Connection.InstanceTracker.InstanceName)
                if (database != null)
                    if (database.Name == App.Connection.InstanceTracker.DatabaseObject?.Name)
                        return;
            new InstanceNameChangeMessage(instanceName, database);
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
                case GlobalStrings.ObjectExplorerTypes.Folder:
                    return (Database) model.Data;
                case GlobalStrings.ObjectExplorerTypes.Table:
                    return ((Table) model.Data).Parent;
                case GlobalStrings.ObjectExplorerTypes.Column:
                    var column = model.Data as Column;
                    return ((Table) column?.Parent)?.Parent;
            }
            return null;
        }

        private string GetInstanceNameFromNode(TreeListNode node)
        {
            if (node == null) return null;
            var model = GetModelForNode(node);
            return model.InstanceName;
        }

        #endregion
    }
}