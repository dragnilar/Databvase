using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Mvvm.DataAnnotations;
using LWSqlQueryTool_Winforms.DAL;
using LWSqlQueryTool_Winforms.Models;
using LWSqlQueryTool_Winforms.Services;

namespace LWSqlQueryTool_Winforms.View_Models
{
    [POCOViewModel()]
    public class ObjectExplorerViewModel
    {
        public virtual List<ObjectExplorerTreeListObject> ObjectExplorerDataSource { get; set; }
        public virtual SQLSchema CurrentSchema { get; set; }

        public ObjectExplorerViewModel()
        {
            SetupObjectExplorer();
        }


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
                Name = CurrentSchema.DatabaseName,
                NodeType = ObjectExplorerTreeListObject.TypeOfNode.Database,
                ParentId = index - 1
            });



            foreach (var obj in CurrentSchema.Tables)
            {
                sauce.Add(new ObjectExplorerTreeListObject
                {
                    Id = index++,
                    Name = obj.TableName,
                    NodeType = ObjectExplorerTreeListObject.TypeOfNode.Table,
                    ParentId = sauce.First(r => r.Name == obj.TableCatalog).Id
                });
            }

            foreach (var obj in CurrentSchema.Columns)
            {
                sauce.Add(new ObjectExplorerTreeListObject
                {
                    Id = index++,
                    Name = obj.ColumnName,
                    NodeType = ObjectExplorerTreeListObject.TypeOfNode.Column,
                    ParentId = sauce.First(r => r.Name == obj.TableName).Id
                });
            }

            return sauce;
        }
    }
}
