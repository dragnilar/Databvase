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
            this.ribbonPageView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSkins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mvvmContextMain = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.defaultLookAndFeelMain = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.barButtonItemColorMixer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemColorPalette = new DevExpress.XtraBars.BarButtonItem();
            this.dashboardDesigner1 = new DevExpress.DashboardWin.DashboardDesigner();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControlMain
            // 
            this.ribbonControlMain.ExpandCollapseItem.Id = 0;
            this.ribbonControlMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControlMain.ExpandCollapseItem,
            this.skinRibbonGalleryBarItem1,
            this.barButtonItemColorMixer,
            this.barButtonItemColorPalette});
            this.ribbonControlMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonControlMain.MaxItemId = 4;
            this.ribbonControlMain.Name = "ribbonControlMain";
            this.ribbonControlMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageView});
            this.ribbonControlMain.Size = new System.Drawing.Size(1024, 162);
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
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinGallery";
            this.skinRibbonGalleryBarItem1.Id = 1;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // defaultLookAndFeelMain
            // 
            this.defaultLookAndFeelMain.LookAndFeel.SkinName = "The Bezier";
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
            // dashboardDesigner1
            // 
            this.dashboardDesigner1.AllowPrintDashboard = true;
            this.dashboardDesigner1.AllowPrintDashboardItems = true;
            this.dashboardDesigner1.Location = new System.Drawing.Point(12, 168);
            this.dashboardDesigner1.MenuManager = this.ribbonControlMain;
            this.dashboardDesigner1.Name = "dashboardDesigner1";
            this.dashboardDesigner1.Size = new System.Drawing.Size(744, 522);
            this.dashboardDesigner1.TabIndex = 1;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.dashboardDesigner1);
            this.Controls.Add(this.ribbonControlMain);
            this.Name = "MainView";
            this.Ribbon = this.ribbonControlMain;
            this.Text = "Lightweight Query Tool";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextMain)).EndInit();
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
        private DevExpress.DashboardWin.DashboardDesigner dashboardDesigner1;
    }
}

