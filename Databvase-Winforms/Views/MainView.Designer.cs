﻿using Databvase_Winforms.View_Models;

namespace Databvase_Winforms.Views
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManagerMainSplashy = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Databvase_Winforms.Views.SplashScreenDatabvase), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.ribbonControlMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.barButtonItemColorMixer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemColorPalette = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemNewQuery = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemConnect = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemObjectExplorer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDisconnect = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemShowSettings = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItemTextEditorBG = new DevExpress.XtraBars.BarEditItem();
            this.riColorPickEditTextBG = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.barEditItemTextEditorLineNumberColor = new DevExpress.XtraBars.BarEditItem();
            this.riColorPickEditTextEditorLineNumberColor = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.barButtonItemTextEditorFontSettings = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQueryBuilder = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemBackupWizard = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageDatabvase = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupDatabvase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupLookAndFeel = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupWindows = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mvvmContextMain = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.tabbedViewMain = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManagerMain = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelMain = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelObjectExplorer = new DevExpress.XtraBars.Docking.DockPanel();
            this.objectExplorerContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.documentManagerMain = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.splashScreenManagerMainWait = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Databvase_Winforms.Views.WaitSplashyView), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riColorPickEditTextBG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riColorPickEditTextEditorLineNumberColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerMain)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanelMain.SuspendLayout();
            this.dockPanelObjectExplorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerMain)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManagerMainSplashy
            // 
            splashScreenManagerMainSplashy.ClosingDelay = 500;
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
            this.barButtonItemConnect,
            this.barButtonItemObjectExplorer,
            this.barButtonItemDisconnect,
            this.barButtonItemShowSettings,
            this.barEditItemTextEditorBG,
            this.barEditItemTextEditorLineNumberColor,
            this.barButtonItemTextEditorFontSettings,
            this.barButtonItemQueryBuilder,
            this.barButtonItemBackupWizard});
            this.ribbonControlMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonControlMain.MaxItemId = 21;
            this.ribbonControlMain.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbonControlMain.Name = "ribbonControlMain";
            this.ribbonControlMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageDatabvase,
            this.ribbonPageView});
            this.ribbonControlMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riColorPickEditTextBG,
            this.riColorPickEditTextEditorLineNumberColor});
            this.ribbonControlMain.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControlMain.Size = new System.Drawing.Size(1024, 162);
            this.ribbonControlMain.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
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
            this.barButtonItemNewQuery.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemConnect
            // 
            this.barButtonItemConnect.Caption = "Connect";
            this.barButtonItemConnect.Id = 6;
            this.barButtonItemConnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemConnect.ImageOptions.Image")));
            this.barButtonItemConnect.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemConnect.ImageOptions.LargeImage")));
            this.barButtonItemConnect.Name = "barButtonItemConnect";
            // 
            // barButtonItemObjectExplorer
            // 
            this.barButtonItemObjectExplorer.Caption = "Show Object Explorer";
            this.barButtonItemObjectExplorer.Id = 7;
            this.barButtonItemObjectExplorer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemObjectExplorer.ImageOptions.Image")));
            this.barButtonItemObjectExplorer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemObjectExplorer.ImageOptions.LargeImage")));
            this.barButtonItemObjectExplorer.Name = "barButtonItemObjectExplorer";
            // 
            // barButtonItemDisconnect
            // 
            this.barButtonItemDisconnect.Caption = "Disconnect";
            this.barButtonItemDisconnect.Id = 9;
            this.barButtonItemDisconnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemDisconnect.ImageOptions.Image")));
            this.barButtonItemDisconnect.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemDisconnect.ImageOptions.LargeImage")));
            this.barButtonItemDisconnect.Name = "barButtonItemDisconnect";
            this.barButtonItemDisconnect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemShowSettings
            // 
            this.barButtonItemShowSettings.Caption = "Settings Window";
            this.barButtonItemShowSettings.Id = 13;
            this.barButtonItemShowSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemShowSettings.ImageOptions.Image")));
            this.barButtonItemShowSettings.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemShowSettings.ImageOptions.LargeImage")));
            this.barButtonItemShowSettings.Name = "barButtonItemShowSettings";
            // 
            // barEditItemTextEditorBG
            // 
            this.barEditItemTextEditorBG.Caption = "Text Editor Background          ";
            this.barEditItemTextEditorBG.Edit = this.riColorPickEditTextBG;
            this.barEditItemTextEditorBG.Id = 15;
            this.barEditItemTextEditorBG.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barEditItemTextEditorBG.ImageOptions.SvgImage")));
            this.barEditItemTextEditorBG.Name = "barEditItemTextEditorBG";
            // 
            // riColorPickEditTextBG
            // 
            this.riColorPickEditTextBG.AutoHeight = false;
            this.riColorPickEditTextBG.AutomaticColor = System.Drawing.Color.Black;
            this.riColorPickEditTextBG.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riColorPickEditTextBG.Name = "riColorPickEditTextBG";
            // 
            // barEditItemTextEditorLineNumberColor
            // 
            this.barEditItemTextEditorLineNumberColor.Caption = "Text Editor Line Number Color";
            this.barEditItemTextEditorLineNumberColor.Edit = this.riColorPickEditTextEditorLineNumberColor;
            this.barEditItemTextEditorLineNumberColor.Id = 16;
            this.barEditItemTextEditorLineNumberColor.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barEditItemTextEditorLineNumberColor.ImageOptions.SvgImage")));
            this.barEditItemTextEditorLineNumberColor.Name = "barEditItemTextEditorLineNumberColor";
            // 
            // riColorPickEditTextEditorLineNumberColor
            // 
            this.riColorPickEditTextEditorLineNumberColor.AutoHeight = false;
            this.riColorPickEditTextEditorLineNumberColor.AutomaticColor = System.Drawing.Color.Black;
            this.riColorPickEditTextEditorLineNumberColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riColorPickEditTextEditorLineNumberColor.Name = "riColorPickEditTextEditorLineNumberColor";
            // 
            // barButtonItemTextEditorFontSettings
            // 
            this.barButtonItemTextEditorFontSettings.Caption = "Text Editor Font Styles";
            this.barButtonItemTextEditorFontSettings.Id = 17;
            this.barButtonItemTextEditorFontSettings.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemTextEditorFontSettings.ImageOptions.SvgImage")));
            this.barButtonItemTextEditorFontSettings.Name = "barButtonItemTextEditorFontSettings";
            // 
            // barButtonItemQueryBuilder
            // 
            this.barButtonItemQueryBuilder.Caption = "Query Builder";
            this.barButtonItemQueryBuilder.Id = 18;
            this.barButtonItemQueryBuilder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemQueryBuilder.ImageOptions.Image")));
            this.barButtonItemQueryBuilder.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemQueryBuilder.ImageOptions.LargeImage")));
            this.barButtonItemQueryBuilder.Name = "barButtonItemQueryBuilder";
            this.barButtonItemQueryBuilder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemBackupWizard
            // 
            this.barButtonItemBackupWizard.Caption = "Backup Wizard";
            this.barButtonItemBackupWizard.Id = 20;
            this.barButtonItemBackupWizard.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemBackupWizard.ImageOptions.SvgImage")));
            this.barButtonItemBackupWizard.Name = "barButtonItemBackupWizard";
            // 
            // ribbonPageDatabvase
            // 
            this.ribbonPageDatabvase.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupDatabvase});
            this.ribbonPageDatabvase.Name = "ribbonPageDatabvase";
            this.ribbonPageDatabvase.Text = "Databvase!";
            // 
            // ribbonPageGroupDatabvase
            // 
            this.ribbonPageGroupDatabvase.ItemLinks.Add(this.barButtonItemConnect);
            this.ribbonPageGroupDatabvase.ItemLinks.Add(this.barButtonItemDisconnect);
            this.ribbonPageGroupDatabvase.ItemLinks.Add(this.barButtonItemNewQuery);
            this.ribbonPageGroupDatabvase.ItemLinks.Add(this.barButtonItemQueryBuilder);
            this.ribbonPageGroupDatabvase.ItemLinks.Add(this.barButtonItemBackupWizard);
            this.ribbonPageGroupDatabvase.Name = "ribbonPageGroupDatabvase";
            this.ribbonPageGroupDatabvase.Text = "Databvase?!";
            // 
            // ribbonPageView
            // 
            this.ribbonPageView.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupLookAndFeel,
            this.ribbonPageGroupWindows});
            this.ribbonPageView.Name = "ribbonPageView";
            this.ribbonPageView.Text = "View";
            // 
            // ribbonPageGroupLookAndFeel
            // 
            this.ribbonPageGroupLookAndFeel.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroupLookAndFeel.ItemLinks.Add(this.barButtonItemColorMixer);
            this.ribbonPageGroupLookAndFeel.ItemLinks.Add(this.barButtonItemColorPalette);
            this.ribbonPageGroupLookAndFeel.ItemLinks.Add(this.barButtonItemTextEditorFontSettings);
            this.ribbonPageGroupLookAndFeel.ItemLinks.Add(this.barEditItemTextEditorBG, true);
            this.ribbonPageGroupLookAndFeel.ItemLinks.Add(this.barEditItemTextEditorLineNumberColor);
            this.ribbonPageGroupLookAndFeel.Name = "ribbonPageGroupLookAndFeel";
            this.ribbonPageGroupLookAndFeel.Text = "Look And Feel";
            // 
            // ribbonPageGroupWindows
            // 
            this.ribbonPageGroupWindows.ItemLinks.Add(this.barButtonItemObjectExplorer);
            this.ribbonPageGroupWindows.ItemLinks.Add(this.barButtonItemShowSettings);
            this.ribbonPageGroupWindows.Name = "ribbonPageGroupWindows";
            this.ribbonPageGroupWindows.Text = "Windows";
            // 
            // mvvmContextMain
            // 
            this.mvvmContextMain.ContainerControl = this;
            this.mvvmContextMain.RegistrationExpressions.AddRange(new DevExpress.Utils.MVVM.RegistrationExpression[] {
            DevExpress.Utils.MVVM.RegistrationExpression.RegisterDocumentManagerService(null, false, this.tabbedViewMain)});
            this.mvvmContextMain.ViewModelType = typeof(Databvase_Winforms.View_Models.MainViewModel);
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
            this.dockPanel2.SavedSizeFactor = 1D;
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
            this.dockPanelMain.SavedSizeFactor = 1D;
            this.dockPanelMain.Text = "Dock Panel";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 34);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(192, 162);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // dockPanelObjectExplorer
            // 
            this.dockPanelObjectExplorer.Controls.Add(this.objectExplorerContainer);
            this.dockPanelObjectExplorer.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelObjectExplorer.ID = new System.Guid("d1cabde8-1e60-4ff1-aba0-b217eab0dd67");
            this.dockPanelObjectExplorer.Location = new System.Drawing.Point(0, 162);
            this.dockPanelObjectExplorer.Name = "dockPanelObjectExplorer";
            this.dockPanelObjectExplorer.OriginalSize = new System.Drawing.Size(350, 200);
            this.dockPanelObjectExplorer.SavedSizeFactor = 0D;
            this.dockPanelObjectExplorer.Size = new System.Drawing.Size(350, 606);
            this.dockPanelObjectExplorer.Text = "Object Explorer";
            // 
            // objectExplorerContainer
            // 
            this.objectExplorerContainer.Location = new System.Drawing.Point(3, 30);
            this.objectExplorerContainer.Name = "objectExplorerContainer";
            this.objectExplorerContainer.Size = new System.Drawing.Size(343, 573);
            this.objectExplorerContainer.TabIndex = 0;
            // 
            // documentManagerMain
            // 
            this.documentManagerMain.ContainerControl = this;
            this.documentManagerMain.MenuManager = this.ribbonControlMain;
            this.documentManagerMain.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always;
            this.documentManagerMain.View = this.tabbedViewMain;
            this.documentManagerMain.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedViewMain});
            // 
            // splashScreenManagerMainWait
            // 
            this.splashScreenManagerMainWait.ClosingDelay = 500;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.dockPanelObjectExplorer);
            this.Controls.Add(this.ribbonControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainView";
            this.Ribbon = this.ribbonControlMain;
            this.Text = "Databvase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riColorPickEditTextBG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riColorPickEditTextEditorLineNumberColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerMain)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanelMain.ResumeLayout(false);
            this.dockPanelObjectExplorer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControlMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageView;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupLookAndFeel;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContextMain;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
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
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageDatabvase;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupDatabvase;
        private DevExpress.XtraBars.BarButtonItem barButtonItemConnect;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupWindows;
        private DevExpress.XtraBars.BarButtonItem barButtonItemObjectExplorer;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDisconnect;
        private DevExpress.XtraBars.BarButtonItem barButtonItemShowSettings;
        private DevExpress.XtraBars.BarEditItem barEditItemTextEditorBG;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit riColorPickEditTextBG;
        private DevExpress.XtraBars.BarEditItem barEditItemTextEditorLineNumberColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit riColorPickEditTextEditorLineNumberColor;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTextEditorFontSettings;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManagerMainWait;
        private DevExpress.XtraBars.BarButtonItem barButtonItemQueryBuilder;
        private DevExpress.XtraBars.BarButtonItem barButtonItemBackupWizard;
    }
}

