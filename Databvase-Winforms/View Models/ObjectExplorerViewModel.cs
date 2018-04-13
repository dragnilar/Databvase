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
        protected bool InstancesLoaded;
        public virtual List<string> InstancesList { get; set; }

        public ObjectExplorerViewModel()
        {
            InstancesList = GetInstancesList();
            InstancesLoaded = false;

        }

        public void ScriptSelectAllForTable(string selectedTable, string dbName)
        {
            var selectStatement = new ScriptGeneratorService().GenerateSelectAllStatement(selectedTable);
            var scriptMessage = new NewScriptMessage(selectStatement, dbName);

            Messenger.Default.Send(scriptMessage, NewScriptMessage.NewScriptSender);
        }

        public void GetNodesForObjectExplorer(VirtualTreeGetChildNodesInfo e)
        {
            try
            {
                if (!InstancesLoaded)
                {
                    GetInstancesList(e);
                }
                else
                {
                    ObjectExplorerTreeListObject nodeObject = (ObjectExplorerTreeListObject)e.Node;
                    switch (nodeObject.Type)
                    {
                        case "Instance":
                            GetDatabases(e);
                            break;
                        case "Database":
                            GetTables(e);
                            break;
                        case "Table":
                            GetColumns(e);
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

        }


        private void GetInstancesList(VirtualTreeGetChildNodesInfo e)
        {
            var list = new List<ObjectExplorerTreeListObject>();
            foreach (var instance in InstancesList)
            {
                list.Add(new ObjectExplorerTreeListObject
                {
                    Name = instance,
                    Type = "Instance",
                    FullName = instance,
                    ParentName = string.Empty
                });
            }
            e.Children = list;
            InstancesLoaded = true;
        }

        private List<string> GetInstancesList()
        {
            //Only one instance at a time right now...
            var instancesList = new List<string>();
            instancesList.Add(App.Connection.CurrentConnection.Instance);
            return instancesList;
        }

        private void GetDatabases(VirtualTreeGetChildNodesInfo e)
        {

            try
            {
                var dbList = SQLServerInterface.GetDatabaseNames();

                if (dbList.Any())
                {
                    var list = new List<ObjectExplorerTreeListObject>();
                    foreach (var db in dbList)
                    {
                        list.Add(new ObjectExplorerTreeListObject
                        {
                            Name = db,
                            Type = "Database",
                            ParentName = string.Empty,
                            FullName = db
                        }
                        );
                    }

                    e.Children = list;
                }
                else e.Children = new List<ObjectExplorerTreeListObject>();
            }
            catch
            {
                e.Children = new List<ObjectExplorerTreeListObject>();
            }
        }

        private void GetTables(VirtualTreeGetChildNodesInfo e)
        {
            try
            {
                var dbName = ((ObjectExplorerTreeListObject)e.Node).Name;
                var tableList = SQLServerInterface.GetTables(dbName);

                if (tableList.Any())
                {
                    var list = new List<ObjectExplorerTreeListObject>();
                    foreach (var table in tableList)
                    {
                        list.Add(new ObjectExplorerTreeListObject
                        {
                            Name = table.Name,
                            Type = "Table",
                            ParentName = dbName,
                            FullName = table.Schema != "dbo" ? $"{table.Schema}.{table.Name}" : table.Name
                        }
                        );
                    }

                    e.Children = list;
                }
                else e.Children = new List<ObjectExplorerTreeListObject>();
            }
            catch
            {
                e.Children = new List<ObjectExplorerTreeListObject>();
            }
        }

        private static void GetColumns(VirtualTreeGetChildNodesInfo e)
        {


            try
            {
                var table = ((ObjectExplorerTreeListObject)e.Node);
                var columnList = SQLServerInterface.GetColumnNames(table.Name, table.ParentName);

                if (columnList.Any())
                {
                    var list = new List<ObjectExplorerTreeListObject>();
                    foreach (var col in columnList)
                    {
                        list.Add(new ObjectExplorerTreeListObject
                        {
                            Name = col,
                            Type = "Column",
                            FullName = col,
                            ParentName = table.Name

                        }
                        );
                    }

                    e.Children = list;
                }
                else e.Children = new List<ObjectExplorerTreeListObject>();
            }
            catch
            {
                e.Children = new List<ObjectExplorerTreeListObject>();
            }
        }
    }
}