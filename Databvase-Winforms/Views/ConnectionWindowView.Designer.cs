using Databvase_Winforms.View_Models;

namespace Databvase_Winforms.Views
{
    partial class ConnectionWindowView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionWindowView));
            this.navigationFrame = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPageConnectionStringManager = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.lcFrame1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCreateNewString = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonConnect = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditConnectionStrings = new DevExpress.XtraEditors.LookUpEdit();
            this.lcgFrame1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcConnectionStringsLookUp = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciConnectButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.emptySpaceItem19 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.navigationPageConnetionStringBuilder = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.lciConnectionStringBuilder = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButtonSaveAndTest = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlNote = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonCancelCreateConnection = new DevExpress.XtraEditors.SimpleButton();
            this.textEditNickName = new DevExpress.XtraEditors.TextEdit();
            this.textEditPassword = new DevExpress.XtraEditors.TextEdit();
            this.textEditUserName = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonQueryInstances = new DevExpress.XtraEditors.SimpleButton();
            this.checkEditWindowsAuthentication = new DevExpress.XtraEditors.CheckEdit();
            this.spinEditConnectionTimeout = new DevExpress.XtraEditors.SpinEdit();
            this.comboBoxEditInstances = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lcgConnectionStringBuilder = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciInstances = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGetInstances = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNickname = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem13 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem14 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem15 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem16 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciTestAndSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem18 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem20 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem21 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem24 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem25 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem17 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem26 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
            this.lciWindowsAuthentication = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem22 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem28 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem29 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleSeparator3 = new DevExpress.XtraLayout.SimpleSeparator();
            this.lciNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTimeout = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Databvase_Winforms.Views.WaitSplashyView), true, true);
            this.mvvmContextConnectionStringView = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).BeginInit();
            this.navigationFrame.SuspendLayout();
            this.navigationPageConnectionStringManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcFrame1)).BeginInit();
            this.lcFrame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditConnectionStrings.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFrame1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcConnectionStringsLookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConnectButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem19)).BeginInit();
            this.navigationPageConnetionStringBuilder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lciConnectionStringBuilder)).BeginInit();
            this.lciConnectionStringBuilder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNickName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditWindowsAuthentication.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditConnectionTimeout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditInstances.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgConnectionStringBuilder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciInstances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGetInstances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNickname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTestAndSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWindowsAuthentication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextConnectionStringView)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationFrame
            // 
            this.navigationFrame.Controls.Add(this.navigationPageConnectionStringManager);
            this.navigationFrame.Controls.Add(this.navigationPageConnetionStringBuilder);
            this.navigationFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame.Name = "navigationFrame";
            this.navigationFrame.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPageConnectionStringManager,
            this.navigationPageConnetionStringBuilder});
            this.navigationFrame.SelectedPage = this.navigationPageConnectionStringManager;
            this.navigationFrame.Size = new System.Drawing.Size(609, 353);
            this.navigationFrame.TabIndex = 0;
            this.navigationFrame.Text = "navigationFrame1";
            // 
            // navigationPageConnectionStringManager
            // 
            this.navigationPageConnectionStringManager.Controls.Add(this.lcFrame1);
            this.navigationPageConnectionStringManager.Name = "navigationPageConnectionStringManager";
            this.navigationPageConnectionStringManager.Size = new System.Drawing.Size(609, 353);
            // 
            // lcFrame1
            // 
            this.lcFrame1.Controls.Add(this.simpleButtonCancel);
            this.lcFrame1.Controls.Add(this.simpleButtonCreateNewString);
            this.lcFrame1.Controls.Add(this.simpleButtonConnect);
            this.lcFrame1.Controls.Add(this.lookUpEditConnectionStrings);
            this.lcFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcFrame1.Location = new System.Drawing.Point(0, 0);
            this.lcFrame1.Name = "lcFrame1";
            this.lcFrame1.Root = this.lcgFrame1;
            this.lcFrame1.Size = new System.Drawing.Size(609, 353);
            this.lcFrame1.TabIndex = 0;
            this.lcFrame1.Text = "layoutControl1";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonCancel.Appearance.Options.UseFont = true;
            this.simpleButtonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCancel.ImageOptions.Image")));
            this.simpleButtonCancel.Location = new System.Drawing.Point(497, 283);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(90, 23);
            this.simpleButtonCancel.StyleController = this.lcFrame1;
            this.simpleButtonCancel.TabIndex = 7;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonCreateNewString
            // 
            this.simpleButtonCreateNewString.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonCreateNewString.Appearance.Options.UseFont = true;
            this.simpleButtonCreateNewString.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCreateNewString.ImageOptions.Image")));
            this.simpleButtonCreateNewString.Location = new System.Drawing.Point(260, 283);
            this.simpleButtonCreateNewString.Name = "simpleButtonCreateNewString";
            this.simpleButtonCreateNewString.Size = new System.Drawing.Size(212, 23);
            this.simpleButtonCreateNewString.StyleController = this.lcFrame1;
            this.simpleButtonCreateNewString.TabIndex = 6;
            this.simpleButtonCreateNewString.Text = "Create A New Connection String";
            // 
            // simpleButtonConnect
            // 
            this.simpleButtonConnect.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonConnect.Appearance.Options.UseFont = true;
            this.simpleButtonConnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonConnect.ImageOptions.Image")));
            this.simpleButtonConnect.Location = new System.Drawing.Point(103, 283);
            this.simpleButtonConnect.Name = "simpleButtonConnect";
            this.simpleButtonConnect.Size = new System.Drawing.Size(125, 23);
            this.simpleButtonConnect.StyleController = this.lcFrame1;
            this.simpleButtonConnect.TabIndex = 5;
            this.simpleButtonConnect.Text = "Connect!";
            // 
            // lookUpEditConnectionStrings
            // 
            this.lookUpEditConnectionStrings.Location = new System.Drawing.Point(12, 99);
            this.lookUpEditConnectionStrings.Name = "lookUpEditConnectionStrings";
            this.lookUpEditConnectionStrings.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditConnectionStrings.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditConnectionStrings.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditConnectionStrings.Properties.NullText = "";
            this.lookUpEditConnectionStrings.Size = new System.Drawing.Size(585, 30);
            this.lookUpEditConnectionStrings.StyleController = this.lcFrame1;
            this.lookUpEditConnectionStrings.TabIndex = 4;
            // 
            // lcgFrame1
            // 
            this.lcgFrame1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgFrame1.GroupBordersVisible = false;
            this.lcgFrame1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcConnectionStringsLookUp,
            this.lciConnectButton,
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.emptySpaceItem3,
            this.emptySpaceItem1,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.layoutControlItem2,
            this.emptySpaceItem7,
            this.simpleSeparator1,
            this.emptySpaceItem19});
            this.lcgFrame1.Name = "Root";
            this.lcgFrame1.Size = new System.Drawing.Size(609, 353);
            this.lcgFrame1.TextVisible = false;
            // 
            // lcConnectionStringsLookUp
            // 
            this.lcConnectionStringsLookUp.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcConnectionStringsLookUp.AppearanceItemCaption.Options.UseFont = true;
            this.lcConnectionStringsLookUp.Control = this.lookUpEditConnectionStrings;
            this.lcConnectionStringsLookUp.Location = new System.Drawing.Point(0, 65);
            this.lcConnectionStringsLookUp.Name = "lcConnectionStringsLookUp";
            this.lcConnectionStringsLookUp.Size = new System.Drawing.Size(589, 56);
            this.lcConnectionStringsLookUp.Text = "Saved Connection Strings";
            this.lcConnectionStringsLookUp.TextLocation = DevExpress.Utils.Locations.Top;
            this.lcConnectionStringsLookUp.TextSize = new System.Drawing.Size(180, 19);
            // 
            // lciConnectButton
            // 
            this.lciConnectButton.Control = this.simpleButtonConnect;
            this.lciConnectButton.Location = new System.Drawing.Point(91, 271);
            this.lciConnectButton.Name = "lciConnectButton";
            this.lciConnectButton.Size = new System.Drawing.Size(129, 27);
            this.lciConnectButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciConnectButton.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(589, 65);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButtonCreateNewString;
            this.layoutControlItem1.Location = new System.Drawing.Point(248, 271);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(216, 27);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(220, 271);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(28, 27);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 121);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(589, 148);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 298);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(589, 35);
            this.emptySpaceItem5.Text = "emptySpaceItem3";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(464, 271);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(21, 27);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButtonCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(485, 271);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(94, 27);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(579, 271);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(10, 27);
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(91, 269);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(498, 2);
            // 
            // emptySpaceItem19
            // 
            this.emptySpaceItem19.AllowHotTrack = false;
            this.emptySpaceItem19.Location = new System.Drawing.Point(0, 269);
            this.emptySpaceItem19.Name = "emptySpaceItem19";
            this.emptySpaceItem19.Size = new System.Drawing.Size(91, 29);
            this.emptySpaceItem19.TextSize = new System.Drawing.Size(0, 0);
            // 
            // navigationPageConnetionStringBuilder
            // 
            this.navigationPageConnetionStringBuilder.Controls.Add(this.lciConnectionStringBuilder);
            this.navigationPageConnetionStringBuilder.Name = "navigationPageConnetionStringBuilder";
            this.navigationPageConnetionStringBuilder.Size = new System.Drawing.Size(609, 353);
            // 
            // lciConnectionStringBuilder
            // 
            this.lciConnectionStringBuilder.Controls.Add(this.simpleButtonSaveAndTest);
            this.lciConnectionStringBuilder.Controls.Add(this.labelControlNote);
            this.lciConnectionStringBuilder.Controls.Add(this.simpleButtonCancelCreateConnection);
            this.lciConnectionStringBuilder.Controls.Add(this.textEditNickName);
            this.lciConnectionStringBuilder.Controls.Add(this.textEditPassword);
            this.lciConnectionStringBuilder.Controls.Add(this.textEditUserName);
            this.lciConnectionStringBuilder.Controls.Add(this.simpleButtonQueryInstances);
            this.lciConnectionStringBuilder.Controls.Add(this.checkEditWindowsAuthentication);
            this.lciConnectionStringBuilder.Controls.Add(this.spinEditConnectionTimeout);
            this.lciConnectionStringBuilder.Controls.Add(this.comboBoxEditInstances);
            this.lciConnectionStringBuilder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lciConnectionStringBuilder.Location = new System.Drawing.Point(0, 0);
            this.lciConnectionStringBuilder.Name = "lciConnectionStringBuilder";
            this.lciConnectionStringBuilder.Root = this.lcgConnectionStringBuilder;
            this.lciConnectionStringBuilder.Size = new System.Drawing.Size(609, 353);
            this.lciConnectionStringBuilder.TabIndex = 6;
            this.lciConnectionStringBuilder.Text = "layoutControl1";
            // 
            // simpleButtonSaveAndTest
            // 
            this.simpleButtonSaveAndTest.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonSaveAndTest.Appearance.Options.UseFont = true;
            this.simpleButtonSaveAndTest.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSaveAndTest.ImageOptions.Image")));
            this.simpleButtonSaveAndTest.Location = new System.Drawing.Point(88, 306);
            this.simpleButtonSaveAndTest.Name = "simpleButtonSaveAndTest";
            this.simpleButtonSaveAndTest.Size = new System.Drawing.Size(182, 23);
            this.simpleButtonSaveAndTest.StyleController = this.lciConnectionStringBuilder;
            this.simpleButtonSaveAndTest.TabIndex = 7;
            this.simpleButtonSaveAndTest.Text = "Test And Save!";
            // 
            // labelControlNote
            // 
            this.labelControlNote.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlNote.Appearance.Options.UseFont = true;
            this.labelControlNote.Location = new System.Drawing.Point(12, 12);
            this.labelControlNote.Name = "labelControlNote";
            this.labelControlNote.Size = new System.Drawing.Size(255, 25);
            this.labelControlNote.StyleController = this.lciConnectionStringBuilder;
            this.labelControlNote.TabIndex = 6;
            this.labelControlNote.Text = "Create A Connection String";
            // 
            // simpleButtonCancelCreateConnection
            // 
            this.simpleButtonCancelCreateConnection.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonCancelCreateConnection.Appearance.Options.UseFont = true;
            this.simpleButtonCancelCreateConnection.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCancelCreateConnection.ImageOptions.Image")));
            this.simpleButtonCancelCreateConnection.Location = new System.Drawing.Point(334, 306);
            this.simpleButtonCancelCreateConnection.Name = "simpleButtonCancelCreateConnection";
            this.simpleButtonCancelCreateConnection.Size = new System.Drawing.Size(157, 23);
            this.simpleButtonCancelCreateConnection.StyleController = this.lciConnectionStringBuilder;
            this.simpleButtonCancelCreateConnection.TabIndex = 2;
            this.simpleButtonCancelCreateConnection.Text = "Cancel";
            // 
            // textEditNickName
            // 
            this.textEditNickName.Location = new System.Drawing.Point(181, 249);
            this.textEditNickName.Name = "textEditNickName";
            this.textEditNickName.Size = new System.Drawing.Size(249, 20);
            this.textEditNickName.StyleController = this.lciConnectionStringBuilder;
            this.textEditNickName.TabIndex = 5;
            // 
            // textEditPassword
            // 
            this.textEditPassword.Location = new System.Drawing.Point(181, 178);
            this.textEditPassword.Name = "textEditPassword";
            this.textEditPassword.Size = new System.Drawing.Size(249, 20);
            this.textEditPassword.StyleController = this.lciConnectionStringBuilder;
            this.textEditPassword.TabIndex = 1;
            // 
            // textEditUserName
            // 
            this.textEditUserName.Location = new System.Drawing.Point(181, 144);
            this.textEditUserName.Name = "textEditUserName";
            this.textEditUserName.Size = new System.Drawing.Size(249, 20);
            this.textEditUserName.StyleController = this.lciConnectionStringBuilder;
            this.textEditUserName.TabIndex = 1;
            // 
            // simpleButtonQueryInstances
            // 
            this.simpleButtonQueryInstances.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonQueryInstances.Appearance.Options.UseFont = true;
            this.simpleButtonQueryInstances.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonQueryInstances.ImageOptions.Image")));
            this.simpleButtonQueryInstances.Location = new System.Drawing.Point(447, 73);
            this.simpleButtonQueryInstances.Name = "simpleButtonQueryInstances";
            this.simpleButtonQueryInstances.Size = new System.Drawing.Size(108, 23);
            this.simpleButtonQueryInstances.StyleController = this.lciConnectionStringBuilder;
            this.simpleButtonQueryInstances.TabIndex = 3;
            this.simpleButtonQueryInstances.Text = "Get Instances";
            // 
            // checkEditWindowsAuthentication
            // 
            this.checkEditWindowsAuthentication.Location = new System.Drawing.Point(185, 110);
            this.checkEditWindowsAuthentication.Name = "checkEditWindowsAuthentication";
            this.checkEditWindowsAuthentication.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditWindowsAuthentication.Properties.Appearance.Options.UseFont = true;
            this.checkEditWindowsAuthentication.Properties.Caption = "Use Windows Authentication";
            this.checkEditWindowsAuthentication.Size = new System.Drawing.Size(245, 20);
            this.checkEditWindowsAuthentication.StyleController = this.lciConnectionStringBuilder;
            this.checkEditWindowsAuthentication.TabIndex = 8;
            // 
            // spinEditConnectionTimeout
            // 
            this.spinEditConnectionTimeout.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditConnectionTimeout.Location = new System.Drawing.Point(181, 212);
            this.spinEditConnectionTimeout.Name = "spinEditConnectionTimeout";
            this.spinEditConnectionTimeout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditConnectionTimeout.Size = new System.Drawing.Size(249, 20);
            this.spinEditConnectionTimeout.StyleController = this.lciConnectionStringBuilder;
            this.spinEditConnectionTimeout.TabIndex = 9;
            // 
            // comboBoxEditInstances
            // 
            this.comboBoxEditInstances.Location = new System.Drawing.Point(181, 73);
            this.comboBoxEditInstances.Name = "comboBoxEditInstances";
            this.comboBoxEditInstances.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditInstances.Size = new System.Drawing.Size(249, 20);
            this.comboBoxEditInstances.StyleController = this.lciConnectionStringBuilder;
            this.comboBoxEditInstances.TabIndex = 4;
            // 
            // lcgConnectionStringBuilder
            // 
            this.lcgConnectionStringBuilder.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgConnectionStringBuilder.GroupBordersVisible = false;
            this.lcgConnectionStringBuilder.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciInstances,
            this.lciGetInstances,
            this.lciUserName,
            this.lciPassword,
            this.lciNickname,
            this.lciCancel,
            this.emptySpaceItem10,
            this.emptySpaceItem11,
            this.emptySpaceItem13,
            this.emptySpaceItem14,
            this.emptySpaceItem15,
            this.emptySpaceItem16,
            this.lciTestAndSave,
            this.emptySpaceItem18,
            this.emptySpaceItem20,
            this.emptySpaceItem21,
            this.emptySpaceItem24,
            this.emptySpaceItem25,
            this.emptySpaceItem17,
            this.emptySpaceItem26,
            this.simpleSeparator2,
            this.lciWindowsAuthentication,
            this.emptySpaceItem4,
            this.emptySpaceItem22,
            this.emptySpaceItem28,
            this.emptySpaceItem29,
            this.simpleSeparator3,
            this.lciNote,
            this.lciTimeout,
            this.emptySpaceItem8,
            this.emptySpaceItem9,
            this.emptySpaceItem12});
            this.lcgConnectionStringBuilder.Name = "lcgConnectionStringBuilder";
            this.lcgConnectionStringBuilder.Size = new System.Drawing.Size(609, 353);
            this.lcgConnectionStringBuilder.TextVisible = false;
            // 
            // lciInstances
            // 
            this.lciInstances.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lciInstances.AppearanceItemCaption.Options.UseFont = true;
            this.lciInstances.Control = this.comboBoxEditInstances;
            this.lciInstances.Location = new System.Drawing.Point(0, 61);
            this.lciInstances.Name = "lciInstances";
            this.lciInstances.Size = new System.Drawing.Size(422, 27);
            this.lciInstances.Text = "Server Instance";
            this.lciInstances.TextSize = new System.Drawing.Size(166, 16);
            // 
            // lciGetInstances
            // 
            this.lciGetInstances.Control = this.simpleButtonQueryInstances;
            this.lciGetInstances.Location = new System.Drawing.Point(435, 61);
            this.lciGetInstances.Name = "lciGetInstances";
            this.lciGetInstances.Size = new System.Drawing.Size(112, 27);
            this.lciGetInstances.Text = "Get Instances";
            this.lciGetInstances.TextSize = new System.Drawing.Size(0, 0);
            this.lciGetInstances.TextVisible = false;
            // 
            // lciUserName
            // 
            this.lciUserName.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lciUserName.AppearanceItemCaption.Options.UseFont = true;
            this.lciUserName.Control = this.textEditUserName;
            this.lciUserName.Location = new System.Drawing.Point(0, 132);
            this.lciUserName.Name = "lciUserName";
            this.lciUserName.Size = new System.Drawing.Size(422, 24);
            this.lciUserName.Text = "User Name";
            this.lciUserName.TextSize = new System.Drawing.Size(166, 16);
            // 
            // lciPassword
            // 
            this.lciPassword.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lciPassword.AppearanceItemCaption.Options.UseFont = true;
            this.lciPassword.Control = this.textEditPassword;
            this.lciPassword.CustomizationFormText = "Password";
            this.lciPassword.Location = new System.Drawing.Point(0, 166);
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.Size = new System.Drawing.Size(422, 24);
            this.lciPassword.Text = "Password";
            this.lciPassword.TextSize = new System.Drawing.Size(166, 16);
            // 
            // lciNickname
            // 
            this.lciNickname.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lciNickname.AppearanceItemCaption.Options.UseFont = true;
            this.lciNickname.Control = this.textEditNickName;
            this.lciNickname.Location = new System.Drawing.Point(0, 237);
            this.lciNickname.Name = "lciNickname";
            this.lciNickname.Size = new System.Drawing.Size(422, 24);
            this.lciNickname.Text = "Connection String NickName:";
            this.lciNickname.TextSize = new System.Drawing.Size(166, 16);
            // 
            // lciCancel
            // 
            this.lciCancel.Control = this.simpleButtonCancelCreateConnection;
            this.lciCancel.Location = new System.Drawing.Point(322, 294);
            this.lciCancel.Name = "lciCancel";
            this.lciCancel.Size = new System.Drawing.Size(161, 27);
            this.lciCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciCancel.TextVisible = false;
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.Location = new System.Drawing.Point(259, 0);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(330, 29);
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.Location = new System.Drawing.Point(422, 61);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(13, 27);
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem13
            // 
            this.emptySpaceItem13.AllowHotTrack = false;
            this.emptySpaceItem13.Location = new System.Drawing.Point(0, 156);
            this.emptySpaceItem13.Name = "emptySpaceItem13";
            this.emptySpaceItem13.Size = new System.Drawing.Size(589, 10);
            this.emptySpaceItem13.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem14
            // 
            this.emptySpaceItem14.AllowHotTrack = false;
            this.emptySpaceItem14.Location = new System.Drawing.Point(0, 190);
            this.emptySpaceItem14.Name = "emptySpaceItem14";
            this.emptySpaceItem14.Size = new System.Drawing.Size(589, 10);
            this.emptySpaceItem14.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem15
            // 
            this.emptySpaceItem15.AllowHotTrack = false;
            this.emptySpaceItem15.Location = new System.Drawing.Point(0, 261);
            this.emptySpaceItem15.Name = "emptySpaceItem15";
            this.emptySpaceItem15.Size = new System.Drawing.Size(589, 31);
            this.emptySpaceItem15.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem16
            // 
            this.emptySpaceItem16.AllowHotTrack = false;
            this.emptySpaceItem16.Location = new System.Drawing.Point(0, 321);
            this.emptySpaceItem16.Name = "emptySpaceItem16";
            this.emptySpaceItem16.Size = new System.Drawing.Size(589, 12);
            this.emptySpaceItem16.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciTestAndSave
            // 
            this.lciTestAndSave.Control = this.simpleButtonSaveAndTest;
            this.lciTestAndSave.Location = new System.Drawing.Point(76, 294);
            this.lciTestAndSave.Name = "lciTestAndSave";
            this.lciTestAndSave.Size = new System.Drawing.Size(186, 27);
            this.lciTestAndSave.TextSize = new System.Drawing.Size(0, 0);
            this.lciTestAndSave.TextVisible = false;
            // 
            // emptySpaceItem18
            // 
            this.emptySpaceItem18.AllowHotTrack = false;
            this.emptySpaceItem18.Location = new System.Drawing.Point(0, 88);
            this.emptySpaceItem18.Name = "emptySpaceItem18";
            this.emptySpaceItem18.Size = new System.Drawing.Size(589, 10);
            this.emptySpaceItem18.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem20
            // 
            this.emptySpaceItem20.AllowHotTrack = false;
            this.emptySpaceItem20.Location = new System.Drawing.Point(422, 237);
            this.emptySpaceItem20.Name = "emptySpaceItem20";
            this.emptySpaceItem20.Size = new System.Drawing.Size(167, 24);
            this.emptySpaceItem20.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem21
            // 
            this.emptySpaceItem21.AllowHotTrack = false;
            this.emptySpaceItem21.Location = new System.Drawing.Point(422, 166);
            this.emptySpaceItem21.Name = "emptySpaceItem21";
            this.emptySpaceItem21.Size = new System.Drawing.Size(167, 24);
            this.emptySpaceItem21.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem24
            // 
            this.emptySpaceItem24.AllowHotTrack = false;
            this.emptySpaceItem24.Location = new System.Drawing.Point(547, 61);
            this.emptySpaceItem24.Name = "emptySpaceItem24";
            this.emptySpaceItem24.Size = new System.Drawing.Size(42, 27);
            this.emptySpaceItem24.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem25
            // 
            this.emptySpaceItem25.AllowHotTrack = false;
            this.emptySpaceItem25.Location = new System.Drawing.Point(262, 294);
            this.emptySpaceItem25.Name = "emptySpaceItem25";
            this.emptySpaceItem25.Size = new System.Drawing.Size(60, 27);
            this.emptySpaceItem25.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem17
            // 
            this.emptySpaceItem17.AllowHotTrack = false;
            this.emptySpaceItem17.Location = new System.Drawing.Point(0, 294);
            this.emptySpaceItem17.Name = "emptySpaceItem17";
            this.emptySpaceItem17.Size = new System.Drawing.Size(76, 27);
            this.emptySpaceItem17.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem26
            // 
            this.emptySpaceItem26.AllowHotTrack = false;
            this.emptySpaceItem26.Location = new System.Drawing.Point(483, 294);
            this.emptySpaceItem26.Name = "emptySpaceItem26";
            this.emptySpaceItem26.Size = new System.Drawing.Size(106, 27);
            this.emptySpaceItem26.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleSeparator2
            // 
            this.simpleSeparator2.AllowHotTrack = false;
            this.simpleSeparator2.Location = new System.Drawing.Point(0, 292);
            this.simpleSeparator2.Name = "simpleSeparator2";
            this.simpleSeparator2.Size = new System.Drawing.Size(589, 2);
            // 
            // lciWindowsAuthentication
            // 
            this.lciWindowsAuthentication.Control = this.checkEditWindowsAuthentication;
            this.lciWindowsAuthentication.Location = new System.Drawing.Point(173, 98);
            this.lciWindowsAuthentication.Name = "lciWindowsAuthentication";
            this.lciWindowsAuthentication.Size = new System.Drawing.Size(249, 24);
            this.lciWindowsAuthentication.TextSize = new System.Drawing.Size(0, 0);
            this.lciWindowsAuthentication.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(422, 132);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(167, 24);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem22
            // 
            this.emptySpaceItem22.AllowHotTrack = false;
            this.emptySpaceItem22.Location = new System.Drawing.Point(0, 122);
            this.emptySpaceItem22.Name = "emptySpaceItem22";
            this.emptySpaceItem22.Size = new System.Drawing.Size(589, 10);
            this.emptySpaceItem22.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem28
            // 
            this.emptySpaceItem28.AllowHotTrack = false;
            this.emptySpaceItem28.Location = new System.Drawing.Point(0, 98);
            this.emptySpaceItem28.Name = "emptySpaceItem28";
            this.emptySpaceItem28.Size = new System.Drawing.Size(173, 24);
            this.emptySpaceItem28.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem29
            // 
            this.emptySpaceItem29.AllowHotTrack = false;
            this.emptySpaceItem29.Location = new System.Drawing.Point(422, 98);
            this.emptySpaceItem29.Name = "emptySpaceItem29";
            this.emptySpaceItem29.Size = new System.Drawing.Size(167, 24);
            this.emptySpaceItem29.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleSeparator3
            // 
            this.simpleSeparator3.AllowHotTrack = false;
            this.simpleSeparator3.Location = new System.Drawing.Point(0, 59);
            this.simpleSeparator3.Name = "simpleSeparator3";
            this.simpleSeparator3.Size = new System.Drawing.Size(589, 2);
            // 
            // lciNote
            // 
            this.lciNote.Control = this.labelControlNote;
            this.lciNote.Location = new System.Drawing.Point(0, 0);
            this.lciNote.Name = "lciNote";
            this.lciNote.Size = new System.Drawing.Size(259, 29);
            this.lciNote.TextSize = new System.Drawing.Size(0, 0);
            this.lciNote.TextVisible = false;
            // 
            // lciTimeout
            // 
            this.lciTimeout.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lciTimeout.AppearanceItemCaption.Options.UseFont = true;
            this.lciTimeout.Control = this.spinEditConnectionTimeout;
            this.lciTimeout.Location = new System.Drawing.Point(0, 200);
            this.lciTimeout.Name = "lciTimeout";
            this.lciTimeout.Size = new System.Drawing.Size(422, 24);
            this.lciTimeout.Text = "Connection Timeout";
            this.lciTimeout.TextSize = new System.Drawing.Size(166, 16);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.Location = new System.Drawing.Point(422, 200);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(167, 37);
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.Location = new System.Drawing.Point(0, 224);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(422, 13);
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            this.emptySpaceItem12.Location = new System.Drawing.Point(0, 29);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(589, 30);
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // mvvmContextConnectionStringView
            // 
            this.mvvmContextConnectionStringView.ContainerControl = this;
            this.mvvmContextConnectionStringView.ViewModelType = typeof(Databvase_Winforms.View_Models.ConnectionWindowViewModel);
            // 
            // ConnectionWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 353);
            this.Controls.Add(this.navigationFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionWindowView";
            this.Text = "Connect To A Server";
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).EndInit();
            this.navigationFrame.ResumeLayout(false);
            this.navigationPageConnectionStringManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcFrame1)).EndInit();
            this.lcFrame1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditConnectionStrings.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFrame1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcConnectionStringsLookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConnectButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem19)).EndInit();
            this.navigationPageConnetionStringBuilder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lciConnectionStringBuilder)).EndInit();
            this.lciConnectionStringBuilder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditNickName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditWindowsAuthentication.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditConnectionTimeout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditInstances.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgConnectionStringBuilder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciInstances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGetInstances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNickname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTestAndSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWindowsAuthentication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextConnectionStringView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContextConnectionStringView;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageConnectionStringManager;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageConnetionStringBuilder;
        private DevExpress.XtraLayout.LayoutControl lcFrame1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgFrame1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditConnectionStrings;
        private DevExpress.XtraLayout.LayoutControlItem lcConnectionStringsLookUp;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonConnect;
        private DevExpress.XtraLayout.LayoutControlItem lciConnectButton;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCreateNewString;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit textEditPassword;
        private DevExpress.XtraEditors.TextEdit textEditUserName;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancelCreateConnection;
        private DevExpress.XtraEditors.SimpleButton simpleButtonQueryInstances;
        private DevExpress.XtraEditors.TextEdit textEditNickName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.LayoutControl lciConnectionStringBuilder;
        private DevExpress.XtraLayout.LayoutControlGroup lcgConnectionStringBuilder;
        private DevExpress.XtraLayout.LayoutControlItem lciInstances;
        private DevExpress.XtraLayout.LayoutControlItem lciGetInstances;
        private DevExpress.XtraLayout.LayoutControlItem lciUserName;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciNickname;
        private DevExpress.XtraLayout.LayoutControlItem lciCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSaveAndTest;
        private DevExpress.XtraEditors.LabelControl labelControlNote;
        private DevExpress.XtraLayout.LayoutControlItem lciNote;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem13;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem14;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem15;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem16;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem17;
        private DevExpress.XtraLayout.LayoutControlItem lciTestAndSave;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem18;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem20;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem21;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem24;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem25;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem26;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraEditors.CheckEdit checkEditWindowsAuthentication;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator2;
        private DevExpress.XtraLayout.LayoutControlItem lciWindowsAuthentication;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem19;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem22;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem28;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem29;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator3;
        private DevExpress.XtraEditors.SpinEdit spinEditConnectionTimeout;
        private DevExpress.XtraLayout.LayoutControlItem lciTimeout;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxEditInstances;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
    }
}