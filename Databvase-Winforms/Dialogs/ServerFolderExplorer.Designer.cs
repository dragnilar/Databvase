using Databvase_Winforms.View_Models;

namespace Databvase_Winforms.Dialogs
{
    partial class ServerFolderExplorer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerFolderExplorer));
            this.lcServerFolderExplorer = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.textEditFileName = new DevExpress.XtraEditors.TextEdit();
            this.textEditSelectedPath = new DevExpress.XtraEditors.TextEdit();
            this.treeListServerFolderExplorer = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnFullPath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnIsFile = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.lcgServerFolderExplorer = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciServerFolderExplorerTree = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectedPath = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFileName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciOKButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.mvvmContextServerFolderExplorer = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lcServerFolderExplorer)).BeginInit();
            this.lcServerFolderExplorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSelectedPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListServerFolderExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgServerFolderExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciServerFolderExplorerTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectedPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOKButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextServerFolderExplorer)).BeginInit();
            this.SuspendLayout();
            // 
            // lcServerFolderExplorer
            // 
            this.lcServerFolderExplorer.Controls.Add(this.simpleButtonCancel);
            this.lcServerFolderExplorer.Controls.Add(this.simpleButtonOK);
            this.lcServerFolderExplorer.Controls.Add(this.textEditFileName);
            this.lcServerFolderExplorer.Controls.Add(this.textEditSelectedPath);
            this.lcServerFolderExplorer.Controls.Add(this.treeListServerFolderExplorer);
            this.lcServerFolderExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcServerFolderExplorer.Location = new System.Drawing.Point(0, 0);
            this.lcServerFolderExplorer.Name = "lcServerFolderExplorer";
            this.lcServerFolderExplorer.Root = this.lcgServerFolderExplorer;
            this.lcServerFolderExplorer.Size = new System.Drawing.Size(385, 442);
            this.lcServerFolderExplorer.TabIndex = 0;
            this.lcServerFolderExplorer.Text = "layoutControl1";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(287, 408);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(73, 22);
            this.simpleButtonCancel.StyleController = this.lcServerFolderExplorer;
            this.simpleButtonCancel.TabIndex = 8;
            this.simpleButtonCancel.Text = "Cancel";
            this.simpleButtonCancel.Visible = false;
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Location = new System.Drawing.Point(179, 408);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(81, 22);
            this.simpleButtonOK.StyleController = this.lcServerFolderExplorer;
            this.simpleButtonOK.TabIndex = 7;
            this.simpleButtonOK.Text = "OK";
            this.simpleButtonOK.Visible = false;
            // 
            // textEditFileName
            // 
            this.textEditFileName.Location = new System.Drawing.Point(88, 384);
            this.textEditFileName.Name = "textEditFileName";
            this.textEditFileName.Size = new System.Drawing.Size(285, 20);
            this.textEditFileName.StyleController = this.lcServerFolderExplorer;
            this.textEditFileName.TabIndex = 6;
            // 
            // textEditSelectedPath
            // 
            this.textEditSelectedPath.Location = new System.Drawing.Point(88, 360);
            this.textEditSelectedPath.Name = "textEditSelectedPath";
            this.textEditSelectedPath.Properties.ReadOnly = true;
            this.textEditSelectedPath.Size = new System.Drawing.Size(285, 20);
            this.textEditSelectedPath.StyleController = this.lcServerFolderExplorer;
            this.textEditSelectedPath.TabIndex = 5;
            // 
            // treeListServerFolderExplorer
            // 
            this.treeListServerFolderExplorer.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnName,
            this.treeListColumnFullPath,
            this.treeListColumnIsFile});
            this.treeListServerFolderExplorer.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListServerFolderExplorer.DataSource = null;
            this.treeListServerFolderExplorer.Location = new System.Drawing.Point(12, 28);
            this.treeListServerFolderExplorer.Name = "treeListServerFolderExplorer";
            this.treeListServerFolderExplorer.OptionsBehavior.Editable = false;
            this.treeListServerFolderExplorer.Size = new System.Drawing.Size(361, 328);
            this.treeListServerFolderExplorer.TabIndex = 4;
            // 
            // treeListColumnName
            // 
            this.treeListColumnName.Caption = "Name";
            this.treeListColumnName.FieldName = "Name";
            this.treeListColumnName.Name = "treeListColumnName";
            this.treeListColumnName.Visible = true;
            this.treeListColumnName.VisibleIndex = 0;
            // 
            // treeListColumnFullPath
            // 
            this.treeListColumnFullPath.Caption = "FullPath";
            this.treeListColumnFullPath.FieldName = "FullPath";
            this.treeListColumnFullPath.Name = "treeListColumnFullPath";
            this.treeListColumnFullPath.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // treeListColumnIsFile
            // 
            this.treeListColumnIsFile.Caption = "IsFile";
            this.treeListColumnIsFile.FieldName = "IsFile";
            this.treeListColumnIsFile.Name = "treeListColumnIsFile";
            this.treeListColumnIsFile.OptionsColumn.AllowEdit = false;
            this.treeListColumnIsFile.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // lcgServerFolderExplorer
            // 
            this.lcgServerFolderExplorer.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgServerFolderExplorer.GroupBordersVisible = false;
            this.lcgServerFolderExplorer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciServerFolderExplorerTree,
            this.lciSelectedPath,
            this.lciFileName,
            this.lciOKButton,
            this.lciCancel,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3});
            this.lcgServerFolderExplorer.Name = "lcgServerFolderExplorer";
            this.lcgServerFolderExplorer.Size = new System.Drawing.Size(385, 442);
            this.lcgServerFolderExplorer.TextVisible = false;
            // 
            // lciServerFolderExplorerTree
            // 
            this.lciServerFolderExplorerTree.Control = this.treeListServerFolderExplorer;
            this.lciServerFolderExplorerTree.Location = new System.Drawing.Point(0, 0);
            this.lciServerFolderExplorerTree.Name = "lciServerFolderExplorerTree";
            this.lciServerFolderExplorerTree.Size = new System.Drawing.Size(365, 348);
            this.lciServerFolderExplorerTree.Text = "Select the file:";
            this.lciServerFolderExplorerTree.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciServerFolderExplorerTree.TextSize = new System.Drawing.Size(73, 13);
            // 
            // lciSelectedPath
            // 
            this.lciSelectedPath.Control = this.textEditSelectedPath;
            this.lciSelectedPath.Location = new System.Drawing.Point(0, 348);
            this.lciSelectedPath.Name = "lciSelectedPath";
            this.lciSelectedPath.Size = new System.Drawing.Size(365, 24);
            this.lciSelectedPath.Text = "Selected Path: ";
            this.lciSelectedPath.TextSize = new System.Drawing.Size(73, 13);
            // 
            // lciFileName
            // 
            this.lciFileName.Control = this.textEditFileName;
            this.lciFileName.Location = new System.Drawing.Point(0, 372);
            this.lciFileName.Name = "lciFileName";
            this.lciFileName.Size = new System.Drawing.Size(365, 24);
            this.lciFileName.Text = "File Name: ";
            this.lciFileName.TextSize = new System.Drawing.Size(73, 13);
            // 
            // lciOKButton
            // 
            this.lciOKButton.Control = this.simpleButtonOK;
            this.lciOKButton.Location = new System.Drawing.Point(167, 396);
            this.lciOKButton.Name = "lciOKButton";
            this.lciOKButton.Size = new System.Drawing.Size(85, 26);
            this.lciOKButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciOKButton.TextVisible = false;
            // 
            // lciCancel
            // 
            this.lciCancel.Control = this.simpleButtonCancel;
            this.lciCancel.Location = new System.Drawing.Point(275, 396);
            this.lciCancel.Name = "lciCancel";
            this.lciCancel.Size = new System.Drawing.Size(77, 26);
            this.lciCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciCancel.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 396);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(167, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(252, 396);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(23, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(352, 396);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(13, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // mvvmContextServerFolderExplorer
            // 
            this.mvvmContextServerFolderExplorer.ContainerControl = this;
            this.mvvmContextServerFolderExplorer.ViewModelType = typeof(ServerFolderExplorerViewModel);
            // 
            // ServerFolderExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 442);
            this.Controls.Add(this.lcServerFolderExplorer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(401, 481);
            this.Name = "ServerFolderExplorer";
            this.Text = "Locate Database Files - ";
            ((System.ComponentModel.ISupportInitialize)(this.lcServerFolderExplorer)).EndInit();
            this.lcServerFolderExplorer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSelectedPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListServerFolderExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgServerFolderExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciServerFolderExplorerTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectedPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOKButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextServerFolderExplorer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcServerFolderExplorer;
        private DevExpress.XtraLayout.LayoutControlGroup lcgServerFolderExplorer;
        private DevExpress.XtraTreeList.TreeList treeListServerFolderExplorer;
        private DevExpress.XtraLayout.LayoutControlItem lciServerFolderExplorerTree;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private DevExpress.XtraEditors.TextEdit textEditFileName;
        private DevExpress.XtraEditors.TextEdit textEditSelectedPath;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectedPath;
        private DevExpress.XtraLayout.LayoutControlItem lciFileName;
        private DevExpress.XtraLayout.LayoutControlItem lciOKButton;
        private DevExpress.XtraLayout.LayoutControlItem lciCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnFullPath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnIsFile;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContextServerFolderExplorer;
    }
}
