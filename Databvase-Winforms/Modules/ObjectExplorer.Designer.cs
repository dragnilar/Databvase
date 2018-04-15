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
            this.treeListColumnData = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollectionObjectExplorer = new DevExpress.Utils.ImageCollection(this.components);
            this.lcgObjectExplorer = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.mvvmContextObjectExplorer = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.popupMenuObjectExplorer = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItemCopy = new DevExpress.XtraBars.BarButtonItem();
            this.barManagerObjectExplorer = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItemGenerateSelectAll = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuTable = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lcObjectExplorer)).BeginInit();
            this.lcObjectExplorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListObjExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionObjectExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgObjectExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextObjectExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuObjectExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerObjectExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuTable)).BeginInit();
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
            this.treeListColumnParentName,
            this.treeListColumnData});
            this.treeListObjExp.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListObjExp.DataSource = null;
            this.treeListObjExp.Location = new System.Drawing.Point(12, 12);
            this.treeListObjExp.Name = "treeListObjExp";
            this.treeListObjExp.OptionsBehavior.EditorShowMode = DevExpress.XtraTreeList.TreeListEditorShowMode.DoubleClick;
            this.treeListObjExp.OptionsBehavior.ReadOnly = true;
            this.treeListObjExp.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListObjExp.OptionsView.ShowFirstLines = false;
            this.treeListObjExp.OptionsView.ShowHorzLines = false;
            this.treeListObjExp.OptionsView.ShowVertLines = false;
            this.treeListObjExp.Size = new System.Drawing.Size(226, 576);
            this.treeListObjExp.StateImageList = this.imageCollectionObjectExplorer;
            this.treeListObjExp.TabIndex = 4;
            // 
            // treeListColumnFullName
            // 
            this.treeListColumnFullName.Caption = "Name";
            this.treeListColumnFullName.FieldName = "Name";
            this.treeListColumnFullName.Name = "treeListColumnFullName";
            this.treeListColumnFullName.OptionsColumn.ShowInCustomizationForm = false;
            this.treeListColumnFullName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Object;
            this.treeListColumnFullName.Visible = true;
            this.treeListColumnFullName.VisibleIndex = 0;
            // 
            // treeListColumnType
            // 
            this.treeListColumnType.Caption = "Type";
            this.treeListColumnType.FieldName = "Type";
            this.treeListColumnType.Name = "treeListColumnType";
            this.treeListColumnType.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Object;
            // 
            // treeListColumnName
            // 
            this.treeListColumnName.Caption = "Name";
            this.treeListColumnName.FieldName = "Name";
            this.treeListColumnName.Name = "treeListColumnName";
            this.treeListColumnName.OptionsColumn.ShowInCustomizationForm = false;
            this.treeListColumnName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Object;
            // 
            // treeListColumnParentName
            // 
            this.treeListColumnParentName.Caption = "Parent Name";
            this.treeListColumnParentName.FieldName = "ParentName";
            this.treeListColumnParentName.Name = "treeListColumnParentName";
            this.treeListColumnParentName.OptionsColumn.ShowInCustomizationForm = false;
            this.treeListColumnParentName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Object;
            // 
            // treeListColumnData
            // 
            this.treeListColumnData.Caption = "Data";
            this.treeListColumnData.FieldName = "Data";
            this.treeListColumnData.Name = "treeListColumnData";
            this.treeListColumnData.OptionsColumn.ShowInCustomizationForm = false;
            this.treeListColumnData.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Object;
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
            // mvvmContextObjectExplorer
            // 
            this.mvvmContextObjectExplorer.ContainerControl = this;
            this.mvvmContextObjectExplorer.ViewModelType = typeof(Databvase_Winforms.View_Models.ObjectExplorerViewModel);
            // 
            // popupMenuObjectExplorer
            // 
            this.popupMenuObjectExplorer.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCopy)});
            this.popupMenuObjectExplorer.Manager = this.barManagerObjectExplorer;
            this.popupMenuObjectExplorer.Name = "popupMenuObjectExplorer";
            // 
            // barButtonItemCopy
            // 
            this.barButtonItemCopy.Caption = "Copy Text To Clipboard";
            this.barButtonItemCopy.Id = 0;
            this.barButtonItemCopy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemCopy.ImageOptions.Image")));
            this.barButtonItemCopy.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemCopy.ImageOptions.LargeImage")));
            this.barButtonItemCopy.Name = "barButtonItemCopy";
            // 
            // barManagerObjectExplorer
            // 
            this.barManagerObjectExplorer.DockControls.Add(this.barDockControlTop);
            this.barManagerObjectExplorer.DockControls.Add(this.barDockControlBottom);
            this.barManagerObjectExplorer.DockControls.Add(this.barDockControlLeft);
            this.barManagerObjectExplorer.DockControls.Add(this.barDockControlRight);
            this.barManagerObjectExplorer.Form = this;
            this.barManagerObjectExplorer.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemCopy,
            this.barButtonItemGenerateSelectAll});
            this.barManagerObjectExplorer.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManagerObjectExplorer;
            this.barDockControlTop.Size = new System.Drawing.Size(250, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 600);
            this.barDockControlBottom.Manager = this.barManagerObjectExplorer;
            this.barDockControlBottom.Size = new System.Drawing.Size(250, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManagerObjectExplorer;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 600);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(250, 0);
            this.barDockControlRight.Manager = this.barManagerObjectExplorer;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 600);
            // 
            // barButtonItemGenerateSelectAll
            // 
            this.barButtonItemGenerateSelectAll.Caption = "Generate Select Statement";
            this.barButtonItemGenerateSelectAll.Id = 2;
            this.barButtonItemGenerateSelectAll.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemGenerateSelectAll.ImageOptions.Image")));
            this.barButtonItemGenerateSelectAll.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemGenerateSelectAll.ImageOptions.LargeImage")));
            this.barButtonItemGenerateSelectAll.Name = "barButtonItemGenerateSelectAll";
            // 
            // popupMenuTable
            // 
            this.popupMenuTable.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemGenerateSelectAll)});
            this.popupMenuTable.Manager = this.barManagerObjectExplorer;
            this.popupMenuTable.Name = "popupMenuTable";
            // 
            // ObjectExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcObjectExplorer);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ObjectExplorer";
            this.Size = new System.Drawing.Size(250, 600);
            ((System.ComponentModel.ISupportInitialize)(this.lcObjectExplorer)).EndInit();
            this.lcObjectExplorer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListObjExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionObjectExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgObjectExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextObjectExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuObjectExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerObjectExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private DevExpress.XtraBars.PopupMenu popupMenuObjectExplorer;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManagerObjectExplorer;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCopy;
        private DevExpress.XtraBars.BarButtonItem barButtonItemGenerateSelectAll;
        private DevExpress.XtraBars.PopupMenu popupMenuTable;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnData;
    }
}
