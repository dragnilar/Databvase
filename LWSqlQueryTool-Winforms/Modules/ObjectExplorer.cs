using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using LWSqlQueryTool_Winforms.Models;
using LWSqlQueryTool_Winforms.Services;
using LWSqlQueryTool_Winforms.View_Models;

namespace LWSqlQueryTool_Winforms.Modules
{
    public partial class ObjectExplorer : DevExpress.XtraEditors.XtraUserControl
    {
        public SQLSchema CurrentSchema = null;

        public ObjectExplorer()
        {
            InitializeComponent();
            SetupObjectExplorer();
            if (!mvvmContextObjectExplorer.IsDesignMode)
                InitializeBindings();
        }

        public void SetupObjectExplorer()
        {
            GetSchema();
            treeListObjectExplorer.DataSource = SetupDataSource();
        }

        private void GetSchema()
        {
            CurrentSchema = SchemaService.GetSchema();
        }



        private List<ObjectExplorerTreeListObject> SetupDataSource()
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
                    ParentId = sauce.First(r=>r.Name == obj.TableCatalog).Id
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

        void InitializeBindings()
        {
            var fluent = mvvmContextObjectExplorer.OfType<ObjectExplorerViewModel>();
        }
    }
}
