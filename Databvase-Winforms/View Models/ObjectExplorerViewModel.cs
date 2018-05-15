 using System;
using System.Collections.Generic;
using System.ComponentModel;
 using System.Diagnostics;
 using System.Linq;
using System.Threading.Tasks;
 using System.Windows;
 using Databvase_Winforms.Globals;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Models;
using Databvase_Winforms.Models.Data_Providers;
using Databvase_Winforms.Services;
 using Databvase_Winforms.Services.Window_Dialog_Services;
 using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class ObjectExplorerViewModel
    {

        private ObjectExplorerDataSource _dataSourceModel;
        public virtual UnboundLoadModes LoadingMode { get; set; }
        public virtual string SelectTopContextMenuItemDescription { get; set; }
        public virtual BindingList<ObjectExplorerNode> ObjectExplorerSource { get; set; }
        protected IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();
        protected ISplashScreenService SplashScreenService => this.GetService<ISplashScreenService>();
        protected IBackupViewService BackupViewService => this.GetService<IBackupViewService>();
        public virtual ObjectExplorerNode FocusedNode { get; set; }

        public ObjectExplorerViewModel()
        {
            GetSelectTopDescriptionForPopupMenu();
            RegisterForMessages();
            _dataSourceModel = new ObjectExplorerDataSource();
            ObjectExplorerSource = _dataSourceModel.DataSource;
            LoadingMode = UnboundLoadModes.NotLoading;
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
            LoadingMode = UnboundLoadModes.BeginUnboundLoad;
            App.Connection.DisconnectCurrentInstance(); //TODO - See if there's a better way to do this...
            var instanceTree =  _dataSourceModel.DataSource.Where(r => r.InstanceName == message.InstanceName).ToList();
            foreach (var item in instanceTree)  _dataSourceModel.DataSource.Remove(item);
            FinishUnboundLoad();
        }

        public void CopyNameCell()
        {
            Clipboard.SetDataObject(FocusedNode.FullName);
        }

        public void ShowBackupView()
        {
            BackupViewService.Show();
        }

        #region Object Explorer On Demand Data Methods

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
            if (e.Node.Nodes.Count <= 0)
            {
                var model = GetModelForNode(e.Node);
                LoadDataForObjectExplorerDynamically(model);
            };
        }

        private void LoadDataForObjectExplorerDynamically(ObjectExplorerNode model)
        {
            LoadingMode = UnboundLoadModes.BeginUnboundLoad;
            ShowWaitMessageIfItsNotActive();
            try
            {
                GetNodes(model);
            }
            catch (Exception e)
            {
                _dataSourceModel.CreateEmptyNode(model);
                DisplayErrorMessage(e.Message, "Error Getting Objects");
            }
            finally
            {
                KillWaitMessageIfItsActive();
                FinishUnboundLoad();
            }

        }

        private void GetNodes(ObjectExplorerNode model)
        {
            switch (model.Type)
            {
                case GlobalStrings.ObjectExplorerTypes.Instance:
                    _dataSourceModel.CreateUserDatabaseNodes(model);
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
            var response = new ScriptGeneratorService().GenerateSelectTopStatement(FocusedNode);
            ValidateResponseAndSendScriptMessage(response);
        }

        public void ScriptSelectAllForObjectExplorerData()
        {
            var response = new ScriptGeneratorService().GenerateSelectAllStatement(FocusedNode);
            ValidateResponseAndSendScriptMessage(response);
        }

        public void ScriptModifyForObjectExplorerData()
        {
            var response = new ScriptGeneratorService().GenerateModifyScript(FocusedNode);
            ValidateResponseAndSendScriptMessage(response);
        }

        public void ScriptAlterForObjectExplorerData()
        {
            var response = new ScriptGeneratorService().GenerateAlterScript(FocusedNode);
            ValidateResponseAndSendScriptMessage(response);
        }

        private void SendBlankScript(string selectedDatabaseName)
        {
            new NewScriptMessage(string.Empty, selectedDatabaseName);
        }

        private void ValidateResponseAndSendScriptMessage(ScriptGenerationResult result)
        {
            if (result.HasErrors)
            {
                DisplayErrorMessage(result.ErrorMessage, "Error Generating Script");
            }
            else
            {
                new NewScriptMessage(result.Script, result.DatabaseName);
            }
            
        }

        #endregion

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
            KillWaitMessageIfItsActive();
            MessageBoxService.ShowMessage(message, header, MessageButton.OK, MessageIcon.Error);
        }

        private void ShowWaitMessageIfItsNotActive()
        {
            if (!SplashScreenService.IsSplashScreenActive)
            {
                SplashScreenService.ShowSplashScreen();
            }
        }

        private void KillWaitMessageIfItsActive()
        {
            if (SplashScreenService.IsSplashScreenActive)
            {
                SplashScreenService.HideSplashScreen();
            }
        }

        private void FinishUnboundLoad()
        {
            LoadingMode = UnboundLoadModes.FinishUnboundLoad;
            LoadingMode = UnboundLoadModes.NotLoading;
        }

        public enum UnboundLoadModes
        {
            NotLoading,
            BeginUnboundLoad,
            FinishUnboundLoad
        }
    }
}