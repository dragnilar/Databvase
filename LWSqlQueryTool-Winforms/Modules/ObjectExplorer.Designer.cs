namespace LWSqlQueryTool_Winforms.Modules
{
    partial class ObjectExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectExplorer));
            this.lcObjectExplorer = new DevExpress.XtraLayout.LayoutControl();
            this.treeListObjectExplorer = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.lcgObjectExplorer = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.imageCollectionObjectExplorer = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lcObjectExplorer)).BeginInit();
            this.lcObjectExplorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListObjectExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgObjectExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionObjectExplorer)).BeginInit();
            this.SuspendLayout();
            // 
            // lcObjectExplorer
            // 
            this.lcObjectExplorer.Controls.Add(this.treeListObjectExplorer);
            this.lcObjectExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcObjectExplorer.Location = new System.Drawing.Point(0, 0);
            this.lcObjectExplorer.Name = "lcObjectExplorer";
            this.lcObjectExplorer.Root = this.lcgObjectExplorer;
            this.lcObjectExplorer.Size = new System.Drawing.Size(250, 600);
            this.lcObjectExplorer.TabIndex = 0;
            this.lcObjectExplorer.Text = "layoutControl1";
            // 
            // treeListObjectExplorer
            // 
            this.treeListObjectExplorer.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnName,
            this.treeListColumnType});
            this.treeListObjectExplorer.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListObjectExplorer.DataSource = null;
            this.treeListObjectExplorer.KeyFieldName = "Id";
            this.treeListObjectExplorer.Location = new System.Drawing.Point(12, 12);
            this.treeListObjectExplorer.Name = "treeListObjectExplorer";
            this.treeListObjectExplorer.ParentFieldName = "ParentId";
            this.treeListObjectExplorer.SelectImageList = this.imageCollectionObjectExplorer;
            this.treeListObjectExplorer.Size = new System.Drawing.Size(226, 576);
            this.treeListObjectExplorer.TabIndex = 4;
            // 
            // treeListColumnName
            // 
            this.treeListColumnName.Caption = "Name";
            this.treeListColumnName.FieldName = "Name";
            this.treeListColumnName.Name = "treeListColumnName";
            this.treeListColumnName.OptionsColumn.ReadOnly = true;
            this.treeListColumnName.Visible = true;
            this.treeListColumnName.VisibleIndex = 0;
            // 
            // treeListColumnType
            // 
            this.treeListColumnType.Caption = "Type";
            this.treeListColumnType.FieldName = "NodeType";
            this.treeListColumnType.Name = "treeListColumnType";
            this.treeListColumnType.OptionsColumn.ReadOnly = true;
            // 
            // lcgObjectExplorer
            // 
            this.lcgObjectExplorer.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgObjectExplorer.GroupBordersVisible = false;
            this.lcgObjectExplorer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgObjectExplorer.Name = "lcgObjectExplorer";
            this.lcgObjectExplorer.Size = new System.Drawing.Size(250, 600);
            this.lcgObjectExplorer.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.treeListObjectExplorer;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(230, 580);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // imageCollectionObjectExplorer
            // 
            this.imageCollectionObjectExplorer.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionObjectExplorer.ImageStream")));
            this.imageCollectionObjectExplorer.InsertGalleryImage("database_16x16.png", "office2013/data/database_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/data/database_16x16.png"), 0);
            this.imageCollectionObjectExplorer.Images.SetKeyName(0, "database_16x16.png");
            this.imageCollectionObjectExplorer.InsertGalleryImage("grid_16x16.png", "office2013/grid/grid_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/grid/grid_16x16.png"), 1);
            this.imageCollectionObjectExplorer.Images.SetKeyName(1, "grid_16x16.png");
            this.imageCollectionObjectExplorer.InsertGalleryImage("groupfooter_16x16.png", "office2013/reports/groupfooter_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/reports/groupfooter_16x16.png"), 2);
            this.imageCollectionObjectExplorer.Images.SetKeyName(2, "groupfooter_16x16.png");
            // 
            // ObjectExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcObjectExplorer);
            this.Name = "ObjectExplorer";
            this.Size = new System.Drawing.Size(250, 600);
            ((System.ComponentModel.ISupportInitialize)(this.lcObjectExplorer)).EndInit();
            this.lcObjectExplorer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListObjectExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgObjectExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionObjectExplorer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcObjectExplorer;
        private DevExpress.XtraLayout.LayoutControlGroup lcgObjectExplorer;
        private DevExpress.XtraTreeList.TreeList treeListObjectExplorer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnType;
        private DevExpress.Utils.ImageCollection imageCollectionObjectExplorer;
    }
}
