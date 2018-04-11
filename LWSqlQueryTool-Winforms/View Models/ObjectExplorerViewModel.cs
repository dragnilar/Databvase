using System.Collections.Generic;
using System.Linq;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Models;
using DevExpress.Mvvm.DataAnnotations;

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
        public virtual SQLSchema CurrentSchema { get; set; }


        public void SetupObjectExplorer()
        {
            GetSchema();
            ObjectExplorerDataSource = GetObjectExplorerDataSource();
        }

        private void GetSchema()
        {
            CurrentSchema = SQLServerInterface.GetSqlSchema();
        }

        private List<ObjectExplorerTreeListObject> GetObjectExplorerDataSource()
        {
            var sauce = new List<ObjectExplorerTreeListObject>();
            var index = 0;

            sauce.Add(new ObjectExplorerTreeListObject
            {
                Id = index++,
                Name = CurrentSchema.InstanceName,
                NodeType = ObjectExplorerTreeListObject.TypeOfNode.Instance,
                ParentId = index - 1
            });

            foreach (var db in CurrentSchema.Databases)
            {
                sauce.Add(new ObjectExplorerTreeListObject
                {
                    Id = index++,
                    Name = db.DataBaseName,
                    NodeType = ObjectExplorerTreeListObject.TypeOfNode.Database,
                    ParentId = 0
                });

                foreach (var obj in db.Tables)
                    sauce.Add(new ObjectExplorerTreeListObject
                    {
                        Id = index++,
                        Name = obj.TableFullName,
                        NodeType = ObjectExplorerTreeListObject.TypeOfNode.Table,
                        ParentId = sauce.First(r => r.Name == db.DataBaseName).Id
                    });

                foreach (var obj in db.Columns)
                    sauce.Add(new ObjectExplorerTreeListObject
                    {
                        Id = index++,
                        Name = obj.ColumnName,
                        NodeType = ObjectExplorerTreeListObject.TypeOfNode.Column,
                        ParentId = sauce.First(r => r.Name == obj.TableFullName).Id
                    });
            }


            return sauce;
        }
    }
}