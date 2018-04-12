namespace Databvase_Winforms.Modules
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
            this.treeListObjExp = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnFullName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnParentName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.lcgObjectExplorer = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.imageCollectionObjectExplorer = new DevExpress.Utils.ImageCollection(this.components);
            this.mvvmContextObjectExplorer = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lcObjectExplorer)).BeginInit();
            this.lcObjectExplorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListObjExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgObjectExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionObjectExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextObjectExplorer)).BeginInit();
            this.SuspendLayout();
            // 
            // lcObjectExplorer
            // 
            this.lcObjectExplorer.Controls.Add(this.treeListObjExp);
            this.lcObjectExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcObjectExplorer.Location = new System.Drawing.Point(0, 0);
            this.lcObjectExplorer.Name = "lcObjectExplorer";
            this.lcObjectExplorer.Root = this.lcgObjectExplorer;
            this.lcObjectExplorer.Size = new System.Drawing.Size(250, 600);
            this.lcObjectExplorer.TabIndex = 0;
            this.lcObjectExplorer.Text = "layoutControl1";
            // 
            // treeListObjExp
            // 
            this.treeListObjExp.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnFullName,
            this.treeListColumnType,
            this.treeListColumnName,
            this.treeListColumnParentName});
            this.treeListObjExp.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListObjExp.DataSource = null;
            this.treeListObjExp.Location = new System.Drawing.Point(12, 12);
            this.treeListObjExp.Name = "treeListObjExp";
            this.treeListObjExp.OptionsBehavior.Editable = false;
            this.treeListObjExp.OptionsBehavior.EditorShowMode = DevExpress.XtraTreeList.TreeListEditorShowMode.DoubleClick;
            this.treeListObjExp.SelectImageList = this.imageCollectionObjectExplorer;
            this.treeListObjExp.Size = new System.Drawing.Size(226, 576);
            this.treeListObjExp.TabIndex = 4;
            // 
            // treeListColumnFullName
            // 
            this.treeListColumnFullName.Caption = "Name";
            this.treeListColumnFullName.FieldName = "Name";
            this.treeListColumnFullName.Name = "treeListColumnFullName";
            this.treeListColumnFullName.OptionsColumn.ShowInCustomizationForm = false;
            this.treeListColumnFullName.Visible = true;
            this.treeListColumnFullName.VisibleIndex = 0;
            // 
            // treeListColumnType
            // 
            this.treeListColumnType.Caption = "Type";
            this.treeListColumnType.FieldName = "Type";
            this.treeListColumnType.Name = "treeListColumnType";
            this.treeListColumnType.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // treeListColumnName
            // 
            this.treeListColumnName.Caption = "Name";
            this.treeListColumnName.FieldName = "Name";
            this.treeListColumnName.Name = "treeListColumnName";
            this.treeListColumnName.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // treeListColumnParentName
            // 
            this.treeListColumnParentName.Caption = "Parent Name";
            this.treeListColumnParentName.FieldName = "ParentName";
            this.treeListColumnParentName.Name = "treeListColumnParentName";
            this.treeListColumnParentName.OptionsColumn.ShowInCustomizationForm = false;
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
            this.layoutControlItem1.Control = this.treeListObjExp;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(230, 580);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // imageCollectionObjectExplorer
            // 
            this.imageCollectionObjectExplorer.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionObjectExplorer.ImageStream")));
            this.imageCollectionObjectExplorer.InsertGalleryImage("addnewdatasource_16x16.png", "grayscaleimages/data/addnewdatasource_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("grayscaleimages/data/addnewdatasource_16x16.png"), 0);
            this.imageCollectionObjectExplorer.Images.SetKeyName(0, "addnewdatasource_16x16.png");
            this.imageCollectionObjectExplorer.InsertGalleryImage("database_16x16.png", "office2013/data/database_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/data/database_16x16.png"), 1);
            this.imageCollectionObjectExplorer.Images.SetKeyName(1, "database_16x16.png");
            this.imageCollectionObjectExplorer.InsertGalleryImage("grid_16x16.png", "office2013/grid/grid_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/grid/grid_16x16.png"), 2);
            this.imageCollectionObjectExplorer.Images.SetKeyName(2, "grid_16x16.png");
            this.imageCollectionObjectExplorer.InsertGalleryImage("groupfooter_16x16.png", "office2013/reports/groupfooter_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/reports/groupfooter_16x16.png"), 3);
            this.imageCollectionObjectExplorer.Images.SetKeyName(3, "groupfooter_16x16.png");
            // 
            // mvvmContextObjectExplorer
            // 
            this.mvvmContextObjectExplorer.ContainerControl = this;
            this.mvvmContextObjectExplorer.ViewModelType = typeof(Databvase_Winforms.View_Models.ObjectExplorerViewModel);
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
            ((System.ComponentModel.ISupportInitialize)(this.treeListObjExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgObjectExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionObjectExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextObjectExplorer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcObjectExplorer;
        private DevExpress.XtraLayout.LayoutControlGroup lcgObjectExplorer;
        private DevExpress.Utils.ImageCollection imageCollectionObjectExplorer;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContextObjectExplorer;
        private DevExpress.XtraTreeList.TreeList treeListObjExp;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnFullName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnParentName;
    }
}
