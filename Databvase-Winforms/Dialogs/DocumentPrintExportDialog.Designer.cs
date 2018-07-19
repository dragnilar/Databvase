namespace Databvase_Winforms.Dialogs
{
    partial class DocumentPrintExportDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentPrintExportDialog));
            this.lcPrintExportDialog = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlPrintExport = new DevExpress.XtraGrid.GridControl();
            this.gridViewPrintExport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcgPrintExportDialog = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciPrintExportGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciOKButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCancelButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcPrintExportDialog)).BeginInit();
            this.lcPrintExportDialog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrintExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPrintExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrintExportDialog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrintExportGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOKButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // lcPrintExportDialog
            // 
            this.lcPrintExportDialog.Controls.Add(this.simpleButtonCancel);
            this.lcPrintExportDialog.Controls.Add(this.simpleButtonOK);
            this.lcPrintExportDialog.Controls.Add(this.gridControlPrintExport);
            this.lcPrintExportDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcPrintExportDialog.Location = new System.Drawing.Point(0, 0);
            this.lcPrintExportDialog.Name = "lcPrintExportDialog";
            this.lcPrintExportDialog.Root = this.lcgPrintExportDialog;
            this.lcPrintExportDialog.Size = new System.Drawing.Size(458, 423);
            this.lcPrintExportDialog.TabIndex = 0;
            this.lcPrintExportDialog.Text = "layoutControl1";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.ImageOptions.ImageUri.Uri = "Cancel;Size16x16;Office2013";
            this.simpleButtonCancel.Location = new System.Drawing.Point(269, 379);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(177, 22);
            this.simpleButtonCancel.StyleController = this.lcPrintExportDialog;
            this.simpleButtonCancel.TabIndex = 6;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.ImageOptions.ImageUri.Uri = "Apply;Size16x16;Office2013";
            this.simpleButtonOK.Location = new System.Drawing.Point(12, 379);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(177, 22);
            this.simpleButtonOK.StyleController = this.lcPrintExportDialog;
            this.simpleButtonOK.TabIndex = 5;
            this.simpleButtonOK.Text = "OK";
            // 
            // gridControlPrintExport
            // 
            this.gridControlPrintExport.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControlPrintExport.Location = new System.Drawing.Point(12, 12);
            this.gridControlPrintExport.MainView = this.gridViewPrintExport;
            this.gridControlPrintExport.Name = "gridControlPrintExport";
            this.gridControlPrintExport.Size = new System.Drawing.Size(434, 353);
            this.gridControlPrintExport.TabIndex = 4;
            this.gridControlPrintExport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPrintExport});
            // 
            // gridViewPrintExport
            // 
            this.gridViewPrintExport.GridControl = this.gridControlPrintExport;
            this.gridViewPrintExport.Name = "gridViewPrintExport";
            this.gridViewPrintExport.OptionsBehavior.Editable = false;
            this.gridViewPrintExport.OptionsCustomization.AllowGroup = false;
            this.gridViewPrintExport.OptionsView.ShowColumnHeaders = false;
            this.gridViewPrintExport.OptionsView.ShowGroupPanel = false;
            // 
            // lcgPrintExportDialog
            // 
            this.lcgPrintExportDialog.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgPrintExportDialog.GroupBordersVisible = false;
            this.lcgPrintExportDialog.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciPrintExportGrid,
            this.lciOKButton,
            this.lciCancelButton,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.emptySpaceItem2});
            this.lcgPrintExportDialog.Name = "lcgPrintExportDialog";
            this.lcgPrintExportDialog.Size = new System.Drawing.Size(458, 423);
            this.lcgPrintExportDialog.TextVisible = false;
            // 
            // lciPrintExportGrid
            // 
            this.lciPrintExportGrid.Control = this.gridControlPrintExport;
            this.lciPrintExportGrid.Location = new System.Drawing.Point(0, 0);
            this.lciPrintExportGrid.Name = "lciPrintExportGrid";
            this.lciPrintExportGrid.Size = new System.Drawing.Size(438, 357);
            this.lciPrintExportGrid.TextSize = new System.Drawing.Size(0, 0);
            this.lciPrintExportGrid.TextVisible = false;
            // 
            // lciOKButton
            // 
            this.lciOKButton.Control = this.simpleButtonOK;
            this.lciOKButton.Location = new System.Drawing.Point(0, 367);
            this.lciOKButton.Name = "lciOKButton";
            this.lciOKButton.Size = new System.Drawing.Size(181, 26);
            this.lciOKButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciOKButton.TextVisible = false;
            // 
            // lciCancelButton
            // 
            this.lciCancelButton.Control = this.simpleButtonCancel;
            this.lciCancelButton.Location = new System.Drawing.Point(257, 367);
            this.lciCancelButton.Name = "lciCancelButton";
            this.lciCancelButton.Size = new System.Drawing.Size(181, 26);
            this.lciCancelButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciCancelButton.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(181, 367);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(76, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 357);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(438, 10);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 393);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(438, 10);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // DocumentPrintExportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 423);
            this.Controls.Add(this.lcPrintExportDialog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DocumentPrintExportDialog";
            this.Text = "Select A Document To Print";
            ((System.ComponentModel.ISupportInitialize)(this.lcPrintExportDialog)).EndInit();
            this.lcPrintExportDialog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrintExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPrintExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrintExportDialog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrintExportGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOKButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcPrintExportDialog;
        private DevExpress.XtraLayout.LayoutControlGroup lcgPrintExportDialog;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private DevExpress.XtraGrid.GridControl gridControlPrintExport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPrintExport;
        private DevExpress.XtraLayout.LayoutControlItem lciPrintExportGrid;
        private DevExpress.XtraLayout.LayoutControlItem lciOKButton;
        private DevExpress.XtraLayout.LayoutControlItem lciCancelButton;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}