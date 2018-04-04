using LWSqlQueryTool_Winforms.View_Models;

namespace LWSqlQueryTool_Winforms.Views
{
    partial class ConnectionStringView
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
            this.navigationFrame = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPageConnectionStringManager = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.lcFrame1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCreateNewString = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonConnect = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditConnectionStrings = new DevExpress.XtraEditors.LookUpEdit();
            this.lcgFrame1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcConnectionStringsLookUp = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciConnectButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.navigationPageConnetionStringBuilder = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.simpleButtonCancelCreateConnection = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.textEditPassword = new DevExpress.XtraEditors.TextEdit();
            this.textEditUserName = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonQueryInstances = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonQueryDatabases = new DevExpress.XtraEditors.SimpleButton();
            this.mvvmContextConnectionStringView = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.comboBoxEditInstances = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditDatabases = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).BeginInit();
            this.navigationFrame.SuspendLayout();
            this.navigationPageConnectionStringManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcFrame1)).BeginInit();
            this.lcFrame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditConnectionStrings.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFrame1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcConnectionStringsLookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConnectButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.navigationPageConnetionStringBuilder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextConnectionStringView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditInstances.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDatabases.Properties)).BeginInit();
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
            this.navigationFrame.Size = new System.Drawing.Size(728, 516);
            this.navigationFrame.TabIndex = 0;
            this.navigationFrame.Text = "navigationFrame1";
            // 
            // navigationPageConnectionStringManager
            // 
            this.navigationPageConnectionStringManager.Caption = "navigationPage1";
            this.navigationPageConnectionStringManager.Controls.Add(this.lcFrame1);
            this.navigationPageConnectionStringManager.Name = "navigationPageConnectionStringManager";
            this.navigationPageConnectionStringManager.Size = new System.Drawing.Size(728, 516);
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
            this.lcFrame1.Size = new System.Drawing.Size(728, 516);
            this.lcFrame1.TabIndex = 0;
            this.lcFrame1.Text = "layoutControl1";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(12, 113);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(704, 22);
            this.simpleButtonCancel.StyleController = this.lcFrame1;
            this.simpleButtonCancel.TabIndex = 7;
            this.simpleButtonCancel.Text = "Get Outta Here (Cancel)";
            // 
            // simpleButtonCreateNewString
            // 
            this.simpleButtonCreateNewString.Location = new System.Drawing.Point(12, 87);
            this.simpleButtonCreateNewString.Name = "simpleButtonCreateNewString";
            this.simpleButtonCreateNewString.Size = new System.Drawing.Size(704, 22);
            this.simpleButtonCreateNewString.StyleController = this.lcFrame1;
            this.simpleButtonCreateNewString.TabIndex = 6;
            this.simpleButtonCreateNewString.Text = "Create A New Connection String";
            // 
            // simpleButtonConnect
            // 
            this.simpleButtonConnect.Location = new System.Drawing.Point(12, 61);
            this.simpleButtonConnect.Name = "simpleButtonConnect";
            this.simpleButtonConnect.Size = new System.Drawing.Size(704, 22);
            this.simpleButtonConnect.StyleController = this.lcFrame1;
            this.simpleButtonConnect.TabIndex = 5;
            this.simpleButtonConnect.Text = "Connect!";
            // 
            // lookUpEditConnectionStrings
            // 
            this.lookUpEditConnectionStrings.Location = new System.Drawing.Point(12, 31);
            this.lookUpEditConnectionStrings.Name = "lookUpEditConnectionStrings";
            this.lookUpEditConnectionStrings.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lookUpEditConnectionStrings.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditConnectionStrings.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditConnectionStrings.Size = new System.Drawing.Size(704, 26);
            this.lookUpEditConnectionStrings.StyleController = this.lcFrame1;
            this.lookUpEditConnectionStrings.TabIndex = 4;
            // 
            // lcgFrame1
            // 
            this.lcgFrame1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgFrame1.GroupBordersVisible = false;
            this.lcgFrame1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcConnectionStringsLookUp,
            this.emptySpaceItem1,
            this.lciConnectButton,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.lcgFrame1.Name = "lcgFrame1";
            this.lcgFrame1.Size = new System.Drawing.Size(728, 516);
            this.lcgFrame1.TextVisible = false;
            // 
            // lcConnectionStringsLookUp
            // 
            this.lcConnectionStringsLookUp.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcConnectionStringsLookUp.AppearanceItemCaption.Options.UseFont = true;
            this.lcConnectionStringsLookUp.Control = this.lookUpEditConnectionStrings;
            this.lcConnectionStringsLookUp.Location = new System.Drawing.Point(0, 0);
            this.lcConnectionStringsLookUp.Name = "lcConnectionStringsLookUp";
            this.lcConnectionStringsLookUp.Size = new System.Drawing.Size(708, 49);
            this.lcConnectionStringsLookUp.Text = "Saved Connection Strings";
            this.lcConnectionStringsLookUp.TextLocation = DevExpress.Utils.Locations.Top;
            this.lcConnectionStringsLookUp.TextSize = new System.Drawing.Size(146, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 127);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(708, 369);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciConnectButton
            // 
            this.lciConnectButton.Control = this.simpleButtonConnect;
            this.lciConnectButton.Location = new System.Drawing.Point(0, 49);
            this.lciConnectButton.Name = "lciConnectButton";
            this.lciConnectButton.Size = new System.Drawing.Size(708, 26);
            this.lciConnectButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciConnectButton.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButtonCreateNewString;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(708, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButtonCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 101);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(708, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // navigationPageConnetionStringBuilder
            // 
            this.navigationPageConnetionStringBuilder.Controls.Add(this.comboBoxEditDatabases);
            this.navigationPageConnetionStringBuilder.Controls.Add(this.comboBoxEditInstances);
            this.navigationPageConnetionStringBuilder.Controls.Add(this.simpleButtonQueryDatabases);
            this.navigationPageConnetionStringBuilder.Controls.Add(this.simpleButtonQueryInstances);
            this.navigationPageConnetionStringBuilder.Controls.Add(this.simpleButtonCancelCreateConnection);
            this.navigationPageConnetionStringBuilder.Controls.Add(this.simpleButtonSave);
            this.navigationPageConnetionStringBuilder.Controls.Add(this.textEditPassword);
            this.navigationPageConnetionStringBuilder.Controls.Add(this.textEditUserName);
            this.navigationPageConnetionStringBuilder.Name = "navigationPageConnetionStringBuilder";
            this.navigationPageConnetionStringBuilder.Size = new System.Drawing.Size(728, 516);
            // 
            // simpleButtonCancelCreateConnection
            // 
            this.simpleButtonCancelCreateConnection.Location = new System.Drawing.Point(397, 330);
            this.simpleButtonCancelCreateConnection.Name = "simpleButtonCancelCreateConnection";
            this.simpleButtonCancelCreateConnection.Size = new System.Drawing.Size(185, 32);
            this.simpleButtonCancelCreateConnection.TabIndex = 2;
            this.simpleButtonCancelCreateConnection.Text = "I Dont Feel Like Doing This (Go Back)";
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Location = new System.Drawing.Point(153, 330);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(185, 32);
            this.simpleButtonSave.TabIndex = 2;
            this.simpleButtonSave.Text = "Test Connection And Save!";
            // 
            // textEditPassword
            // 
            this.textEditPassword.Location = new System.Drawing.Point(183, 262);
            this.textEditPassword.Name = "textEditPassword";
            this.textEditPassword.Size = new System.Drawing.Size(335, 20);
            this.textEditPassword.TabIndex = 1;
            // 
            // textEditUserName
            // 
            this.textEditUserName.Location = new System.Drawing.Point(183, 215);
            this.textEditUserName.Name = "textEditUserName";
            this.textEditUserName.Size = new System.Drawing.Size(335, 20);
            this.textEditUserName.TabIndex = 1;
            // 
            // simpleButtonQueryInstances
            // 
            this.simpleButtonQueryInstances.Location = new System.Drawing.Point(525, 91);
            this.simpleButtonQueryInstances.Name = "simpleButtonQueryInstances";
            this.simpleButtonQueryInstances.Size = new System.Drawing.Size(112, 23);
            this.simpleButtonQueryInstances.TabIndex = 3;
            this.simpleButtonQueryInstances.Text = "Get Instances";
            // 
            // simpleButtonQueryDatabases
            // 
            this.simpleButtonQueryDatabases.Location = new System.Drawing.Point(525, 140);
            this.simpleButtonQueryDatabases.Name = "simpleButtonQueryDatabases";
            this.simpleButtonQueryDatabases.Size = new System.Drawing.Size(112, 23);
            this.simpleButtonQueryDatabases.TabIndex = 3;
            this.simpleButtonQueryDatabases.Text = "Get Databases";
            // 
            // mvvmContextConnectionStringView
            // 
            this.mvvmContextConnectionStringView.ContainerControl = this;
            this.mvvmContextConnectionStringView.ViewModelType = typeof(LWSqlQueryTool_Winforms.View_Models.ConnectionStringViewModel);
            // 
            // comboBoxEditInstances
            // 
            this.comboBoxEditInstances.Location = new System.Drawing.Point(184, 94);
            this.comboBoxEditInstances.Name = "comboBoxEditInstances";
            this.comboBoxEditInstances.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditInstances.Size = new System.Drawing.Size(335, 20);
            this.comboBoxEditInstances.TabIndex = 4;
            // 
            // comboBoxEditDatabases
            // 
            this.comboBoxEditDatabases.Location = new System.Drawing.Point(184, 143);
            this.comboBoxEditDatabases.Name = "comboBoxEditDatabases";
            this.comboBoxEditDatabases.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditDatabases.Size = new System.Drawing.Size(335, 20);
            this.comboBoxEditDatabases.TabIndex = 4;
            // 
            // ConnectionStringView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 516);
            this.Controls.Add(this.navigationFrame);
            this.Name = "ConnectionStringView";
            this.Text = "GoNecction?";
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).EndInit();
            this.navigationFrame.ResumeLayout(false);
            this.navigationPageConnectionStringManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcFrame1)).EndInit();
            this.lcFrame1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditConnectionStrings.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFrame1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcConnectionStringsLookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConnectButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.navigationPageConnetionStringBuilder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextConnectionStringView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditInstances.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDatabases.Properties)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.SimpleButton simpleButtonQueryDatabases;
        private DevExpress.XtraEditors.SimpleButton simpleButtonQueryInstances;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditDatabases;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditInstances;
    }
}