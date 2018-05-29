using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Models;
using Databvase_Winforms.Models.Data_Providers;
using Databvase_Winforms.Services.Window_Dialog_Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class ObjectExplorerViewModel
    {
        public enum UnboundLoadModes
        {
            NotLoading,
            BeginUnboundLoad,
            FinishUnboundLoad,
            FinishUnboundLoadRefresh
        }

        private readonly ObjectExplorerDataSource _dataSourceModel;
        private bool _refreshing; 

        public ObjectExplorerViewModel()
        {
            GetSelectTopDescriptionForPopupMenu();
            RegisterForMessages();
            _dataSourceModel = new ObjectExplorerDataSource();
            ObjectExplorerSource = _dataSourceModel.DataSource;
            LoadingMode = UnboundLoadModes.NotLoading;
        }

        public virtual UnboundLoadModes LoadingMode { get; set; }
        public virtual string SelectTopContextMenuItemDescription { get; set; }
        public virtual BindingList<ObjectExplorerNode> ObjectExplorerSource { get; set; }
        protected IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();
        protected IBackupViewService BackupViewService => this.GetService<IBackupViewService>();
        public virtual ObjectExplorerNode FocusedNode { get; set; }


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
            LoadingMode = UnboundLoadModes.BeginUnboundLoad;
            App.Connection.DisconnectCurrentInstance(); //TODO - See if there's a better way to do this...
            var instanceTree = _dataSourceModel.DataSource.Where(r => r.InstanceName == message.InstanceName).ToList();
            foreach (var item in instanceTree) _dataSourceModel.DataSource.Remove(item);
            FinishUnboundLoad();
        }

        public void CopyNameCell()
        {
            Clipboard.SetDataObject(FocusedNode.DisplayName);
        }

        public void ShowBackupView()
        {
            BackupViewService.Show();
        }

        #region Focused Node Changed

        //Binds at runtime 
        public void OnFocusedNodeChanged()
        {
            if (FocusedNode != null)
            {
                var instance = FocusedNode.GetInstanceFromNode();
                var database = FocusedNode.GetDatabaseFromNode();
                if (instance == App.Connection.CurrentServer)
                    if (database != null)
                        if (database.Name == App.Connection.CurrentDatabase?.Name)
                            return;
                new InstanceNameChangeMessage(instance, database);
            }
        }

        #endregion

        private void DisplayErrorMessage(string message, string header)
        {
            FinishUnboundLoad();
            MessageBoxService.ShowMessage(message, header, MessageButton.OK, MessageIcon.Error);
        }

        private void FinishUnboundLoad()
        {
            LoadingMode = _refreshing ? UnboundLoadModes.FinishUnboundLoadRefresh : UnboundLoadModes.FinishUnboundLoad;
            LoadingMode = UnboundLoadModes.NotLoading;
            _refreshing = false;
        }

        #region Object Explorer On Demand Data Methods

        public void RefreshNode()
        {
            var node = FocusedNode;
            try
            {
                _refreshing = true;
                LoadingMode = UnboundLoadModes.BeginUnboundLoad;
                _dataSourceModel.RefreshNode(node);
                FinishUnboundLoad();
            }
            catch (Exception e)
            {
                _dataSourceModel.CreateEmptyNode(node);
                DisplayErrorMessage(e.Message, "Error Refreshing Objects");
            }
        }

        private void GetInstances(InstanceConnectedMessage message)
        {
            if (message == null) return;
            try
            {
                _dataSourceModel.GenerateInstances();
            }
            catch (Exception e)
            {
                DisplayErrorMessage(e.Message, "Error Getting Objects");
            }
        }

        public void ObjectExplorer_OnBeforeExpand(BeforeExpandEventArgs e)
        {
            if (_refreshing) return;

            if (e.Node.Nodes.Count <= 0)
            {
                var model = GetModelForNode(e.Node);
                LoadDataForObjectExplorerDynamically(model);
            }
        }

        private void LoadDataForObjectExplorerDynamically(ObjectExplorerNode selectedNode)
        {
            LoadingMode = UnboundLoadModes.BeginUnboundLoad;
            try
            {
                _dataSourceModel.GetNodes(selectedNode);
                FinishUnboundLoad();
            }
            catch (Exception e)
            {
                _dataSourceModel.CreateEmptyNode(selectedNode);
                DisplayErrorMessage(e.Message, "Error Getting Objects");
            }
        }

        private ObjectExplorerNode GetModelForNode(TreeListNode node)
        {
            var model = node.TreeList.GetRow(node.Id) as ObjectExplorerNode;
            return model;
        }

        #endregion

        #region Scripting

        public void NewQueryScript()
        {
            var selectedDatabase = FocusedNode.GetDatabaseFromNode();
            var selectedDatabaseName = selectedDatabase == null ? string.Empty : selectedDatabase.Name;
            SendBlankScript(selectedDatabaseName);
        }

        public void ScriptSelectTopForObjectExplorerData()
        {
            new ScriptGenerator().GenerateSelectTopStatement(FocusedNode);
        }

        public void ScriptSelectAllForObjectExplorerData()
        {
            new ScriptGenerator().GenerateSelectAllStatement(FocusedNode);
        }

        public void ScriptModifyForObjectExplorerData()
        {
            new ScriptGenerator().GenerateModifyScript(FocusedNode);
        }

        public void ScriptAlterForObjectExplorerData()
        {
            new ScriptGenerator().GenerateAlterScript(FocusedNode);
        }

        private void SendBlankScript(string selectedDatabaseName)
        {
            new ScriptGenerator().GenerateBlankScript(selectedDatabaseName);
        }

        #endregion
    }
}