using System.Collections.Generic;
using System.Linq;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Models;
using DevExpress.Mvvm.DataAnnotations;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class ObjectExplorerViewModel
    {
        public ObjectExplorerViewModel()
        {
            SetupObjectExplorer();
        }

        public virtual List<ObjectExplorerTreeListObject> ObjectExplorerDataSource { get; set; }
        public virtual List<Database> CurrentDatabases { get; set; }
        public virtual string CurrentServerName { get; set; }


        public void SetupObjectExplorer()
        {
            GetDatabases();
            GetServerName();
            ObjectExplorerDataSource = GetObjectExplorerDataSource();
        }

        private void GetDatabases()
        {
            CurrentDatabases = SQLServerInterface.GetDatabases();
        }

        private void GetServerName()
        {
            CurrentServerName = SQLServerInterface.GetServerName();
        }

        private List<ObjectExplorerTreeListObject> GetObjectExplorerDataSource()
        {
            var sauce = new List<ObjectExplorerTreeListObject>();
            var index = 0;

            sauce.Add(new ObjectExplorerTreeListObject
            {
                Id = index++,
                Name = CurrentServerName,
                NodeType = ObjectExplorerTreeListObject.TypeOfNode.Instance,
                ParentId = index - 1
            });

            foreach (Database db in CurrentDatabases)
            {
                var databaseId = index;
                sauce.Add(new ObjectExplorerTreeListObject
                {
                    Id = index++,
                    Name = db.Name,
                    NodeType = ObjectExplorerTreeListObject.TypeOfNode.Database,
                    ParentId = 0
                });

                foreach (Table table in db.Tables)
                {
                    var tableId = index;
                    sauce.Add(new ObjectExplorerTreeListObject
                    {
                        Id = index++,
                        Name = table.Schema != "dbo" ? $"{table.Schema}.{table.Name}" : table.Name,
                        NodeType = ObjectExplorerTreeListObject.TypeOfNode.Table,
                        ParentId = databaseId
                    });

                    foreach (Column obj in table.Columns)
                        sauce.Add(new ObjectExplorerTreeListObject
                        {
                            Id = index++,
                            Name = obj.Name,
                            NodeType = ObjectExplorerTreeListObject.TypeOfNode.Column,
                            ParentId = tableId
                        });
                }

            }


            return sauce;
        }
    }
}