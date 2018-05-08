using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Databvase_Winforms.Modules
{
    /// <summary>
    /// This is a tree list file explorer that can be used to browse the folders on a remote computer where SQL Server is running.
    /// This is based off of the answer provided to this stack overflow question here, full credit goes to jfabrix and DevExpress
    /// https://stackoverflow.com/questions/20576995/folder-browser-dialog-from-remote-machine-perspective-like-the-one-ssms-uses
    /// https://documentation.devexpress.com/WindowsForms/325/Controls-and-Libraries/Tree-List/Examples/Data-Binding/How-to-Implement-Virtual-Mode-Dynamic-Loading-in-Unbound-Mode
    /// </summary>
    public partial class ServerFolderExplorer : DevExpress.XtraEditors.XtraUserControl
    {
        public ServerFolderExplorer()
        {
            InitializeComponent();
            HookUpEvents();
            GetServerDrives();
        }

        private void HookUpEvents()
        {
            treeListServerFolderExplorer.BeforeExpand += TreeListServerFolderExplorerOnBeforeExpand;
        }


        private void GetServerDrives()
        {
            var table = App.Connection.InstanceTracker.CurrentInstance.EnumAvailableMedia();

            foreach (DataRow row in table.Rows)
            {
                var node = new TreeListNode();
                node = treeListServerFolderExplorer.Nodes.Add(new object[] { row["Name"].ToString() + @"\" });
                node.HasChildren = true;
            }
        }

        private void TreeListServerFolderExplorerOnBeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            if (e.Node.HasChildren && e.Node.Nodes.Count < 1)
            {
                DataSet dataSet = App.Connection.InstanceTracker.CurrentInstance.ConnectionContext.ExecuteWithResults(
                    string.Format("exec xp_dirtree '{0}', 1, 1",
                        GetFullPathForTreeNode(e.Node, @"\")));

                dataSet.Tables[0].DefaultView.Sort = "file ASC";

                DataTable dataTable = dataSet.Tables[0].DefaultView.ToTable();

                foreach (DataRow row in dataTable.Rows)
                {
                    var node = new TreeListNode();
                    node = e.Node.Nodes.Add(new object[] { row["subdirectory"].ToString() });
                    if (row["file"].ToString() != "1")
                    {
                        node.HasChildren = true;
                    }

                }

            }

        }


        private string GetFullPathForTreeNode(TreeListNode node, string pathSeperator)
        {
            if (node == null) return "";
            string result = "";
            while (node != null)
            {
                result = node.GetDisplayText(0) + pathSeperator  + result;
                node = node.ParentNode;
            }
            return result;
        }


    }
}
