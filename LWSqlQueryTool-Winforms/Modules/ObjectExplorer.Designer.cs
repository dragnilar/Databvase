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
            this.lcObjectExplorer = new DevExpress.XtraLayout.LayoutControl();
            this.lcgObjectExplorer = new DevExpress.XtraLayout.LayoutControlGroup();
            this.treeListObjectExplorer = new DevExpress.XtraTreeList.TreeList();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcObjectExplorer)).BeginInit();
            this.lcObjectExplorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgObjectExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListObjectExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcObjectExplorer
            // 
            this.lcObjectExplorer.Controls.Add(this.treeListObjectExplorer);
            this.lcObjectExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcObjectExplorer.Location = new System.Drawing.Point(0, 0);
            this.lcObjectExplorer.Name = "lcObjectExplorer";
            this.lcObjectExplorer.Root = this.lcgObjectExplorer;
            this.lcObjectExplorer.Size = new System.Drawing.Size(195, 600);
            this.lcObjectExplorer.TabIndex = 0;
            this.lcObjectExplorer.Text = "layoutControl1";
            // 
            // lcgObjectExplorer
            // 
            this.lcgObjectExplorer.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgObjectExplorer.GroupBordersVisible = false;
            this.lcgObjectExplorer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgObjectExplorer.Name = "lcgObjectExplorer";
            this.lcgObjectExplorer.Size = new System.Drawing.Size(195, 600);
            this.lcgObjectExplorer.TextVisible = false;
            // 
            // treeListObjectExplorer
            // 
            this.treeListObjectExplorer.DataSource = null;
            this.treeListObjectExplorer.Location = new System.Drawing.Point(12, 12);
            this.treeListObjectExplorer.Name = "treeListObjectExplorer";
            this.treeListObjectExplorer.Size = new System.Drawing.Size(171, 576);
            this.treeListObjectExplorer.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.treeListObjectExplorer;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(175, 580);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ObjectExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcObjectExplorer);
            this.Name = "ObjectExplorer";
            this.Size = new System.Drawing.Size(195, 600);
            ((System.ComponentModel.ISupportInitialize)(this.lcObjectExplorer)).EndInit();
            this.lcObjectExplorer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgObjectExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListObjectExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcObjectExplorer;
        private DevExpress.XtraLayout.LayoutControlGroup lcgObjectExplorer;
        private DevExpress.XtraTreeList.TreeList treeListObjectExplorer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
