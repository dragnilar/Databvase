using LWSqlQueryTool_Winforms.View_Models;

namespace LWSqlQueryTool_Winforms.Views
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.ribbonControlMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.barButtonItemColorMixer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemColorPalette = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemNewQuery = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSaveQuery = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSkins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mvvmContextMain = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.defaultLookAndFeelMain = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.dockManagerMain = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelMain = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelObjectExplorer = new DevExpress.XtraBars.Docking.DockPanel();
            this.objectExplorerContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.documentManagerMain = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedViewMain = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.ribbonPageDatabvase = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupQuery = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupGoNecction = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemConnect = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerMain)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanelMain.SuspendLayout();
            this.dockPanelObjectExplorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControlMain
            // 
            this.ribbonControlMain.ExpandCollapseItem.Id = 0;
            this.ribbonControlMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControlMain.ExpandCollapseItem,
            this.skinRibbonGalleryBarItem1,
            this.barButtonItemColorMixer,
            this.barButtonItemColorPalette,
            this.barButtonItemNewQuery,
            this.barButtonItemSaveQuery,
            this.barButtonItemConnect});
            this.ribbonControlMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonControlMain.MaxItemId = 7;
            this.ribbonControlMain.Name = "ribbonControlMain";
            this.ribbonControlMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageDatabvase,
            this.ribbonPageView});
            this.ribbonControlMain.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControlMain.Size = new System.Drawing.Size(1024, 162);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinGallery";
            this.skinRibbonGalleryBarItem1.Id = 1;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // barButtonItemColorMixer
            // 
            this.barButtonItemColorMixer.Caption = "Color Mixer";
            this.barButtonItemColorMixer.Id = 2;
            this.barButtonItemColorMixer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemColorMixer.ImageOptions.Image")));
            this.barButtonItemColorMixer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemColorMixer.ImageOptions.LargeImage")));
            this.barButtonItemColorMixer.Name = "barButtonItemColorMixer";
            // 
            // barButtonItemColorPalette
            // 
            this.barButtonItemColorPalette.Caption = "Color Palette";
            this.barButtonItemColorPalette.Id = 3;
            this.barButtonItemColorPalette.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemColorPalette.ImageOptions.Image")));
            this.barButtonItemColorPalette.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemColorPalette.ImageOptions.LargeImage")));
            this.barButtonItemColorPalette.Name = "barButtonItemColorPalette";
            // 
            // barButtonItemNewQuery
            // 
            this.barButtonItemNewQuery.Caption = "New Query";
            this.barButtonItemNewQuery.Id = 4;
            this.barButtonItemNewQuery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemNewQuery.ImageOptions.Image")));
            this.barButtonItemNewQuery.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemNewQuery.ImageOptions.LargeImage")));
            this.barButtonItemNewQuery.Name = "barButtonItemNewQuery";
            // 
            // barButtonItemSaveQuery
            // 
            this.barButtonItemSaveQuery.Caption = "Save Query";
            this.barButtonItemSaveQuery.Id = 5;
            this.barButtonItemSaveQuery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemSaveQuery.ImageOptions.Image")));
            this.barButtonItemSaveQuery.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemSaveQuery.ImageOptions.LargeImage")));
            this.barButtonItemSaveQuery.Name = "barButtonItemSaveQuery";
            // 
            // ribbonPageView
            // 
            this.ribbonPageView.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupSkins});
            this.ribbonPageView.Name = "ribbonPageView";
            this.ribbonPageView.Text = "View";
            // 
            // ribbonPageGroupSkins
            // 
            this.ribbonPageGroupSkins.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroupSkins.ItemLinks.Add(this.barButtonItemColorMixer);
            this.ribbonPageGroupSkins.ItemLinks.Add(this.barButtonItemColorPalette);
            this.ribbonPageGroupSkins.Name = "ribbonPageGroupSkins";
            this.ribbonPageGroupSkins.Text = "Skins";
            // 
            // mvvmContextMain
            // 
            this.mvvmContextMain.ContainerControl = this;
            this.mvvmContextMain.ViewModelType = typeof(LWSqlQueryTool_Winforms.View_Models.MainViewModel);
            // 
            // defaultLookAndFeelMain
            // 
            this.defaultLookAndFeelMain.LookAndFeel.SkinName = "The Bezier";
            // 
            // dockManagerMain
            // 
            this.dockManagerMain.Form = this;
            this.dockManagerMain.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel2,
            this.dockPanelMain});
            this.dockManagerMain.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelObjectExplorer});
            this.dockManagerMain.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockPanel2.ID = new System.Guid("ad036517-88f0-4ad8-8e21-4aa87af11946");
            this.dockPanel2.Location = new System.Drawing.Point(-32768, -32768);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel2.SavedIndex = 1;
            this.dockPanel2.Size = new System.Drawing.Size(200, 200);
            this.dockPanel2.Text = "dockPanel2";
            this.dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 35);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(192, 161);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dockPanelMain
            // 
            this.dockPanelMain.Controls.Add(this.dockPanel3_Container);
            this.dockPanelMain.DockedAsTabbedDocument = true;
            this.dockPanelMain.ID = new System.Guid("25d39194-5f11-477b-858c-539a2c2cbb22");
            this.dockPanelMain.Name = "dockPanelMain";
            this.dockPanelMain.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelMain.SavedIndex = 1;
            this.dockPanelMain.SavedMdiDocument = true;
            this.dockPanelMain.Text = "Dock Panel";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 35);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(192, 161);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // dockPanelObjectExplorer
            // 
            this.dockPanelObjectExplorer.Controls.Add(this.objectExplorerContainer);
            this.dockPanelObjectExplorer.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelObjectExplorer.ID = new System.Guid("d1cabde8-1e60-4ff1-aba0-b217eab0dd67");
            this.dockPanelObjectExplorer.Location = new System.Drawing.Point(0, 162);
            this.dockPanelObjectExplorer.Name = "dockPanelObjectExplorer";
            this.dockPanelObjectExplorer.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelObjectExplorer.Size = new System.Drawing.Size(200, 606);
            this.dockPanelObjectExplorer.Text = "Object Explorer";
            // 
            // objectExplorerContainer
            // 
            this.objectExplorerContainer.Location = new System.Drawing.Point(3, 30);
            this.objectExplorerContainer.Name = "objectExplorerContainer";
            this.objectExplorerContainer.Size = new System.Drawing.Size(193, 573);
            this.objectExplorerContainer.TabIndex = 0;
            // 
            // documentManagerMain
            // 
            this.documentManagerMain.ContainerControl = this;
            this.documentManagerMain.View = this.tabbedViewMain;
            this.documentManagerMain.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedViewMain});
            // 
            // ribbonPageDatabvase
            // 
            this.ribbonPageDatabvase.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupGoNecction,
            this.ribbonPageGroupQuery});
            this.ribbonPageDatabvase.Name = "ribbonPageDatabvase";
            this.ribbonPageDatabvase.Text = "Databvase!";
            // 
            // ribbonPageGroupQuery
            // 
            this.ribbonPageGroupQuery.ItemLinks.Add(this.barButtonItemNewQuery);
            this.ribbonPageGroupQuery.ItemLinks.Add(this.barButtonItemSaveQuery);
            this.ribbonPageGroupQuery.Name = "ribbonPageGroupQuery";
            this.ribbonPageGroupQuery.Text = "Query";
            // 
            // ribbonPageGroupGoNecction
            // 
            this.ribbonPageGroupGoNecction.ItemLinks.Add(this.barButtonItemConnect);
            this.ribbonPageGroupGoNecction.Name = "ribbonPageGroupGoNecction";
            this.ribbonPageGroupGoNecction.Text = "GoNecction";
            // 
            // barButtonItemConnect
            // 
            this.barButtonItemConnect.Caption = "Connect";
            this.barButtonItemConnect.Id = 6;
            this.barButtonItemConnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemConnect.ImageOptions.Image")));
            this.barButtonItemConnect.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemConnect.ImageOptions.LargeImage")));
            this.barButtonItemConnect.Name = "barButtonItemConnect";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.dockPanelObjectExplorer);
            this.Controls.Add(this.ribbonControlMain);
            this.Name = "MainView";
            this.Ribbon = this.ribbonControlMain;
            this.Text = "Lightweight Query Tool";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerMain)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanelMain.ResumeLayout(false);
            this.dockPanelObjectExplorer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedViewMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControlMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageView;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSkins;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContextMain;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeelMain;
        private DevExpress.XtraBars.BarButtonItem barButtonItemColorMixer;
        private DevExpress.XtraBars.BarButtonItem barButtonItemColorPalette;
        private DevExpress.XtraBars.Docking.DockManager dockManagerMain;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelObjectExplorer;
        private DevExpress.XtraBars.Docking.ControlContainer objectExplorerContainer;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelMain;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManagerMain;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedViewMain;
        private DevExpress.XtraBars.BarButtonItem barButtonItemNewQuery;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSaveQuery;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageDatabvase;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupQuery;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupGoNecction;
        private DevExpress.XtraBars.BarButtonItem barButtonItemConnect;
    }
}

