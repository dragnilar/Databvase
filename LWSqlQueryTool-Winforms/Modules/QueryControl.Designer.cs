namespace Databvase_Winforms.Modules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryControl));
            this.layoutControlQueryControl = new DevExpress.XtraLayout.LayoutControl();
            this.Ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.QueryButton = new DevExpress.XtraBars.BarButtonItem();
            this.SaveQueryButton = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupDatabvase = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupQuery = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabControlResultsPane = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageResultsGrid = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlResults = new DevExpress.XtraGrid.GridControl();
            this.gridViewResults = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPageMessages = new DevExpress.XtraTab.XtraTabPage();
            this.memoEditResults = new DevExpress.XtraEditors.MemoEdit();
            this.richEditControlQueryEditor = new DevExpress.XtraRichEdit.RichEditControl();
            this.lcgQueryControl = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciQueryEditor = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItemQueryEditor = new DevExpress.XtraLayout.SplitterItem();
            this.lcIResultsPane = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciRibbon = new DevExpress.XtraLayout.LayoutControlItem();
            this.mvvmContextQueryControl = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.bindingSourceQueryControl = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonPageGroupGridPrintAndExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barSubItemExport = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemExportGridToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExportToXLSX = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExportToHTML = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExportToPDF = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExportToMHT = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExportToRTF = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExportToText = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrintGrid = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlQueryControl)).BeginInit();
            this.layoutControlQueryControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlResultsPane)).BeginInit();
            this.xtraTabControlResultsPane.SuspendLayout();
            this.xtraTabPageResultsGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).BeginInit();
            this.xtraTabPageMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditResults.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgQueryControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciQueryEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItemQueryEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcIResultsPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextQueryControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceQueryControl)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlQueryControl
            // 
            this.layoutControlQueryControl.Controls.Add(this.Ribbon);
            this.layoutControlQueryControl.Controls.Add(this.xtraTabControlResultsPane);
            this.layoutControlQueryControl.Controls.Add(this.richEditControlQueryEditor);
            this.layoutControlQueryControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlQueryControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControlQueryControl.Name = "layoutControlQueryControl";
            this.layoutControlQueryControl.Root = this.lcgQueryControl;
            this.layoutControlQueryControl.Size = new System.Drawing.Size(800, 600);
            this.layoutControlQueryControl.TabIndex = 0;
            this.layoutControlQueryControl.Text = "layoutControl1";
            // 
            // ribbonControlQueryControl
            // 
            this.Ribbon.Dock = System.Windows.Forms.DockStyle.None;
            this.Ribbon.ExpandCollapseItem.Id = 0;
            this.Ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.Ribbon.ExpandCollapseItem,
            this.QueryButton,
            this.SaveQueryButton,
            this.barSubItemExport,
            this.barButtonItemExportGridToExcel,
            this.barButtonItemExportToXLSX,
            this.barButtonItemExportToHTML,
            this.barButtonItemExportToPDF,
            this.barButtonItemExportToMHT,
            this.barButtonItemExportToRTF,
            this.barButtonItemExportToText,
            this.barButtonItemPrintGrid});
            this.Ribbon.Location = new System.Drawing.Point(12, 12);
            this.Ribbon.MaxItemId = 14;
            this.Ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.Ribbon.Name = "Ribbon";
            this.Ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageGroupDatabvase});
            this.Ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.Ribbon.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            this.Ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.Ribbon.Size = new System.Drawing.Size(776, 120);
            this.Ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // QueryButton
            // 
            this.QueryButton.Caption = "Execute Query";
            this.QueryButton.Id = 1;
            this.QueryButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("QueryButton.ImageOptions.Image")));
            this.QueryButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("QueryButton.ImageOptions.LargeImage")));
            this.QueryButton.Name = "QueryButton";
            // 
            // SaveQueryButton
            // 
            this.SaveQueryButton.Caption = "Save Query";
            this.SaveQueryButton.Id = 2;
            this.SaveQueryButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SaveQueryButton.ImageOptions.Image")));
            this.SaveQueryButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("SaveQueryButton.ImageOptions.LargeImage")));
            this.SaveQueryButton.Name = "SaveQueryButton";
            // 
            // ribbonPageGroupDatabvase
            // 
            this.ribbonPageGroupDatabvase.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupQuery,
            this.ribbonPageGroupGridPrintAndExport});
            this.ribbonPageGroupDatabvase.Name = "ribbonPageGroupDatabvase";
            this.ribbonPageGroupDatabvase.Text = "Databvase!";
            // 
            // ribbonPageGroupQuery
            // 
            this.ribbonPageGroupQuery.ItemLinks.Add(this.QueryButton);
            this.ribbonPageGroupQuery.ItemLinks.Add(this.SaveQueryButton);
            this.ribbonPageGroupQuery.Name = "ribbonPageGroupQuery";
            this.ribbonPageGroupQuery.Text = "Query";
            // 
            // xtraTabControlResultsPane
            // 
            this.xtraTabControlResultsPane.Location = new System.Drawing.Point(12, 285);
            this.xtraTabControlResultsPane.Name = "xtraTabControlResultsPane";
            this.xtraTabControlResultsPane.SelectedTabPage = this.xtraTabPageResultsGrid;
            this.xtraTabControlResultsPane.Size = new System.Drawing.Size(776, 303);
            this.xtraTabControlResultsPane.TabIndex = 12;
            this.xtraTabControlResultsPane.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageResultsGrid,
            this.xtraTabPageMessages});
            // 
            // xtraTabPageResultsGrid
            // 
            this.xtraTabPageResultsGrid.Controls.Add(this.gridControlResults);
            this.xtraTabPageResultsGrid.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageResultsGrid.ImageOptions.Image")));
            this.xtraTabPageResultsGrid.Name = "xtraTabPageResultsGrid";
            this.xtraTabPageResultsGrid.Size = new System.Drawing.Size(770, 272);
            this.xtraTabPageResultsGrid.Text = "Results";
            // 
            // gridControlResults
            // 
            this.gridControlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlResults.Location = new System.Drawing.Point(0, 0);
            this.gridControlResults.MainView = this.gridViewResults;
            this.gridControlResults.Name = "gridControlResults";
            this.gridControlResults.Size = new System.Drawing.Size(770, 272);
            this.gridControlResults.TabIndex = 12;
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
            // xtraTabPageMessages
            // 
            this.xtraTabPageMessages.Controls.Add(this.memoEditResults);
            this.xtraTabPageMessages.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageMessages.ImageOptions.Image")));
            this.xtraTabPageMessages.Name = "xtraTabPageMessages";
            this.xtraTabPageMessages.Size = new System.Drawing.Size(770, 272);
            this.xtraTabPageMessages.Text = "Messages";
            // 
            // memoEditResults
            // 
            this.memoEditResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEditResults.Location = new System.Drawing.Point(0, 0);
            this.memoEditResults.Name = "memoEditResults";
            this.memoEditResults.Size = new System.Drawing.Size(770, 272);
            this.memoEditResults.TabIndex = 0;
            // 
            // richEditControlQueryEditor
            // 
            this.richEditControlQueryEditor.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richEditControlQueryEditor.Location = new System.Drawing.Point(12, 36);
            this.richEditControlQueryEditor.MenuManager = this.Ribbon;
            this.richEditControlQueryEditor.Name = "richEditControlQueryEditor";
            this.richEditControlQueryEditor.Size = new System.Drawing.Size(776, 240);
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
            this.splitterItemQueryEditor,
            this.lcIResultsPane,
            this.lciRibbon});
            this.lcgQueryControl.Name = "lcgQueryControl";
            this.lcgQueryControl.Size = new System.Drawing.Size(800, 600);
            this.lcgQueryControl.Text = "QueryControl";
            this.lcgQueryControl.TextVisible = false;
            // 
            // lciQueryEditor
            // 
            this.lciQueryEditor.Control = this.richEditControlQueryEditor;
            this.lciQueryEditor.Location = new System.Drawing.Point(0, 24);
            this.lciQueryEditor.Name = "lciQueryEditor";
            this.lciQueryEditor.Size = new System.Drawing.Size(780, 244);
            this.lciQueryEditor.Text = "Query Editor";
            this.lciQueryEditor.TextSize = new System.Drawing.Size(0, 0);
            this.lciQueryEditor.TextVisible = false;
            // 
            // splitterItemQueryEditor
            // 
            this.splitterItemQueryEditor.AllowHotTrack = true;
            this.splitterItemQueryEditor.Location = new System.Drawing.Point(0, 268);
            this.splitterItemQueryEditor.Name = "splitterItemQueryEditor";
            this.splitterItemQueryEditor.Size = new System.Drawing.Size(780, 5);
            // 
            // lcIResultsPane
            // 
            this.lcIResultsPane.Control = this.xtraTabControlResultsPane;
            this.lcIResultsPane.Location = new System.Drawing.Point(0, 273);
            this.lcIResultsPane.Name = "lcIResultsPane";
            this.lcIResultsPane.Size = new System.Drawing.Size(780, 307);
            this.lcIResultsPane.Text = "ResultsPane";
            this.lcIResultsPane.TextSize = new System.Drawing.Size(0, 0);
            this.lcIResultsPane.TextVisible = false;
            // 
            // lciRibbon
            // 
            this.lciRibbon.Control = this.Ribbon;
            this.lciRibbon.Location = new System.Drawing.Point(0, 0);
            this.lciRibbon.Name = "lciRibbon";
            this.lciRibbon.Size = new System.Drawing.Size(780, 24);
            this.lciRibbon.TextSize = new System.Drawing.Size(0, 0);
            this.lciRibbon.TextVisible = false;
            this.lciRibbon.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // mvvmContextQueryControl
            // 
            this.mvvmContextQueryControl.ContainerControl = this;
            this.mvvmContextQueryControl.ViewModelType = typeof(Databvase_Winforms.View_Models.QueryControlViewModel);
            // 
            // bindingSourceQueryControl
            // 
            this.bindingSourceQueryControl.DataSource = typeof(Databvase_Winforms.Models.QueryDocumentEntity);
            // 
            // ribbonPageGroupGridPrintAndExport
            // 
            this.ribbonPageGroupGridPrintAndExport.AllowTextClipping = false;
            this.ribbonPageGroupGridPrintAndExport.ItemLinks.Add(this.barSubItemExport);
            this.ribbonPageGroupGridPrintAndExport.ItemLinks.Add(this.barButtonItemPrintGrid);
            this.ribbonPageGroupGridPrintAndExport.Name = "ribbonPageGroupGridPrintAndExport";
            this.ribbonPageGroupGridPrintAndExport.Text = "Print And Export Data";
            // 
            // barSubItemExport
            // 
            this.barSubItemExport.Caption = "Export Grid";
            this.barSubItemExport.Id = 5;
            this.barSubItemExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItemExport.ImageOptions.Image")));
            this.barSubItemExport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItemExport.ImageOptions.LargeImage")));
            this.barSubItemExport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExportGridToExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExportToXLSX),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExportToHTML),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExportToPDF),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExportToMHT),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExportToRTF),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExportToText)});
            this.barSubItemExport.Name = "barSubItemExport";
            // 
            // barButtonItemExportGridToExcel
            // 
            this.barButtonItemExportGridToExcel.Caption = "Export to XLS";
            this.barButtonItemExportGridToExcel.Id = 6;
            this.barButtonItemExportGridToExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportGridToExcel.ImageOptions.Image")));
            this.barButtonItemExportGridToExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportGridToExcel.ImageOptions.LargeImage")));
            this.barButtonItemExportGridToExcel.Name = "barButtonItemExportGridToExcel";
            // 
            // barButtonItemExportToXLSX
            // 
            this.barButtonItemExportToXLSX.Caption = "Export to XLSX";
            this.barButtonItemExportToXLSX.Id = 7;
            this.barButtonItemExportToXLSX.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportToXLSX.ImageOptions.Image")));
            this.barButtonItemExportToXLSX.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportToXLSX.ImageOptions.LargeImage")));
            this.barButtonItemExportToXLSX.Name = "barButtonItemExportToXLSX";
            // 
            // barButtonItemExportToHTML
            // 
            this.barButtonItemExportToHTML.Caption = "Export to HTML";
            this.barButtonItemExportToHTML.Id = 8;
            this.barButtonItemExportToHTML.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportToHTML.ImageOptions.Image")));
            this.barButtonItemExportToHTML.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportToHTML.ImageOptions.LargeImage")));
            this.barButtonItemExportToHTML.Name = "barButtonItemExportToHTML";
            // 
            // barButtonItemExportToPDF
            // 
            this.barButtonItemExportToPDF.Caption = "Export to PDF";
            this.barButtonItemExportToPDF.Id = 9;
            this.barButtonItemExportToPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportToPDF.ImageOptions.Image")));
            this.barButtonItemExportToPDF.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportToPDF.ImageOptions.LargeImage")));
            this.barButtonItemExportToPDF.Name = "barButtonItemExportToPDF";
            // 
            // barButtonItemExportToMHT
            // 
            this.barButtonItemExportToMHT.Caption = "Export to MHT";
            this.barButtonItemExportToMHT.Id = 10;
            this.barButtonItemExportToMHT.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportToMHT.ImageOptions.Image")));
            this.barButtonItemExportToMHT.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportToMHT.ImageOptions.LargeImage")));
            this.barButtonItemExportToMHT.Name = "barButtonItemExportToMHT";
            // 
            // barButtonItemExportToRTF
            // 
            this.barButtonItemExportToRTF.Caption = "Export to RTF";
            this.barButtonItemExportToRTF.Id = 11;
            this.barButtonItemExportToRTF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportToRTF.ImageOptions.Image")));
            this.barButtonItemExportToRTF.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportToRTF.ImageOptions.LargeImage")));
            this.barButtonItemExportToRTF.Name = "barButtonItemExportToRTF";
            // 
            // barButtonItemExportToText
            // 
            this.barButtonItemExportToText.Caption = "Export to Text";
            this.barButtonItemExportToText.Id = 12;
            this.barButtonItemExportToText.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportToText.ImageOptions.Image")));
            this.barButtonItemExportToText.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemExportToText.ImageOptions.LargeImage")));
            this.barButtonItemExportToText.Name = "barButtonItemExportToText";
            // 
            // barButtonItemPrintGrid
            // 
            this.barButtonItemPrintGrid.Caption = "Print Preview";
            this.barButtonItemPrintGrid.Id = 13;
            this.barButtonItemPrintGrid.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItemPrintGrid.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItemPrintGrid.Name = "barButtonItemPrintGrid";
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
            this.layoutControlQueryControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlResultsPane)).EndInit();
            this.xtraTabControlResultsPane.ResumeLayout(false);
            this.xtraTabPageResultsGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).EndInit();
            this.xtraTabPageMessages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEditResults.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgQueryControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciQueryEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItemQueryEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcIResultsPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextQueryControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceQueryControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlQueryControl;
        private DevExpress.XtraLayout.LayoutControlGroup lcgQueryControl;
        private DevExpress.XtraRichEdit.RichEditControl richEditControlQueryEditor;
        private DevExpress.XtraLayout.LayoutControlItem lciQueryEditor;
        private DevExpress.XtraLayout.SplitterItem splitterItemQueryEditor;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContextQueryControl;
        private System.Windows.Forms.BindingSource bindingSourceQueryControl;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlResultsPane;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageResultsGrid;
        private DevExpress.XtraGrid.GridControl gridControlResults;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewResults;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageMessages;
        private DevExpress.XtraLayout.LayoutControlItem lcIResultsPane;
        private DevExpress.XtraEditors.MemoEdit memoEditResults;
        private DevExpress.XtraBars.BarButtonItem QueryButton;
        private DevExpress.XtraBars.BarButtonItem SaveQueryButton;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageGroupDatabvase;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupQuery;
        private DevExpress.XtraLayout.LayoutControlItem lciRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupGridPrintAndExport;
        private DevExpress.XtraBars.BarSubItem barSubItemExport;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExportGridToExcel;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExportToXLSX;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExportToHTML;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExportToPDF;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExportToMHT;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExportToRTF;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExportToText;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPrintGrid;
    }
}
