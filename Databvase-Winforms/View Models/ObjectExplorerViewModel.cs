using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Databvase_Winforms.DAL;
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
        public virtual string SelectTopContextMenuItemDescription { get; set; }

        public ObjectExplorerViewModel()
        {
            GetSelectTopDescriptionForPopupMenu();
            RegisterForMessages();
        }
        
        private void GetSelectTopDescriptionForPopupMenu()
        {
            SelectTopContextMenuItemDescription = $"Generate Select Top {App.Config.NumberOfRowsForTopSelectScript} Rows";
        }

        private void RegisterForMessages()
        {
            Messenger.Default.Register<SettingsUpdatedMessage>(this, SettingsUpdatedMessage.SettingsUpdatedSender, OnSettingsUpdated );
        }

        private void OnSettingsUpdated(SettingsUpdatedMessage settingsUpdated)
        {
            if ((settingsUpdated.Type == SettingsUpdatedMessage.SettingsUpdateType.NumberOfRowsForTopSelectScript))
            {
                GetSelectTopDescriptionForPopupMenu();
            }
        }

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

        #region Object Explorer On Demand Data Methods
        public void ObjectExplorer_OnBeforeExpand(BeforeExpandEventArgs e)
        {
            if (e.Node.Nodes.Count > 0) return;

            switch (e.Node.Tag.ToString())
            {
                case GlobalStrings.ObjectExplorerTypes.Instance:
                    InitDatabases(e.Node);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Database:
                    InitTables(e.Node);
                    break;
                case GlobalStrings.ObjectExplorerTypes.Table:
                    InitColumns(e.Node);
                    break;
            }
        }

        private void InitDatabases(TreeListNode instanceNode)
        {
            try
            {
                var instanceName = instanceNode.GetValue(0).ToString();
                var dbList = SQLServerInterface.GetDatabases(instanceName);
                if (dbList.Any())
                {
                    foreach (var db in dbList)
                    {
                        var node = instanceNode.Nodes.Add(new object[]
                        {
                            db.Name,
                            GlobalStrings.ObjectExplorerTypes.Database,
                            instanceName,
                            db,
                            instanceName
                        });
                        node.StateImageIndex = 1;
                        node.HasChildren = true;
                        node.Tag = GlobalStrings.ObjectExplorerTypes.Database;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        private void InitTables(TreeListNode databaseNode)
        {
            try
            {
                var database = (Database)databaseNode.GetValue(3);
                if (database.Tables.Count > 0)
                {
                    foreach (Table table in database.Tables)
                    {
                        CreateTableNode(databaseNode, table, database.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void CreateTableNode(TreeListNode databaseNode, Table table, string databaseName)
        {
            var node = databaseNode.Nodes.Add(                
                table.Schema != "dbo" ? $"{table.Schema}.{table.Name}" : table.Name,
                GlobalStrings.ObjectExplorerTypes.Table,
                databaseName,
                table,
                table.Parent.Parent.Name);
            node.StateImageIndex = 2;
            node.HasChildren = true;
            node.Tag = GlobalStrings.ObjectExplorerTypes.Table;
        }

        private void InitColumns(TreeListNode tableNode)
        {
            try
            {
                var table = (Table)tableNode.GetValue(3);
                var tableFullName = tableNode.GetValue(0).ToString();
                if (table.Columns.Count < 1 ) return;
                foreach (Column column in table.Columns)
                {
                    CreateColumnNode(tableNode, column, tableFullName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void CreateColumnNode(TreeListNode tableNode, Column column, string tableFullName)
        {
            var node = tableNode.Nodes.Add(
                column.Name,
                GlobalStrings.ObjectExplorerTypes.Column,
                tableFullName,
                column,
                ((Table) column.Parent).Parent.Parent.Name
                );
            node.StateImageIndex = 3;
            node.HasChildren = false;
            node.Tag = GlobalStrings.ObjectExplorerTypes.Column;
        }
        #endregion

        public List<string> GetInstancesList()
        {
            var instancesList = new List<string>();

            foreach (var connection in App.Connection.CurrentConnections)
            {
                instancesList.Add(connection.Instance);
            }
            return instancesList;
        }
    }
}