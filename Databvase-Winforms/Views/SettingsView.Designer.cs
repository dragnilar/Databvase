using Databvase_Winforms.View_Models;

namespace Databvase_Winforms.Views
{
    partial class SettingsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
            this.mvvmContextSettingsView = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.navigationPaneSettings = new DevExpress.XtraBars.Navigation.NavigationPane();
            this.navigationPageQuerySettings = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.lclQuerySettings = new DevExpress.XtraLayout.LayoutControl();
            this.lcgEnvironment = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgQueryScripting = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgQueryExecution = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciNumberOfRowsForSelectTop = new DevExpress.XtraLayout.LayoutControlItem();
            this.spinEditNumberOfRowsForTopScript = new DevExpress.XtraEditors.SpinEdit();
            this.lcSettings = new DevExpress.XtraLayout.LayoutControl();
            this.checkEditShowRowNumberColumn = new DevExpress.XtraEditors.CheckEdit();
            this.lcgSettings = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciSettingsNavigationPane = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciShowRowNumberInGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.navigationPageTextEditor = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPageObjectExplorer = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPageEnvironment = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.simpleButtonSaveSettings = new DevExpress.XtraEditors.SimpleButton();
            this.lciSaveSettingsButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButtonCancelSaveSettings = new DevExpress.XtraEditors.SimpleButton();
            this.lciCancelSaveSettingsButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextSettingsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPaneSettings)).BeginInit();
            this.navigationPaneSettings.SuspendLayout();
            this.navigationPageQuerySettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lclQuerySettings)).BeginInit();
            this.lclQuerySettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgEnvironment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgQueryScripting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgQueryExecution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNumberOfRowsForSelectTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNumberOfRowsForTopScript.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSettings)).BeginInit();
            this.lcSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShowRowNumberColumn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSettingsNavigationPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciShowRowNumberInGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSaveSettingsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancelSaveSettingsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContextSettingsView
            // 
            this.mvvmContextSettingsView.ContainerControl = this;
            this.mvvmContextSettingsView.ViewModelType = typeof(Databvase_Winforms.View_Models.SettingsViewModel);
            // 
            // navigationPaneSettings
            // 
            this.navigationPaneSettings.Controls.Add(this.navigationPageQuerySettings);
            this.navigationPaneSettings.Controls.Add(this.navigationPageTextEditor);
            this.navigationPaneSettings.Controls.Add(this.navigationPageObjectExplorer);
            this.navigationPaneSettings.Controls.Add(this.navigationPageEnvironment);
            this.navigationPaneSettings.Location = new System.Drawing.Point(12, 12);
            this.navigationPaneSettings.Name = "navigationPaneSettings";
            this.navigationPaneSettings.PageProperties.AllowBorderColorBlending = true;
            this.navigationPaneSettings.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.navigationPaneSettings.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPageEnvironment,
            this.navigationPageQuerySettings,
            this.navigationPageObjectExplorer,
            this.navigationPageTextEditor});
            this.navigationPaneSettings.RegularSize = new System.Drawing.Size(760, 511);
            this.navigationPaneSettings.SelectedPage = this.navigationPageEnvironment;
            this.navigationPaneSettings.Size = new System.Drawing.Size(760, 511);
            this.navigationPaneSettings.TabIndex = 0;
            this.navigationPaneSettings.Text = "Settings";
            // 
            // navigationPageQuerySettings
            // 
            this.navigationPageQuerySettings.Caption = "Query Settings";
            this.navigationPageQuerySettings.Controls.Add(this.lclQuerySettings);
            this.navigationPageQuerySettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("navigationPageQuerySettings.ImageOptions.Image")));
            this.navigationPageQuerySettings.Name = "navigationPageQuerySettings";
            this.navigationPageQuerySettings.Size = new System.Drawing.Size(637, 463);
            // 
            // lclQuerySettings
            // 
            this.lclQuerySettings.Controls.Add(this.spinEditNumberOfRowsForTopScript);
            this.lclQuerySettings.Controls.Add(this.checkEditShowRowNumberColumn);
            this.lclQuerySettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lclQuerySettings.Location = new System.Drawing.Point(0, 0);
            this.lclQuerySettings.Name = "lclQuerySettings";
            this.lclQuerySettings.Root = this.lcgEnvironment;
            this.lclQuerySettings.Size = new System.Drawing.Size(637, 463);
            this.lclQuerySettings.TabIndex = 0;
            this.lclQuerySettings.Text = "layoutControl1";
            // 
            // lcgEnvironment
            // 
            this.lcgEnvironment.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgEnvironment.GroupBordersVisible = false;
            this.lcgEnvironment.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.lcgQueryScripting,
            this.lcgQueryExecution,
            this.emptySpaceItem2});
            this.lcgEnvironment.Name = "lcgEnvironment";
            this.lcgEnvironment.OptionsItemText.TextToControlDistance = 5;
            this.lcgEnvironment.Size = new System.Drawing.Size(637, 463);
            this.lcgEnvironment.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 304);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(617, 139);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgQueryScripting
            // 
            this.lcgQueryScripting.CustomizationFormText = "Query Scripting";
            this.lcgQueryScripting.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem3,
            this.lciNumberOfRowsForSelectTop,
            this.emptySpaceItem7});
            this.lcgQueryScripting.Location = new System.Drawing.Point(0, 164);
            this.lcgQueryScripting.Name = "lcgQueryScripting";
            this.lcgQueryScripting.OptionsItemText.TextToControlDistance = 5;
            this.lcgQueryScripting.Size = new System.Drawing.Size(617, 140);
            this.lcgQueryScripting.Text = "Query Scripting";
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(593, 67);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgQueryExecution
            // 
            this.lcgQueryExecution.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem4,
            this.lciShowRowNumberInGrid});
            this.lcgQueryExecution.Location = new System.Drawing.Point(0, 0);
            this.lcgQueryExecution.Name = "lcgQueryExecution";
            this.lcgQueryExecution.OptionsItemText.TextToControlDistance = 5;
            this.lcgQueryExecution.Size = new System.Drawing.Size(617, 140);
            this.lcgQueryExecution.Text = "Query Execution";
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(593, 67);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 140);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(617, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciNumberOfRowsForSelectTop
            // 
            this.lciNumberOfRowsForSelectTop.Control = this.spinEditNumberOfRowsForTopScript;
            this.lciNumberOfRowsForSelectTop.Location = new System.Drawing.Point(0, 0);
            this.lciNumberOfRowsForSelectTop.Name = "lciNumberOfRowsForSelectTop";
            this.lciNumberOfRowsForSelectTop.Size = new System.Drawing.Size(483, 24);
            this.lciNumberOfRowsForSelectTop.Text = "Number Of Rows For Select Top * Script";
            this.lciNumberOfRowsForSelectTop.TextSize = new System.Drawing.Size(192, 13);
            // 
            // spinEditNumberOfRowsForTopScript
            // 
            this.spinEditNumberOfRowsForTopScript.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditNumberOfRowsForTopScript.Location = new System.Drawing.Point(221, 213);
            this.spinEditNumberOfRowsForTopScript.Name = "spinEditNumberOfRowsForTopScript";
            this.spinEditNumberOfRowsForTopScript.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditNumberOfRowsForTopScript.Size = new System.Drawing.Size(282, 20);
            this.spinEditNumberOfRowsForTopScript.StyleController = this.lclQuerySettings;
            this.spinEditNumberOfRowsForTopScript.TabIndex = 5;
            // 
            // lcSettings
            // 
            this.lcSettings.Controls.Add(this.simpleButtonCancelSaveSettings);
            this.lcSettings.Controls.Add(this.simpleButtonSaveSettings);
            this.lcSettings.Controls.Add(this.navigationPaneSettings);
            this.lcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcSettings.Location = new System.Drawing.Point(0, 0);
            this.lcSettings.Name = "lcSettings";
            this.lcSettings.Root = this.lcgSettings;
            this.lcSettings.Size = new System.Drawing.Size(784, 561);
            this.lcSettings.TabIndex = 1;
            this.lcSettings.Text = "layoutControl1";
            // 
            // checkEditShowRowNumberColumn
            // 
            this.checkEditShowRowNumberColumn.Location = new System.Drawing.Point(24, 49);
            this.checkEditShowRowNumberColumn.Name = "checkEditShowRowNumberColumn";
            this.checkEditShowRowNumberColumn.Properties.Caption = "Show Row Number Column In Query Results";
            this.checkEditShowRowNumberColumn.Size = new System.Drawing.Size(589, 20);
            this.checkEditShowRowNumberColumn.StyleController = this.lclQuerySettings;
            this.checkEditShowRowNumberColumn.TabIndex = 4;
            // 
            // lcgSettings
            // 
            this.lcgSettings.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgSettings.GroupBordersVisible = false;
            this.lcgSettings.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSettingsNavigationPane,
            this.lciSaveSettingsButton,
            this.lciCancelSaveSettingsButton,
            this.emptySpaceItem5,
            this.emptySpaceItem6});
            this.lcgSettings.Name = "lcgSettings";
            this.lcgSettings.Size = new System.Drawing.Size(784, 561);
            this.lcgSettings.TextVisible = false;
            // 
            // lciSettingsNavigationPane
            // 
            this.lciSettingsNavigationPane.Control = this.navigationPaneSettings;
            this.lciSettingsNavigationPane.Location = new System.Drawing.Point(0, 0);
            this.lciSettingsNavigationPane.Name = "lciSettingsNavigationPane";
            this.lciSettingsNavigationPane.Size = new System.Drawing.Size(764, 515);
            this.lciSettingsNavigationPane.TextSize = new System.Drawing.Size(0, 0);
            this.lciSettingsNavigationPane.TextVisible = false;
            // 
            // lciShowRowNumberInGrid
            // 
            this.lciShowRowNumberInGrid.Control = this.checkEditShowRowNumberColumn;
            this.lciShowRowNumberInGrid.Location = new System.Drawing.Point(0, 0);
            this.lciShowRowNumberInGrid.Name = "lciShowRowNumberInGrid";
            this.lciShowRowNumberInGrid.Size = new System.Drawing.Size(593, 24);
            this.lciShowRowNumberInGrid.TextSize = new System.Drawing.Size(0, 0);
            this.lciShowRowNumberInGrid.TextVisible = false;
            // 
            // navigationPageTextEditor
            // 
            this.navigationPageTextEditor.Caption = "Text Editor";
            this.navigationPageTextEditor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("navigationPageTextEditor.ImageOptions.Image")));
            this.navigationPageTextEditor.Name = "navigationPageTextEditor";
            this.navigationPageTextEditor.Size = new System.Drawing.Size(637, 463);
            // 
            // navigationPageObjectExplorer
            // 
            this.navigationPageObjectExplorer.Caption = "Object Explorer";
            this.navigationPageObjectExplorer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("navigationPageObjectExplorer.ImageOptions.Image")));
            this.navigationPageObjectExplorer.Name = "navigationPageObjectExplorer";
            this.navigationPageObjectExplorer.Size = new System.Drawing.Size(637, 463);
            // 
            // navigationPageEnvironment
            // 
            this.navigationPageEnvironment.Caption = "Environment";
            this.navigationPageEnvironment.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("navigationPageEnvironment.ImageOptions.Image")));
            this.navigationPageEnvironment.Name = "navigationPageEnvironment";
            this.navigationPageEnvironment.Size = new System.Drawing.Size(637, 463);
            // 
            // simpleButtonSaveSettings
            // 
            this.simpleButtonSaveSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSaveSettings.ImageOptions.Image")));
            this.simpleButtonSaveSettings.Location = new System.Drawing.Point(466, 527);
            this.simpleButtonSaveSettings.Name = "simpleButtonSaveSettings";
            this.simpleButtonSaveSettings.Size = new System.Drawing.Size(144, 22);
            this.simpleButtonSaveSettings.StyleController = this.lcSettings;
            this.simpleButtonSaveSettings.TabIndex = 4;
            this.simpleButtonSaveSettings.Text = "OK";
            // 
            // lciSaveSettingsButton
            // 
            this.lciSaveSettingsButton.Control = this.simpleButtonSaveSettings;
            this.lciSaveSettingsButton.Location = new System.Drawing.Point(454, 515);
            this.lciSaveSettingsButton.Name = "lciSaveSettingsButton";
            this.lciSaveSettingsButton.Size = new System.Drawing.Size(148, 26);
            this.lciSaveSettingsButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciSaveSettingsButton.TextVisible = false;
            // 
            // simpleButtonCancelSaveSettings
            // 
            this.simpleButtonCancelSaveSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCancelSaveSettings.ImageOptions.Image")));
            this.simpleButtonCancelSaveSettings.Location = new System.Drawing.Point(645, 527);
            this.simpleButtonCancelSaveSettings.Name = "simpleButtonCancelSaveSettings";
            this.simpleButtonCancelSaveSettings.Size = new System.Drawing.Size(127, 22);
            this.simpleButtonCancelSaveSettings.StyleController = this.lcSettings;
            this.simpleButtonCancelSaveSettings.TabIndex = 5;
            this.simpleButtonCancelSaveSettings.Text = "Cancel";
            // 
            // lciCancelSaveSettingsButton
            // 
            this.lciCancelSaveSettingsButton.Control = this.simpleButtonCancelSaveSettings;
            this.lciCancelSaveSettingsButton.Location = new System.Drawing.Point(633, 515);
            this.lciCancelSaveSettingsButton.Name = "lciCancelSaveSettingsButton";
            this.lciCancelSaveSettingsButton.Size = new System.Drawing.Size(131, 26);
            this.lciCancelSaveSettingsButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciCancelSaveSettingsButton.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(602, 515);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(31, 26);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(0, 515);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(454, 26);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(483, 0);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(110, 24);
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lcSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsView";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextSettingsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPaneSettings)).EndInit();
            this.navigationPaneSettings.ResumeLayout(false);
            this.navigationPageQuerySettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lclQuerySettings)).EndInit();
            this.lclQuerySettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgEnvironment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgQueryScripting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgQueryExecution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNumberOfRowsForSelectTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNumberOfRowsForTopScript.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSettings)).EndInit();
            this.lcSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShowRowNumberColumn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSettingsNavigationPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciShowRowNumberInGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSaveSettingsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancelSaveSettingsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContextSettingsView;
        private DevExpress.XtraBars.Navigation.NavigationPane navigationPaneSettings;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageQuerySettings;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageTextEditor;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageObjectExplorer;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageEnvironment;
        private DevExpress.XtraLayout.LayoutControl lclQuerySettings;
        private DevExpress.XtraLayout.LayoutControlGroup lcgEnvironment;
        private DevExpress.XtraEditors.SpinEdit spinEditNumberOfRowsForTopScript;
        private DevExpress.XtraEditors.CheckEdit checkEditShowRowNumberColumn;
        private DevExpress.XtraLayout.LayoutControlGroup lcgQueryScripting;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgQueryExecution;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControl lcSettings;
        private DevExpress.XtraLayout.LayoutControlItem lciNumberOfRowsForSelectTop;
        private DevExpress.XtraLayout.LayoutControlItem lciShowRowNumberInGrid;
        private DevExpress.XtraLayout.LayoutControlGroup lcgSettings;
        private DevExpress.XtraLayout.LayoutControlItem lciSettingsNavigationPane;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancelSaveSettings;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSaveSettings;
        private DevExpress.XtraLayout.LayoutControlItem lciSaveSettingsButton;
        private DevExpress.XtraLayout.LayoutControlItem lciCancelSaveSettingsButton;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
    }
}