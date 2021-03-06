﻿using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Modules;
using Databvase_Winforms.View_Models;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Databvase_Winforms.Dialogs
{
    /// <summary>
    /// This is a tree list file explorer that can be used to browse the folders on a remote computer where SQL Server is running.
    /// This is based off of the answer provided to this stack overflow question here, full credit goes to jfabrix and DevExpress
    /// https://stackoverflow.com/questions/20576995/folder-browser-dialog-from-remote-machine-perspective-like-the-one-ssms-uses
    /// https://documentation.devexpress.com/WindowsForms/325/Controls-and-Libraries/Tree-List/Examples/Data-Binding/How-to-Implement-Virtual-Mode-Dynamic-Loading-in-Unbound-Mode
    /// </summary>
    public partial class ServerFolderExplorer : DevExpress.XtraEditors.XtraForm
    {
        //TODO - Reactor more of this into the view model
        public ServerFolderExplorer()
        {
            InitializeComponent();
            HookUpEvents();
            InitializeServerTreeAndGetDrives();
            if (!mvvmContextServerFolderExplorer.IsDesignMode)
                InitializeBindings();
        }

        private void HookUpEvents()
        {
            treeListServerFolderExplorer.BeforeExpand += TreeListServerFolderExplorerOnBeforeExpand;
            treeListServerFolderExplorer.MouseDown += TreeListServerFolderExplorerOnMouseDown;
            Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            simpleButtonSave.Enabled = false;
        }

        private void InitializeServerTreeAndGetDrives()
        {
            var table = App.Connection.CurrentServer.EnumAvailableMedia();

            foreach (DataRow row in table.Rows)
            {
                var node = new TreeListNode();
                var driveName = row["Name"];
                node = treeListServerFolderExplorer.Nodes.Add(driveName, driveName, false);
                node.HasChildren = true;
            }
        }

        #region On Demand Data Methods

        private void TreeListServerFolderExplorerOnBeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            if (e.Node.HasChildren && e.Node.Nodes.Count < 1)
            {
                //TODO - probably should move this to the DAL
                var fullPath = GetFullPathForTreeNode(e.Node, @"\");
                var xpDirTreeCommand = $"exec xp_dirtree '{fullPath}', 1, 1";
                DataSet dataSet = App.Connection.CurrentServer.ConnectionContext.ExecuteWithResults(xpDirTreeCommand);

                dataSet.Tables[0].DefaultView.Sort = "file ASC";

                DataTable dataTable = dataSet.Tables[0].DefaultView.ToTable();

                foreach (DataRow row in dataTable.Rows)
                {
                    CreateSubDirectoryNode(e, row, fullPath);
                }
            }

        }

        private void CreateSubDirectoryNode(BeforeExpandEventArgs e, DataRow row, string fullPath)
        {
            var subDirectory = row["subdirectory"].ToString();
            var nodeIsAFile = IsThisAFile(row["file"].ToString());
            if (nodeIsAFile)
            {
                if (!IsThisABackupFile(fullPath + subDirectory)) return;
                var node = e.Node.Nodes.Add(subDirectory, fullPath + subDirectory, nodeIsAFile);
                node.HasChildren = false;
            }
            else
            {
                var node = e.Node.Nodes.Add(subDirectory, fullPath + subDirectory, nodeIsAFile);
                node.HasChildren = true;
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

        private bool IsThisAFile(string fileStatus)
        {
            return fileStatus == "1";
        }

        private bool IsThisABackupFile(string filePath)
        {
            var extension = Path.GetExtension(filePath);

            return extension?.ToLower() == ".bak" || extension?.ToLower() == ".trn";
        }

        #endregion


        private void TreeListServerFolderExplorerOnMouseDown(object sender, MouseEventArgs e)
        {
            var treeList = sender as TreeList;
            var info = treeList?.CalcHitInfo(e.Location);
            if (info?.Node != null)
            {
                CheckIfNodeIsFileAndPopulateFileStrings(info.Node);
            }
            
        }

        private void CheckIfNodeIsFileAndPopulateFileStrings(TreeListNode infoNode)
        {
            string selectedFolderPath;

            if (infoNode.ParentNode == null)
            {
                selectedFolderPath = infoNode.GetValue(1) + @"\";
            }
            else
            {
                selectedFolderPath = infoNode.GetValue(1).ToString();
            }

            var isFile = (bool)infoNode.GetValue(2);
            var selectedBackupFilePath = isFile ? infoNode.GetValue(0).ToString() : string.Empty;

            new ServerExplorerNodeChangedMessage(selectedFolderPath, selectedBackupFilePath);
        }

        void InitializeBindings()
        {
            var fluent = mvvmContextServerFolderExplorer.OfType<ServerFolderExplorerViewModel>();
            fluent.SetBinding(textEditFileName, x => x.Text, y => y.SelectedBackupFilePath);
            fluent.SetBinding(textEditSelectedPath, x => x.Text, y => y.SelectedFolderPath);
            fluent.BindCommand(simpleButtonSave, x=>x.SaveAndClose());
            fluent.BindCommand(simpleButtonCancel, x=>x.Close());
            fluent.SetTrigger(x => x.State, state =>
            {
                switch (state)
                {
                    case ServerFolderExplorerViewModel.WindowState.Open:
                        simpleButtonSave.Enabled = false;
                        break;
                    case ServerFolderExplorerViewModel.WindowState.Close:
                        Close();
                        break;
                    case ServerFolderExplorerViewModel.WindowState.ReadyToSave:
                        simpleButtonSave.Enabled = true;
                        break;
                }
            });
        }
    }
}
