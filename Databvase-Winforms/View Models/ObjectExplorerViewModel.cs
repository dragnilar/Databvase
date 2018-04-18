using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Models;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.XtraTreeList;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class ObjectExplorerViewModel
    {
        public virtual string SelectTopContextMenuItemDescription { get; set; }

        public ObjectExplorerViewModel()
        {
            GetSelectTopDescription();
            RegisterForMessages();
        }

        private void RegisterForMessages()
        {
            Messenger.Default.Register<SettingsUpdatedMessage>(this, SettingsUpdatedMessage.SettingsUpdatedSender, OnSettingsUpdated );
        }

        public void ScriptSelectAllForTable(Table selectedTable)
        {
            var selectStatement = new ScriptGeneratorService().GenerateSelectAllStatement(selectedTable);
            var scriptMessage = new NewScriptMessage(selectStatement, selectedTable.Parent.Name);

            Messenger.Default.Send(scriptMessage, NewScriptMessage.NewScriptSender);
        }

        public void ScriptSelectTopForTable(Table selectedTable)
        {
            var selectStatement = new ScriptGeneratorService().GenerateSelectTopStatement(selectedTable);
            var scriptMessage = new NewScriptMessage(selectStatement, selectedTable.Parent.Name);

            Messenger.Default.Send(scriptMessage, NewScriptMessage.NewScriptSender);
        }

        public List<string> GetInstancesList()
        {
            var instancesList = new List<string>();

            foreach (var connection in App.Connection.CurrentConnections)
            {
                instancesList.Add(connection.Instance);
            }
            return instancesList;
        }


        private void GetSelectTopDescription()
        {
            SelectTopContextMenuItemDescription = $"Generate Select Top {App.Config.NumberOfRowsForTopSelectScript} Rows";
        }

        private void OnSettingsUpdated(SettingsUpdatedMessage settingsUpdated)
        {
            if ((settingsUpdated.Type == SettingsUpdatedMessage.SettingsUpdateType.NumberOfRowsForTopSelectScript))
            {
                GetSelectTopDescription();
            }
        }




    }
}