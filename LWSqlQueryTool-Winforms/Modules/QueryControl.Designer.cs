namespace LWSqlQueryTool_Winforms.Modules
{
    partial class QueryControl
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
            this.layoutControlQueryControl = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlResults = new DevExpress.XtraGrid.GridControl();
            this.gridViewResults = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.richEditControlQueryEditor = new DevExpress.XtraRichEdit.RichEditControl();
            this.lcgQueryControl = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciQueryEditor = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciQueryResults = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItemQueryEditor = new DevExpress.XtraLayout.SplitterItem();
            this.mvvmContextQueryControl = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlQueryControl)).BeginInit();
            this.layoutControlQueryControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgQueryControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciQueryEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciQueryResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItemQueryEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextQueryControl)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlQueryControl
            // 
            this.layoutControlQueryControl.Controls.Add(this.gridControlResults);
            this.layoutControlQueryControl.Controls.Add(this.richEditControlQueryEditor);
            this.layoutControlQueryControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlQueryControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControlQueryControl.Name = "layoutControlQueryControl";
            this.layoutControlQueryControl.Root = this.lcgQueryControl;
            this.layoutControlQueryControl.Size = new System.Drawing.Size(800, 600);
            this.layoutControlQueryControl.TabIndex = 0;
            this.layoutControlQueryControl.Text = "layoutControl1";
            // 
            // gridControlResults
            // 
            this.gridControlResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlResults.Location = new System.Drawing.Point(12, 274);
            this.gridControlResults.MainView = this.gridViewResults;
            this.gridControlResults.Name = "gridControlResults";
            this.gridControlResults.Size = new System.Drawing.Size(776, 314);
            this.gridControlResults.TabIndex = 11;
            this.gridControlResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewResults});
            // 
            // gridViewResults
            // 
            this.gridViewResults.GridControl = this.gridControlResults;
            this.gridViewResults.Name = "gridViewResults";
            this.gridViewResults.OptionsBehavior.Editable = false;
            this.gridViewResults.OptionsView.ColumnAutoWidth = false;
            // 
            // richEditControlQueryEditor
            // 
            this.richEditControlQueryEditor.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richEditControlQueryEditor.Location = new System.Drawing.Point(12, 12);
            this.richEditControlQueryEditor.Name = "richEditControlQueryEditor";
            this.richEditControlQueryEditor.Size = new System.Drawing.Size(776, 248);
            this.richEditControlQueryEditor.TabIndex = 10;
            this.richEditControlQueryEditor.Views.DraftView.AllowDisplayLineNumbers = true;
            this.richEditControlQueryEditor.Views.DraftView.Padding = new System.Windows.Forms.Padding(80, 4, 0, 0);
            this.richEditControlQueryEditor.Views.SimpleView.AllowDisplayLineNumbers = true;
            this.richEditControlQueryEditor.Views.SimpleView.Padding = new System.Windows.Forms.Padding(80, 4, 0, 0);
            // 
            // lcgQueryControl
            // 
            this.lcgQueryControl.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgQueryControl.GroupBordersVisible = false;
            this.lcgQueryControl.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciQueryEditor,
            this.lciQueryResults,
            this.splitterItemQueryEditor});
            this.lcgQueryControl.Name = "lcgQueryControl";
            this.lcgQueryControl.Size = new System.Drawing.Size(800, 600);
            this.lcgQueryControl.Text = "QueryControl";
            this.lcgQueryControl.TextVisible = false;
            // 
            // lciQueryEditor
            // 
            this.lciQueryEditor.Control = this.richEditControlQueryEditor;
            this.lciQueryEditor.Location = new System.Drawing.Point(0, 0);
            this.lciQueryEditor.Name = "lciQueryEditor";
            this.lciQueryEditor.Size = new System.Drawing.Size(780, 252);
            this.lciQueryEditor.Text = "Query Editor";
            this.lciQueryEditor.TextSize = new System.Drawing.Size(0, 0);
            this.lciQueryEditor.TextVisible = false;
            // 
            // lciQueryResults
            // 
            this.lciQueryResults.Control = this.gridControlResults;
            this.lciQueryResults.Location = new System.Drawing.Point(0, 262);
            this.lciQueryResults.Name = "lciQueryResults";
            this.lciQueryResults.Size = new System.Drawing.Size(780, 318);
            this.lciQueryResults.TextSize = new System.Drawing.Size(0, 0);
            this.lciQueryResults.TextVisible = false;
            // 
            // splitterItemQueryEditor
            // 
            this.splitterItemQueryEditor.AllowHotTrack = true;
            this.splitterItemQueryEditor.Location = new System.Drawing.Point(0, 252);
            this.splitterItemQueryEditor.Name = "splitterItemQueryEditor";
            this.splitterItemQueryEditor.Size = new System.Drawing.Size(780, 10);
            // 
            // mvvmContextQueryControl
            // 
            this.mvvmContextQueryControl.ContainerControl = this;
            // 
            // QueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControlQueryControl);
            this.Name = "QueryControl";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlQueryControl)).EndInit();
            this.layoutControlQueryControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgQueryControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciQueryEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciQueryResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItemQueryEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextQueryControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlQueryControl;
        private DevExpress.XtraLayout.LayoutControlGroup lcgQueryControl;
        private DevExpress.XtraRichEdit.RichEditControl richEditControlQueryEditor;
        private DevExpress.XtraLayout.LayoutControlItem lciQueryEditor;
        private DevExpress.XtraGrid.GridControl gridControlResults;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewResults;
        private DevExpress.XtraLayout.LayoutControlItem lciQueryResults;
        private DevExpress.XtraLayout.SplitterItem splitterItemQueryEditor;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContextQueryControl;
    }
}
