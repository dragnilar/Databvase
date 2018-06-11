using Databvase_Winforms.View_Models;

namespace Databvase_Winforms.Views
{
    partial class BackupView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupView));
            this.accordianBackup = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordianConnectionContainer = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.layoutControlConnection = new DevExpress.XtraLayout.LayoutControl();
            this.labelControlCurrentUser = new DevExpress.XtraEditors.LabelControl();
            this.labelControlServerName = new DevExpress.XtraEditors.LabelControl();
            this.lcgConnectionGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciServerName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCurrentUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.accordianProgressContainer = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.lcProgressPanel = new DevExpress.XtraLayout.LayoutControl();
            this.pictureEditProgressStatus = new DevExpress.XtraEditors.PictureEdit();
            this.progressBarControlDatabaseBackup = new DevExpress.XtraEditors.ProgressBarControl();
            this.lcgProgressPanel = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcProgressStatusImage = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciBackupProgressBar = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.accordionControlElementBackupPages = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordianElementGeneral = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordianElementMedia = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordianElementBackupOptions = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator2 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.accordianElementConnection = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator1 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.accordianElementProgress = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.lcBackupWindow = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.navigationFrameBackupWindow = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPageBackupGeneral = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.lciBackupGeneral = new DevExpress.XtraLayout.LayoutControl();
            this.checkEditCopyOnlyBackup = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButtonBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.textEditRecoveryModel = new DevExpress.XtraEditors.TextEdit();
            this.textEditBackupPath = new DevExpress.XtraEditors.TextEdit();
            this.imageComboBoxEditDatabaseList = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.imageComboBoxEditBackupType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lcgBackupGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgBackupSource = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciBackupDatabaseName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBackupType = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciRecoveryModel = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCopyOnlyBackup = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem24 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgBackupDestination = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciBackupPath = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciBrowseButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.navigationPageMediaOptions = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.lcMediaOptions = new DevExpress.XtraLayout.LayoutControl();
            this.checkEditVerifyBackup = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditContinueOnError = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditPerformChecksum = new DevExpress.XtraEditors.CheckEdit();
            this.memoEditNewMediaSetDescription = new DevExpress.XtraEditors.MemoEdit();
            this.textEditNewMediaSetName = new DevExpress.XtraEditors.TextEdit();
            this.radioGroupBackupNewMediaSet = new DevExpress.XtraEditors.RadioGroup();
            this.textEditMediaSetName = new DevExpress.XtraEditors.TextEdit();
            this.checkEditMediaSetName = new DevExpress.XtraEditors.CheckEdit();
            this.radioGroupAppendOrOverwriteBackupSet = new DevExpress.XtraEditors.RadioGroup();
            this.radioGroupBackupToExisting = new DevExpress.XtraEditors.RadioGroup();
            this.lcgMediaOptions = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem13 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgOverwriteMedia = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciOverwriteMedia = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAppendOrOverwrite = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCheckMediaSetName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcMediaSetName = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem14 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciBackupNewMediaSet = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem15 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciNewMediaSetDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem16 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciNewMediaSetName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgReliability = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciVerifyBacupWhenFinished = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPerformChecksum = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciContinueOnError = new DevExpress.XtraLayout.LayoutControlItem();
            this.navigationPageBackupOptions = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.lcBackupOptions = new DevExpress.XtraLayout.LayoutControl();
            this.dateEditExpireOnDate = new DevExpress.XtraEditors.DateEdit();
            this.spinEditExpireAfterDays = new DevExpress.XtraEditors.SpinEdit();
            this.radioGroupBackupSetExpire = new DevExpress.XtraEditors.RadioGroup();
            this.textEditBackupDescription = new DevExpress.XtraEditors.TextEdit();
            this.textEditBackupSetName = new DevExpress.XtraEditors.TextEdit();
            this.imageComboBoxEditCompressionSetting = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lcgBackupOptions = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem17 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgBackupSet = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciBackupName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBackupDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBackupSetExpire = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciExpireAfterDays = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciExpireOnDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem18 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem19 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem21 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem20 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem22 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem23 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgCompression = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciCompressionComboBox = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgBackupWindow = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciAccordian = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNavigationFrame = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCancelButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.lciOkButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.imageCollectionBackupView = new DevExpress.Utils.ImageCollection(this.components);
            this.mvvmContextBackupView = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordianBackup)).BeginInit();
            this.accordianBackup.SuspendLayout();
            this.accordianConnectionContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlConnection)).BeginInit();
            this.layoutControlConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgConnectionGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciServerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCurrentUser)).BeginInit();
            this.accordianProgressContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcProgressPanel)).BeginInit();
            this.lcProgressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditProgressStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlDatabaseBackup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgProgressPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcProgressStatusImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBackupWindow)).BeginInit();
            this.lcBackupWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrameBackupWindow)).BeginInit();
            this.navigationFrameBackupWindow.SuspendLayout();
            this.navigationPageBackupGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupGeneral)).BeginInit();
            this.lciBackupGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditCopyOnlyBackup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRecoveryModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBackupPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditDatabaseList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditBackupType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBackupGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBackupSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupDatabaseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRecoveryModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCopyOnlyBackup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBackupDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBrowseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            this.navigationPageMediaOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcMediaOptions)).BeginInit();
            this.lcMediaOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditVerifyBackup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditContinueOnError.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPerformChecksum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditNewMediaSetDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewMediaSetName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupBackupNewMediaSet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMediaSetName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditMediaSetName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupAppendOrOverwriteBackupSet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupBackupToExisting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMediaOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgOverwriteMedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOverwriteMedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAppendOrOverwrite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCheckMediaSetName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMediaSetName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupNewMediaSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNewMediaSetDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNewMediaSetName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgReliability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVerifyBacupWhenFinished)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPerformChecksum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciContinueOnError)).BeginInit();
            this.navigationPageBackupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcBackupOptions)).BeginInit();
            this.lcBackupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditExpireOnDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditExpireOnDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditExpireAfterDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupBackupSetExpire.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBackupDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBackupSetName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditCompressionSetting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBackupOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBackupSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupSetExpire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExpireAfterDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExpireOnDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCompression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCompressionComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBackupWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAccordian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNavigationFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOkButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionBackupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextBackupView)).BeginInit();
            this.SuspendLayout();
            // 
            // accordianBackup
            // 
            this.accordianBackup.Controls.Add(this.accordianConnectionContainer);
            this.accordianBackup.Controls.Add(this.accordianProgressContainer);
            this.accordianBackup.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementBackupPages});
            this.accordianBackup.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Multiple;
            this.accordianBackup.Location = new System.Drawing.Point(12, 12);
            this.accordianBackup.Name = "accordianBackup";
            this.accordianBackup.Size = new System.Drawing.Size(200, 510);
            this.accordianBackup.StyleController = this.lcBackupWindow;
            this.accordianBackup.TabIndex = 0;
            this.accordianBackup.Text = "Backup Menu";
            // 
            // accordianConnectionContainer
            // 
            this.accordianConnectionContainer.Controls.Add(this.layoutControlConnection);
            this.accordianConnectionContainer.Name = "accordianConnectionContainer";
            this.accordianConnectionContainer.Size = new System.Drawing.Size(181, 122);
            this.accordianConnectionContainer.TabIndex = 1;
            // 
            // layoutControlConnection
            // 
            this.layoutControlConnection.Controls.Add(this.labelControlCurrentUser);
            this.layoutControlConnection.Controls.Add(this.labelControlServerName);
            this.layoutControlConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlConnection.Location = new System.Drawing.Point(0, 0);
            this.layoutControlConnection.Name = "layoutControlConnection";
            this.layoutControlConnection.Root = this.lcgConnectionGroup;
            this.layoutControlConnection.Size = new System.Drawing.Size(181, 122);
            this.layoutControlConnection.TabIndex = 0;
            this.layoutControlConnection.Text = "layoutControl1";
            // 
            // labelControlCurrentUser
            // 
            this.labelControlCurrentUser.Location = new System.Drawing.Point(12, 61);
            this.labelControlCurrentUser.Name = "labelControlCurrentUser";
            this.labelControlCurrentUser.Size = new System.Drawing.Size(70, 13);
            this.labelControlCurrentUser.StyleController = this.layoutControlConnection;
            this.labelControlCurrentUser.TabIndex = 5;
            this.labelControlCurrentUser.Text = "[Current User]";
            // 
            // labelControlServerName
            // 
            this.labelControlServerName.Location = new System.Drawing.Point(12, 28);
            this.labelControlServerName.Name = "labelControlServerName";
            this.labelControlServerName.Size = new System.Drawing.Size(70, 13);
            this.labelControlServerName.StyleController = this.layoutControlConnection;
            this.labelControlServerName.TabIndex = 4;
            this.labelControlServerName.Text = "[Server Name]";
            // 
            // lcgConnectionGroup
            // 
            this.lcgConnectionGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgConnectionGroup.GroupBordersVisible = false;
            this.lcgConnectionGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.lciServerName,
            this.lciCurrentUser});
            this.lcgConnectionGroup.Name = "lcgConnectionGroup";
            this.lcgConnectionGroup.Size = new System.Drawing.Size(181, 122);
            this.lcgConnectionGroup.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 66);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(161, 36);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciServerName
            // 
            this.lciServerName.Control = this.labelControlServerName;
            this.lciServerName.Location = new System.Drawing.Point(0, 0);
            this.lciServerName.Name = "lciServerName";
            this.lciServerName.Size = new System.Drawing.Size(161, 33);
            this.lciServerName.Text = "Server:";
            this.lciServerName.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciServerName.TextSize = new System.Drawing.Size(66, 13);
            // 
            // lciCurrentUser
            // 
            this.lciCurrentUser.Control = this.labelControlCurrentUser;
            this.lciCurrentUser.Location = new System.Drawing.Point(0, 33);
            this.lciCurrentUser.Name = "lciCurrentUser";
            this.lciCurrentUser.Size = new System.Drawing.Size(161, 33);
            this.lciCurrentUser.Text = "Current User:";
            this.lciCurrentUser.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciCurrentUser.TextSize = new System.Drawing.Size(66, 13);
            // 
            // accordianProgressContainer
            // 
            this.accordianProgressContainer.Controls.Add(this.lcProgressPanel);
            this.accordianProgressContainer.Name = "accordianProgressContainer";
            this.accordianProgressContainer.Size = new System.Drawing.Size(181, 126);
            this.accordianProgressContainer.TabIndex = 2;
            // 
            // lcProgressPanel
            // 
            this.lcProgressPanel.Controls.Add(this.pictureEditProgressStatus);
            this.lcProgressPanel.Controls.Add(this.progressBarControlDatabaseBackup);
            this.lcProgressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcProgressPanel.Location = new System.Drawing.Point(0, 0);
            this.lcProgressPanel.Name = "lcProgressPanel";
            this.lcProgressPanel.Root = this.lcgProgressPanel;
            this.lcProgressPanel.Size = new System.Drawing.Size(181, 126);
            this.lcProgressPanel.TabIndex = 0;
            this.lcProgressPanel.Text = "layoutControl1";
            // 
            // pictureEditProgressStatus
            // 
            this.pictureEditProgressStatus.EditValue = ((object)(resources.GetObject("pictureEditProgressStatus.EditValue")));
            this.pictureEditProgressStatus.Location = new System.Drawing.Point(51, 12);
            this.pictureEditProgressStatus.Name = "pictureEditProgressStatus";
            this.pictureEditProgressStatus.Properties.AllowFocused = false;
            this.pictureEditProgressStatus.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEditProgressStatus.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEditProgressStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEditProgressStatus.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEditProgressStatus.Properties.ShowMenu = false;
            this.pictureEditProgressStatus.Size = new System.Drawing.Size(55, 40);
            this.pictureEditProgressStatus.StyleController = this.lcProgressPanel;
            this.pictureEditProgressStatus.TabIndex = 5;
            // 
            // progressBarControlDatabaseBackup
            // 
            this.progressBarControlDatabaseBackup.Location = new System.Drawing.Point(12, 71);
            this.progressBarControlDatabaseBackup.Name = "progressBarControlDatabaseBackup";
            this.progressBarControlDatabaseBackup.Properties.ShowTitle = true;
            this.progressBarControlDatabaseBackup.Size = new System.Drawing.Size(157, 18);
            this.progressBarControlDatabaseBackup.StyleController = this.lcProgressPanel;
            this.progressBarControlDatabaseBackup.TabIndex = 4;
            // 
            // lcgProgressPanel
            // 
            this.lcgProgressPanel.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgProgressPanel.GroupBordersVisible = false;
            this.lcgProgressPanel.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcProgressStatusImage,
            this.emptySpaceItem9,
            this.emptySpaceItem10,
            this.emptySpaceItem11,
            this.lciBackupProgressBar,
            this.emptySpaceItem12});
            this.lcgProgressPanel.Name = "lcgProgressPanel";
            this.lcgProgressPanel.Size = new System.Drawing.Size(181, 126);
            this.lcgProgressPanel.TextVisible = false;
            // 
            // lcProgressStatusImage
            // 
            this.lcProgressStatusImage.Control = this.pictureEditProgressStatus;
            this.lcProgressStatusImage.Location = new System.Drawing.Point(39, 0);
            this.lcProgressStatusImage.MaxSize = new System.Drawing.Size(93, 44);
            this.lcProgressStatusImage.MinSize = new System.Drawing.Size(93, 44);
            this.lcProgressStatusImage.Name = "lcProgressStatusImage";
            this.lcProgressStatusImage.Size = new System.Drawing.Size(93, 44);
            this.lcProgressStatusImage.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcProgressStatusImage.Text = "Ready";
            this.lcProgressStatusImage.TextLocation = DevExpress.Utils.Locations.Right;
            this.lcProgressStatusImage.TextSize = new System.Drawing.Size(31, 13);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.Location = new System.Drawing.Point(132, 0);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(29, 44);
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.Location = new System.Drawing.Point(0, 44);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(161, 15);
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(39, 44);
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciBackupProgressBar
            // 
            this.lciBackupProgressBar.Control = this.progressBarControlDatabaseBackup;
            this.lciBackupProgressBar.Location = new System.Drawing.Point(0, 59);
            this.lciBackupProgressBar.Name = "lciBackupProgressBar";
            this.lciBackupProgressBar.Size = new System.Drawing.Size(161, 22);
            this.lciBackupProgressBar.TextSize = new System.Drawing.Size(0, 0);
            this.lciBackupProgressBar.TextVisible = false;
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            this.emptySpaceItem12.Location = new System.Drawing.Point(0, 81);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(161, 25);
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // accordionControlElementBackupPages
            // 
            this.accordionControlElementBackupPages.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordianElementGeneral,
            this.accordianElementMedia,
            this.accordianElementBackupOptions,
            this.accordionControlSeparator2,
            this.accordianElementConnection,
            this.accordionControlSeparator1,
            this.accordianElementProgress});
            this.accordionControlElementBackupPages.Expanded = true;
            this.accordionControlElementBackupPages.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElementBackupPages.ImageOptions.SvgImage")));
            this.accordionControlElementBackupPages.Name = "accordionControlElementBackupPages";
            this.accordionControlElementBackupPages.Text = "Backup Settings";
            // 
            // accordianElementGeneral
            // 
            this.accordianElementGeneral.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordianElementGeneral.ImageOptions.Image")));
            this.accordianElementGeneral.Name = "accordianElementGeneral";
            this.accordianElementGeneral.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordianElementGeneral.Text = "General";
            // 
            // accordianElementMedia
            // 
            this.accordianElementMedia.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordianElementMedia.ImageOptions.Image")));
            this.accordianElementMedia.Name = "accordianElementMedia";
            this.accordianElementMedia.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordianElementMedia.Text = "Media Options";
            // 
            // accordianElementBackupOptions
            // 
            this.accordianElementBackupOptions.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordianElementBackupOptions.ImageOptions.SvgImage")));
            this.accordianElementBackupOptions.Name = "accordianElementBackupOptions";
            this.accordianElementBackupOptions.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordianElementBackupOptions.Text = "Backup Options";
            // 
            // accordionControlSeparator2
            // 
            this.accordionControlSeparator2.Name = "accordionControlSeparator2";
            // 
            // accordianElementConnection
            // 
            this.accordianElementConnection.ContentContainer = this.accordianConnectionContainer;
            this.accordianElementConnection.Expanded = true;
            this.accordianElementConnection.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordianElementConnection.ImageOptions.Image")));
            this.accordianElementConnection.Name = "accordianElementConnection";
            this.accordianElementConnection.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordianElementConnection.Text = "Connection";
            // 
            // accordionControlSeparator1
            // 
            this.accordionControlSeparator1.Name = "accordionControlSeparator1";
            // 
            // accordianElementProgress
            // 
            this.accordianElementProgress.ContentContainer = this.accordianProgressContainer;
            this.accordianElementProgress.Expanded = true;
            this.accordianElementProgress.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordianElementProgress.ImageOptions.Image")));
            this.accordianElementProgress.Name = "accordianElementProgress";
            this.accordianElementProgress.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordianElementProgress.Text = "Progress";
            // 
            // lcBackupWindow
            // 
            this.lcBackupWindow.Controls.Add(this.simpleButtonCancel);
            this.lcBackupWindow.Controls.Add(this.simpleButtonOK);
            this.lcBackupWindow.Controls.Add(this.navigationFrameBackupWindow);
            this.lcBackupWindow.Controls.Add(this.accordianBackup);
            this.lcBackupWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcBackupWindow.Location = new System.Drawing.Point(0, 0);
            this.lcBackupWindow.Name = "lcBackupWindow";
            this.lcBackupWindow.Root = this.lcgBackupWindow;
            this.lcBackupWindow.Size = new System.Drawing.Size(784, 561);
            this.lcBackupWindow.TabIndex = 1;
            this.lcBackupWindow.Text = "layoutControl1";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCancel.ImageOptions.Image")));
            this.simpleButtonCancel.Location = new System.Drawing.Point(681, 527);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(91, 22);
            this.simpleButtonCancel.StyleController = this.lcBackupWindow;
            this.simpleButtonCancel.TabIndex = 6;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonOK.ImageOptions.Image")));
            this.simpleButtonOK.Location = new System.Drawing.Point(543, 527);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(103, 22);
            this.simpleButtonOK.StyleController = this.lcBackupWindow;
            this.simpleButtonOK.TabIndex = 5;
            this.simpleButtonOK.Text = "OK";
            // 
            // navigationFrameBackupWindow
            // 
            this.navigationFrameBackupWindow.Controls.Add(this.navigationPageBackupGeneral);
            this.navigationFrameBackupWindow.Controls.Add(this.navigationPageMediaOptions);
            this.navigationFrameBackupWindow.Controls.Add(this.navigationPageBackupOptions);
            this.navigationFrameBackupWindow.Location = new System.Drawing.Point(216, 12);
            this.navigationFrameBackupWindow.Name = "navigationFrameBackupWindow";
            this.navigationFrameBackupWindow.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPageBackupGeneral,
            this.navigationPageMediaOptions,
            this.navigationPageBackupOptions});
            this.navigationFrameBackupWindow.SelectedPage = this.navigationPageBackupGeneral;
            this.navigationFrameBackupWindow.Size = new System.Drawing.Size(556, 510);
            this.navigationFrameBackupWindow.TabIndex = 4;
            this.navigationFrameBackupWindow.Text = "navigationFrame1";
            // 
            // navigationPageBackupGeneral
            // 
            this.navigationPageBackupGeneral.Caption = "navigationPageBackupGeneral";
            this.navigationPageBackupGeneral.Controls.Add(this.lciBackupGeneral);
            this.navigationPageBackupGeneral.Name = "navigationPageBackupGeneral";
            this.navigationPageBackupGeneral.Size = new System.Drawing.Size(556, 510);
            // 
            // lciBackupGeneral
            // 
            this.lciBackupGeneral.Controls.Add(this.checkEditCopyOnlyBackup);
            this.lciBackupGeneral.Controls.Add(this.simpleButtonBrowse);
            this.lciBackupGeneral.Controls.Add(this.textEditRecoveryModel);
            this.lciBackupGeneral.Controls.Add(this.textEditBackupPath);
            this.lciBackupGeneral.Controls.Add(this.imageComboBoxEditDatabaseList);
            this.lciBackupGeneral.Controls.Add(this.imageComboBoxEditBackupType);
            this.lciBackupGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lciBackupGeneral.Location = new System.Drawing.Point(0, 0);
            this.lciBackupGeneral.Name = "lciBackupGeneral";
            this.lciBackupGeneral.Root = this.lcgBackupGeneral;
            this.lciBackupGeneral.Size = new System.Drawing.Size(556, 510);
            this.lciBackupGeneral.TabIndex = 0;
            this.lciBackupGeneral.Text = "layoutControl1";
            // 
            // checkEditCopyOnlyBackup
            // 
            this.checkEditCopyOnlyBackup.Location = new System.Drawing.Point(59, 121);
            this.checkEditCopyOnlyBackup.Name = "checkEditCopyOnlyBackup";
            this.checkEditCopyOnlyBackup.Properties.Caption = "Copy Only Backup";
            this.checkEditCopyOnlyBackup.Size = new System.Drawing.Size(366, 20);
            this.checkEditCopyOnlyBackup.StyleController = this.lciBackupGeneral;
            this.checkEditCopyOnlyBackup.TabIndex = 11;
            // 
            // simpleButtonBrowse
            // 
            this.simpleButtonBrowse.Location = new System.Drawing.Point(429, 230);
            this.simpleButtonBrowse.Name = "simpleButtonBrowse";
            this.simpleButtonBrowse.Size = new System.Drawing.Size(76, 22);
            this.simpleButtonBrowse.StyleController = this.lciBackupGeneral;
            this.simpleButtonBrowse.TabIndex = 9;
            this.simpleButtonBrowse.Text = "Browse";
            this.simpleButtonBrowse.Visible = false;
            // 
            // textEditRecoveryModel
            // 
            this.textEditRecoveryModel.Location = new System.Drawing.Point(111, 73);
            this.textEditRecoveryModel.Name = "textEditRecoveryModel";
            this.textEditRecoveryModel.Properties.ReadOnly = true;
            this.textEditRecoveryModel.Size = new System.Drawing.Size(314, 20);
            this.textEditRecoveryModel.StyleController = this.lciBackupGeneral;
            this.textEditRecoveryModel.TabIndex = 8;
            // 
            // textEditBackupPath
            // 
            this.textEditBackupPath.Location = new System.Drawing.Point(111, 230);
            this.textEditBackupPath.Name = "textEditBackupPath";
            this.textEditBackupPath.Properties.ReadOnly = true;
            this.textEditBackupPath.Size = new System.Drawing.Size(314, 20);
            this.textEditBackupPath.StyleController = this.lciBackupGeneral;
            this.textEditBackupPath.TabIndex = 7;
            // 
            // imageComboBoxEditDatabaseList
            // 
            this.imageComboBoxEditDatabaseList.Location = new System.Drawing.Point(111, 49);
            this.imageComboBoxEditDatabaseList.Name = "imageComboBoxEditDatabaseList";
            this.imageComboBoxEditDatabaseList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxEditDatabaseList.Size = new System.Drawing.Size(314, 20);
            this.imageComboBoxEditDatabaseList.StyleController = this.lciBackupGeneral;
            this.imageComboBoxEditDatabaseList.TabIndex = 4;
            // 
            // imageComboBoxEditBackupType
            // 
            this.imageComboBoxEditBackupType.Location = new System.Drawing.Point(111, 97);
            this.imageComboBoxEditBackupType.Name = "imageComboBoxEditBackupType";
            this.imageComboBoxEditBackupType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxEditBackupType.Size = new System.Drawing.Size(314, 20);
            this.imageComboBoxEditBackupType.StyleController = this.lciBackupGeneral;
            this.imageComboBoxEditBackupType.TabIndex = 6;
            // 
            // lcgBackupGeneral
            // 
            this.lcgBackupGeneral.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgBackupGeneral.GroupBordersVisible = false;
            this.lcgBackupGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem3,
            this.lcgBackupSource,
            this.lcgBackupDestination,
            this.emptySpaceItem8});
            this.lcgBackupGeneral.Name = "lcgBackupGeneral";
            this.lcgBackupGeneral.Size = new System.Drawing.Size(556, 510);
            this.lcgBackupGeneral.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 256);
            this.emptySpaceItem3.Name = "emptySpaceItem2";
            this.emptySpaceItem3.Size = new System.Drawing.Size(536, 234);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgBackupSource
            // 
            this.lcgBackupSource.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lcgBackupSource.CaptionImageOptions.SvgImage")));
            this.lcgBackupSource.CaptionImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.lcgBackupSource.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciBackupDatabaseName,
            this.lciBackupType,
            this.emptySpaceItem4,
            this.lciRecoveryModel,
            this.lciCopyOnlyBackup,
            this.emptySpaceItem24});
            this.lcgBackupSource.Location = new System.Drawing.Point(0, 0);
            this.lcgBackupSource.Name = "lcgBackupSource";
            this.lcgBackupSource.Size = new System.Drawing.Size(536, 145);
            this.lcgBackupSource.Text = "Backup Source";
            // 
            // lciBackupDatabaseName
            // 
            this.lciBackupDatabaseName.Control = this.imageComboBoxEditDatabaseList;
            this.lciBackupDatabaseName.Location = new System.Drawing.Point(0, 0);
            this.lciBackupDatabaseName.Name = "lciBackupDatabaseName";
            this.lciBackupDatabaseName.Size = new System.Drawing.Size(405, 24);
            this.lciBackupDatabaseName.Text = "Database: ";
            this.lciBackupDatabaseName.TextSize = new System.Drawing.Size(84, 13);
            // 
            // lciBackupType
            // 
            this.lciBackupType.Control = this.imageComboBoxEditBackupType;
            this.lciBackupType.Location = new System.Drawing.Point(0, 48);
            this.lciBackupType.Name = "lciBackupType";
            this.lciBackupType.Size = new System.Drawing.Size(405, 24);
            this.lciBackupType.Text = "Backup Type:";
            this.lciBackupType.TextSize = new System.Drawing.Size(84, 13);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(405, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem3";
            this.emptySpaceItem4.Size = new System.Drawing.Size(107, 96);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciRecoveryModel
            // 
            this.lciRecoveryModel.Control = this.textEditRecoveryModel;
            this.lciRecoveryModel.Location = new System.Drawing.Point(0, 24);
            this.lciRecoveryModel.Name = "lciRecoveryModel";
            this.lciRecoveryModel.Size = new System.Drawing.Size(405, 24);
            this.lciRecoveryModel.Text = "Recovery Model: ";
            this.lciRecoveryModel.TextSize = new System.Drawing.Size(84, 13);
            // 
            // lciCopyOnlyBackup
            // 
            this.lciCopyOnlyBackup.Control = this.checkEditCopyOnlyBackup;
            this.lciCopyOnlyBackup.Location = new System.Drawing.Point(35, 72);
            this.lciCopyOnlyBackup.Name = "lciCopyOnlyBackup";
            this.lciCopyOnlyBackup.Size = new System.Drawing.Size(370, 24);
            this.lciCopyOnlyBackup.TextSize = new System.Drawing.Size(0, 0);
            this.lciCopyOnlyBackup.TextVisible = false;
            // 
            // emptySpaceItem24
            // 
            this.emptySpaceItem24.AllowHotTrack = false;
            this.emptySpaceItem24.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem24.Name = "emptySpaceItem24";
            this.emptySpaceItem24.Size = new System.Drawing.Size(35, 24);
            this.emptySpaceItem24.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgBackupDestination
            // 
            this.lcgBackupDestination.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lcgBackupDestination.CaptionImageOptions.SvgImage")));
            this.lcgBackupDestination.CaptionImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.lcgBackupDestination.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciBackupPath,
            this.emptySpaceItem6,
            this.lciBrowseButton});
            this.lcgBackupDestination.Location = new System.Drawing.Point(0, 181);
            this.lcgBackupDestination.Name = "lcgBackupDestination";
            this.lcgBackupDestination.Size = new System.Drawing.Size(536, 75);
            this.lcgBackupDestination.Text = "Backup Destination";
            // 
            // lciBackupPath
            // 
            this.lciBackupPath.Control = this.textEditBackupPath;
            this.lciBackupPath.Location = new System.Drawing.Point(0, 0);
            this.lciBackupPath.Name = "lciBackupPath";
            this.lciBackupPath.Size = new System.Drawing.Size(405, 26);
            this.lciBackupPath.Text = "Backup Path: ";
            this.lciBackupPath.TextSize = new System.Drawing.Size(84, 13);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(485, 0);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(27, 26);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciBrowseButton
            // 
            this.lciBrowseButton.Control = this.simpleButtonBrowse;
            this.lciBrowseButton.Location = new System.Drawing.Point(405, 0);
            this.lciBrowseButton.Name = "lciBrowseButton";
            this.lciBrowseButton.Size = new System.Drawing.Size(80, 26);
            this.lciBrowseButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciBrowseButton.TextVisible = false;
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.Location = new System.Drawing.Point(0, 145);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(536, 36);
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // navigationPageMediaOptions
            // 
            this.navigationPageMediaOptions.Caption = "navigationPageMediaOptions";
            this.navigationPageMediaOptions.Controls.Add(this.lcMediaOptions);
            this.navigationPageMediaOptions.Name = "navigationPageMediaOptions";
            this.navigationPageMediaOptions.Size = new System.Drawing.Size(556, 510);
            // 
            // lcMediaOptions
            // 
            this.lcMediaOptions.Controls.Add(this.checkEditVerifyBackup);
            this.lcMediaOptions.Controls.Add(this.checkEditContinueOnError);
            this.lcMediaOptions.Controls.Add(this.checkEditPerformChecksum);
            this.lcMediaOptions.Controls.Add(this.memoEditNewMediaSetDescription);
            this.lcMediaOptions.Controls.Add(this.textEditNewMediaSetName);
            this.lcMediaOptions.Controls.Add(this.radioGroupBackupNewMediaSet);
            this.lcMediaOptions.Controls.Add(this.textEditMediaSetName);
            this.lcMediaOptions.Controls.Add(this.checkEditMediaSetName);
            this.lcMediaOptions.Controls.Add(this.radioGroupAppendOrOverwriteBackupSet);
            this.lcMediaOptions.Controls.Add(this.radioGroupBackupToExisting);
            this.lcMediaOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMediaOptions.Location = new System.Drawing.Point(0, 0);
            this.lcMediaOptions.Name = "lcMediaOptions";
            this.lcMediaOptions.Root = this.lcgMediaOptions;
            this.lcMediaOptions.Size = new System.Drawing.Size(556, 510);
            this.lcMediaOptions.TabIndex = 0;
            this.lcMediaOptions.Text = "layoutControl1";
            // 
            // checkEditVerifyBackup
            // 
            this.checkEditVerifyBackup.Location = new System.Drawing.Point(24, 349);
            this.checkEditVerifyBackup.Name = "checkEditVerifyBackup";
            this.checkEditVerifyBackup.Properties.Caption = "Verify backup when finished";
            this.checkEditVerifyBackup.Size = new System.Drawing.Size(508, 20);
            this.checkEditVerifyBackup.StyleController = this.lcMediaOptions;
            this.checkEditVerifyBackup.TabIndex = 14;
            // 
            // checkEditContinueOnError
            // 
            this.checkEditContinueOnError.Location = new System.Drawing.Point(24, 397);
            this.checkEditContinueOnError.Name = "checkEditContinueOnError";
            this.checkEditContinueOnError.Properties.Caption = "Continue On Error";
            this.checkEditContinueOnError.Size = new System.Drawing.Size(508, 20);
            this.checkEditContinueOnError.StyleController = this.lcMediaOptions;
            this.checkEditContinueOnError.TabIndex = 13;
            // 
            // checkEditPerformChecksum
            // 
            this.checkEditPerformChecksum.Location = new System.Drawing.Point(24, 373);
            this.checkEditPerformChecksum.Name = "checkEditPerformChecksum";
            this.checkEditPerformChecksum.Properties.Caption = "Perform checksum before writing to media";
            this.checkEditPerformChecksum.Size = new System.Drawing.Size(508, 20);
            this.checkEditPerformChecksum.StyleController = this.lcMediaOptions;
            this.checkEditPerformChecksum.TabIndex = 12;
            // 
            // memoEditNewMediaSetDescription
            // 
            this.memoEditNewMediaSetDescription.Location = new System.Drawing.Point(220, 277);
            this.memoEditNewMediaSetDescription.Name = "memoEditNewMediaSetDescription";
            this.memoEditNewMediaSetDescription.Size = new System.Drawing.Size(312, 19);
            this.memoEditNewMediaSetDescription.StyleController = this.lcMediaOptions;
            this.memoEditNewMediaSetDescription.TabIndex = 10;
            // 
            // textEditNewMediaSetName
            // 
            this.textEditNewMediaSetName.Location = new System.Drawing.Point(220, 253);
            this.textEditNewMediaSetName.Name = "textEditNewMediaSetName";
            this.textEditNewMediaSetName.Size = new System.Drawing.Size(312, 20);
            this.textEditNewMediaSetName.StyleController = this.lcMediaOptions;
            this.textEditNewMediaSetName.TabIndex = 9;
            // 
            // radioGroupBackupNewMediaSet
            // 
            this.radioGroupBackupNewMediaSet.Location = new System.Drawing.Point(24, 215);
            this.radioGroupBackupNewMediaSet.Name = "radioGroupBackupNewMediaSet";
            this.radioGroupBackupNewMediaSet.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupBackupNewMediaSet.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupBackupNewMediaSet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupBackupNewMediaSet.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Back up to a new media set, and erase all existing backup sets")});
            this.radioGroupBackupNewMediaSet.Size = new System.Drawing.Size(508, 34);
            this.radioGroupBackupNewMediaSet.StyleController = this.lcMediaOptions;
            this.radioGroupBackupNewMediaSet.TabIndex = 8;
            // 
            // textEditMediaSetName
            // 
            this.textEditMediaSetName.Location = new System.Drawing.Point(220, 180);
            this.textEditMediaSetName.Name = "textEditMediaSetName";
            this.textEditMediaSetName.Size = new System.Drawing.Size(312, 20);
            this.textEditMediaSetName.StyleController = this.lcMediaOptions;
            this.textEditMediaSetName.TabIndex = 7;
            // 
            // checkEditMediaSetName
            // 
            this.checkEditMediaSetName.Location = new System.Drawing.Point(83, 156);
            this.checkEditMediaSetName.Name = "checkEditMediaSetName";
            this.checkEditMediaSetName.Properties.Caption = "Check media set name and backup set expiration";
            this.checkEditMediaSetName.Size = new System.Drawing.Size(449, 20);
            this.checkEditMediaSetName.StyleController = this.lcMediaOptions;
            this.checkEditMediaSetName.TabIndex = 6;
            // 
            // radioGroupAppendOrOverwriteBackupSet
            // 
            this.radioGroupAppendOrOverwriteBackupSet.Location = new System.Drawing.Point(83, 88);
            this.radioGroupAppendOrOverwriteBackupSet.Name = "radioGroupAppendOrOverwriteBackupSet";
            this.radioGroupAppendOrOverwriteBackupSet.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupAppendOrOverwriteBackupSet.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupAppendOrOverwriteBackupSet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupAppendOrOverwriteBackupSet.Properties.Columns = 1;
            this.radioGroupAppendOrOverwriteBackupSet.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Append to the existing backup set"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Overwrite all existing backup sets")});
            this.radioGroupAppendOrOverwriteBackupSet.Size = new System.Drawing.Size(449, 64);
            this.radioGroupAppendOrOverwriteBackupSet.StyleController = this.lcMediaOptions;
            this.radioGroupAppendOrOverwriteBackupSet.TabIndex = 5;
            // 
            // radioGroupBackupToExisting
            // 
            this.radioGroupBackupToExisting.Location = new System.Drawing.Point(24, 49);
            this.radioGroupBackupToExisting.Name = "radioGroupBackupToExisting";
            this.radioGroupBackupToExisting.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupBackupToExisting.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupBackupToExisting.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupBackupToExisting.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Back up to the existing media set")});
            this.radioGroupBackupToExisting.Size = new System.Drawing.Size(508, 35);
            this.radioGroupBackupToExisting.StyleController = this.lcMediaOptions;
            this.radioGroupBackupToExisting.TabIndex = 4;
            // 
            // lcgMediaOptions
            // 
            this.lcgMediaOptions.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMediaOptions.GroupBordersVisible = false;
            this.lcgMediaOptions.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem13,
            this.lcgOverwriteMedia,
            this.lcgReliability});
            this.lcgMediaOptions.Name = "lcgMediaOptions";
            this.lcgMediaOptions.Size = new System.Drawing.Size(556, 510);
            this.lcgMediaOptions.TextVisible = false;
            // 
            // emptySpaceItem13
            // 
            this.emptySpaceItem13.AllowHotTrack = false;
            this.emptySpaceItem13.Location = new System.Drawing.Point(0, 421);
            this.emptySpaceItem13.Name = "emptySpaceItem13";
            this.emptySpaceItem13.Size = new System.Drawing.Size(536, 69);
            this.emptySpaceItem13.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgOverwriteMedia
            // 
            this.lcgOverwriteMedia.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lcgOverwriteMedia.CaptionImageOptions.SvgImage")));
            this.lcgOverwriteMedia.CaptionImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.lcgOverwriteMedia.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciOverwriteMedia,
            this.lciAppendOrOverwrite,
            this.lciCheckMediaSetName,
            this.lcMediaSetName,
            this.emptySpaceItem14,
            this.lciBackupNewMediaSet,
            this.emptySpaceItem15,
            this.lciNewMediaSetDescription,
            this.emptySpaceItem16,
            this.lciNewMediaSetName});
            this.lcgOverwriteMedia.Location = new System.Drawing.Point(0, 0);
            this.lcgOverwriteMedia.Name = "lcgOverwriteMedia";
            this.lcgOverwriteMedia.Size = new System.Drawing.Size(536, 300);
            this.lcgOverwriteMedia.Text = "Overwrite media";
            // 
            // lciOverwriteMedia
            // 
            this.lciOverwriteMedia.Control = this.radioGroupBackupToExisting;
            this.lciOverwriteMedia.Location = new System.Drawing.Point(0, 0);
            this.lciOverwriteMedia.Name = "lciOverwriteMedia";
            this.lciOverwriteMedia.Size = new System.Drawing.Size(512, 39);
            this.lciOverwriteMedia.TextSize = new System.Drawing.Size(0, 0);
            this.lciOverwriteMedia.TextVisible = false;
            // 
            // lciAppendOrOverwrite
            // 
            this.lciAppendOrOverwrite.Control = this.radioGroupAppendOrOverwriteBackupSet;
            this.lciAppendOrOverwrite.Location = new System.Drawing.Point(59, 39);
            this.lciAppendOrOverwrite.Name = "lciAppendOrOverwrite";
            this.lciAppendOrOverwrite.Size = new System.Drawing.Size(453, 68);
            this.lciAppendOrOverwrite.TextSize = new System.Drawing.Size(0, 0);
            this.lciAppendOrOverwrite.TextVisible = false;
            // 
            // lciCheckMediaSetName
            // 
            this.lciCheckMediaSetName.Control = this.checkEditMediaSetName;
            this.lciCheckMediaSetName.Location = new System.Drawing.Point(59, 107);
            this.lciCheckMediaSetName.Name = "lciCheckMediaSetName";
            this.lciCheckMediaSetName.Size = new System.Drawing.Size(453, 24);
            this.lciCheckMediaSetName.TextSize = new System.Drawing.Size(0, 0);
            this.lciCheckMediaSetName.TextVisible = false;
            // 
            // lcMediaSetName
            // 
            this.lcMediaSetName.Control = this.textEditMediaSetName;
            this.lcMediaSetName.Location = new System.Drawing.Point(59, 131);
            this.lcMediaSetName.Name = "lcMediaSetName";
            this.lcMediaSetName.Size = new System.Drawing.Size(453, 24);
            this.lcMediaSetName.Text = "Media Set Name: ";
            this.lcMediaSetName.TextSize = new System.Drawing.Size(134, 13);
            // 
            // emptySpaceItem14
            // 
            this.emptySpaceItem14.AllowHotTrack = false;
            this.emptySpaceItem14.Location = new System.Drawing.Point(0, 39);
            this.emptySpaceItem14.Name = "emptySpaceItem14";
            this.emptySpaceItem14.Size = new System.Drawing.Size(59, 116);
            this.emptySpaceItem14.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciBackupNewMediaSet
            // 
            this.lciBackupNewMediaSet.Control = this.radioGroupBackupNewMediaSet;
            this.lciBackupNewMediaSet.Location = new System.Drawing.Point(0, 166);
            this.lciBackupNewMediaSet.Name = "lciBackupNewMediaSet";
            this.lciBackupNewMediaSet.Size = new System.Drawing.Size(512, 38);
            this.lciBackupNewMediaSet.TextSize = new System.Drawing.Size(0, 0);
            this.lciBackupNewMediaSet.TextVisible = false;
            // 
            // emptySpaceItem15
            // 
            this.emptySpaceItem15.AllowHotTrack = false;
            this.emptySpaceItem15.Location = new System.Drawing.Point(0, 155);
            this.emptySpaceItem15.Name = "emptySpaceItem15";
            this.emptySpaceItem15.Size = new System.Drawing.Size(512, 11);
            this.emptySpaceItem15.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciNewMediaSetDescription
            // 
            this.lciNewMediaSetDescription.Control = this.memoEditNewMediaSetDescription;
            this.lciNewMediaSetDescription.Location = new System.Drawing.Point(59, 228);
            this.lciNewMediaSetDescription.Name = "lciNewMediaSetDescription";
            this.lciNewMediaSetDescription.Size = new System.Drawing.Size(453, 23);
            this.lciNewMediaSetDescription.Text = "New Media Set Description: ";
            this.lciNewMediaSetDescription.TextSize = new System.Drawing.Size(134, 13);
            // 
            // emptySpaceItem16
            // 
            this.emptySpaceItem16.AllowHotTrack = false;
            this.emptySpaceItem16.Location = new System.Drawing.Point(0, 204);
            this.emptySpaceItem16.Name = "emptySpaceItem16";
            this.emptySpaceItem16.Size = new System.Drawing.Size(59, 47);
            this.emptySpaceItem16.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciNewMediaSetName
            // 
            this.lciNewMediaSetName.Control = this.textEditNewMediaSetName;
            this.lciNewMediaSetName.Location = new System.Drawing.Point(59, 204);
            this.lciNewMediaSetName.Name = "lciNewMediaSetName";
            this.lciNewMediaSetName.Size = new System.Drawing.Size(453, 24);
            this.lciNewMediaSetName.Text = "New Media Set Name: ";
            this.lciNewMediaSetName.TextSize = new System.Drawing.Size(134, 13);
            // 
            // lcgReliability
            // 
            this.lcgReliability.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lcgReliability.CaptionImageOptions.SvgImage")));
            this.lcgReliability.CaptionImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.lcgReliability.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciVerifyBacupWhenFinished,
            this.lciPerformChecksum,
            this.lciContinueOnError});
            this.lcgReliability.Location = new System.Drawing.Point(0, 300);
            this.lcgReliability.Name = "lcgReliability";
            this.lcgReliability.Size = new System.Drawing.Size(536, 121);
            this.lcgReliability.Text = "Reliability";
            // 
            // lciVerifyBacupWhenFinished
            // 
            this.lciVerifyBacupWhenFinished.Control = this.checkEditVerifyBackup;
            this.lciVerifyBacupWhenFinished.Location = new System.Drawing.Point(0, 0);
            this.lciVerifyBacupWhenFinished.Name = "lciVerifyBacupWhenFinished";
            this.lciVerifyBacupWhenFinished.Size = new System.Drawing.Size(512, 24);
            this.lciVerifyBacupWhenFinished.TextSize = new System.Drawing.Size(0, 0);
            this.lciVerifyBacupWhenFinished.TextVisible = false;
            // 
            // lciPerformChecksum
            // 
            this.lciPerformChecksum.Control = this.checkEditPerformChecksum;
            this.lciPerformChecksum.Location = new System.Drawing.Point(0, 24);
            this.lciPerformChecksum.Name = "lciPerformChecksum";
            this.lciPerformChecksum.Size = new System.Drawing.Size(512, 24);
            this.lciPerformChecksum.TextSize = new System.Drawing.Size(0, 0);
            this.lciPerformChecksum.TextVisible = false;
            // 
            // lciContinueOnError
            // 
            this.lciContinueOnError.Control = this.checkEditContinueOnError;
            this.lciContinueOnError.Location = new System.Drawing.Point(0, 48);
            this.lciContinueOnError.Name = "lciContinueOnError";
            this.lciContinueOnError.Size = new System.Drawing.Size(512, 24);
            this.lciContinueOnError.TextSize = new System.Drawing.Size(0, 0);
            this.lciContinueOnError.TextVisible = false;
            // 
            // navigationPageBackupOptions
            // 
            this.navigationPageBackupOptions.Caption = "navigationPageBackupOptions";
            this.navigationPageBackupOptions.Controls.Add(this.lcBackupOptions);
            this.navigationPageBackupOptions.Name = "navigationPageBackupOptions";
            this.navigationPageBackupOptions.Size = new System.Drawing.Size(556, 510);
            // 
            // lcBackupOptions
            // 
            this.lcBackupOptions.Controls.Add(this.dateEditExpireOnDate);
            this.lcBackupOptions.Controls.Add(this.spinEditExpireAfterDays);
            this.lcBackupOptions.Controls.Add(this.radioGroupBackupSetExpire);
            this.lcBackupOptions.Controls.Add(this.textEditBackupDescription);
            this.lcBackupOptions.Controls.Add(this.textEditBackupSetName);
            this.lcBackupOptions.Controls.Add(this.imageComboBoxEditCompressionSetting);
            this.lcBackupOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcBackupOptions.Location = new System.Drawing.Point(0, 0);
            this.lcBackupOptions.Name = "lcBackupOptions";
            this.lcBackupOptions.Root = this.lcgBackupOptions;
            this.lcBackupOptions.Size = new System.Drawing.Size(556, 510);
            this.lcBackupOptions.TabIndex = 2;
            this.lcBackupOptions.Text = "layoutControl1";
            // 
            // dateEditExpireOnDate
            // 
            this.dateEditExpireOnDate.EditValue = null;
            this.dateEditExpireOnDate.Enabled = false;
            this.dateEditExpireOnDate.Location = new System.Drawing.Point(213, 203);
            this.dateEditExpireOnDate.Name = "dateEditExpireOnDate";
            this.dateEditExpireOnDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditExpireOnDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditExpireOnDate.Size = new System.Drawing.Size(146, 20);
            this.dateEditExpireOnDate.StyleController = this.lcBackupOptions;
            this.dateEditExpireOnDate.TabIndex = 8;
            // 
            // spinEditExpireAfterDays
            // 
            this.spinEditExpireAfterDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditExpireAfterDays.Location = new System.Drawing.Point(213, 179);
            this.spinEditExpireAfterDays.Name = "spinEditExpireAfterDays";
            this.spinEditExpireAfterDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditExpireAfterDays.Size = new System.Drawing.Size(107, 20);
            this.spinEditExpireAfterDays.StyleController = this.lcBackupOptions;
            this.spinEditExpireAfterDays.TabIndex = 7;
            // 
            // radioGroupBackupSetExpire
            // 
            this.radioGroupBackupSetExpire.Location = new System.Drawing.Point(24, 155);
            this.radioGroupBackupSetExpire.Name = "radioGroupBackupSetExpire";
            this.radioGroupBackupSetExpire.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupBackupSetExpire.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupBackupSetExpire.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupBackupSetExpire.Properties.Columns = 1;
            this.radioGroupBackupSetExpire.Size = new System.Drawing.Size(142, 68);
            this.radioGroupBackupSetExpire.StyleController = this.lcBackupOptions;
            this.radioGroupBackupSetExpire.TabIndex = 6;
            // 
            // textEditBackupDescription
            // 
            this.textEditBackupDescription.Location = new System.Drawing.Point(169, 100);
            this.textEditBackupDescription.Name = "textEditBackupDescription";
            this.textEditBackupDescription.Size = new System.Drawing.Size(363, 20);
            this.textEditBackupDescription.StyleController = this.lcBackupOptions;
            this.textEditBackupDescription.TabIndex = 5;
            // 
            // textEditBackupSetName
            // 
            this.textEditBackupSetName.Location = new System.Drawing.Point(169, 49);
            this.textEditBackupSetName.Name = "textEditBackupSetName";
            this.textEditBackupSetName.Size = new System.Drawing.Size(363, 20);
            this.textEditBackupSetName.StyleController = this.lcBackupOptions;
            this.textEditBackupSetName.TabIndex = 4;
            // 
            // imageComboBoxEditCompressionSetting
            // 
            this.imageComboBoxEditCompressionSetting.Location = new System.Drawing.Point(169, 276);
            this.imageComboBoxEditCompressionSetting.Name = "imageComboBoxEditCompressionSetting";
            this.imageComboBoxEditCompressionSetting.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxEditCompressionSetting.Size = new System.Drawing.Size(363, 20);
            this.imageComboBoxEditCompressionSetting.StyleController = this.lcBackupOptions;
            this.imageComboBoxEditCompressionSetting.TabIndex = 10;
            // 
            // lcgBackupOptions
            // 
            this.lcgBackupOptions.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgBackupOptions.GroupBordersVisible = false;
            this.lcgBackupOptions.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem17,
            this.lcgBackupSet,
            this.lcgCompression});
            this.lcgBackupOptions.Name = "lcgBackupOptions";
            this.lcgBackupOptions.Size = new System.Drawing.Size(556, 510);
            this.lcgBackupOptions.TextVisible = false;
            // 
            // emptySpaceItem17
            // 
            this.emptySpaceItem17.AllowHotTrack = false;
            this.emptySpaceItem17.Location = new System.Drawing.Point(0, 300);
            this.emptySpaceItem17.Name = "emptySpaceItem17";
            this.emptySpaceItem17.Size = new System.Drawing.Size(536, 190);
            this.emptySpaceItem17.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgBackupSet
            // 
            this.lcgBackupSet.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lcgBackupSet.CaptionImageOptions.SvgImage")));
            this.lcgBackupSet.CaptionImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.lcgBackupSet.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciBackupName,
            this.lciBackupDescription,
            this.lciBackupSetExpire,
            this.lciExpireAfterDays,
            this.lciExpireOnDate,
            this.emptySpaceItem18,
            this.emptySpaceItem19,
            this.emptySpaceItem21,
            this.emptySpaceItem20,
            this.emptySpaceItem22,
            this.emptySpaceItem23});
            this.lcgBackupSet.Location = new System.Drawing.Point(0, 0);
            this.lcgBackupSet.Name = "lcgBackupSet";
            this.lcgBackupSet.Size = new System.Drawing.Size(536, 227);
            this.lcgBackupSet.Text = "Backup Set";
            // 
            // lciBackupName
            // 
            this.lciBackupName.Control = this.textEditBackupSetName;
            this.lciBackupName.Location = new System.Drawing.Point(0, 0);
            this.lciBackupName.Name = "lciBackupName";
            this.lciBackupName.Size = new System.Drawing.Size(512, 24);
            this.lciBackupName.Text = "Name: ";
            this.lciBackupName.TextSize = new System.Drawing.Size(142, 13);
            // 
            // lciBackupDescription
            // 
            this.lciBackupDescription.Control = this.textEditBackupDescription;
            this.lciBackupDescription.Location = new System.Drawing.Point(0, 51);
            this.lciBackupDescription.Name = "lciBackupDescription";
            this.lciBackupDescription.Size = new System.Drawing.Size(512, 24);
            this.lciBackupDescription.Text = "Backup Description: ";
            this.lciBackupDescription.TextSize = new System.Drawing.Size(142, 13);
            // 
            // lciBackupSetExpire
            // 
            this.lciBackupSetExpire.Control = this.radioGroupBackupSetExpire;
            this.lciBackupSetExpire.Location = new System.Drawing.Point(0, 90);
            this.lciBackupSetExpire.Name = "lciBackupSetExpire";
            this.lciBackupSetExpire.Size = new System.Drawing.Size(146, 88);
            this.lciBackupSetExpire.Text = "Backup set will expire: ";
            this.lciBackupSetExpire.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciBackupSetExpire.TextSize = new System.Drawing.Size(142, 13);
            // 
            // lciExpireAfterDays
            // 
            this.lciExpireAfterDays.Control = this.spinEditExpireAfterDays;
            this.lciExpireAfterDays.Location = new System.Drawing.Point(189, 130);
            this.lciExpireAfterDays.Name = "lciExpireAfterDays";
            this.lciExpireAfterDays.Size = new System.Drawing.Size(256, 24);
            this.lciExpireAfterDays.Text = "days";
            this.lciExpireAfterDays.TextLocation = DevExpress.Utils.Locations.Right;
            this.lciExpireAfterDays.TextSize = new System.Drawing.Size(142, 13);
            // 
            // lciExpireOnDate
            // 
            this.lciExpireOnDate.Control = this.dateEditExpireOnDate;
            this.lciExpireOnDate.Location = new System.Drawing.Point(189, 154);
            this.lciExpireOnDate.Name = "lciExpireOnDate";
            this.lciExpireOnDate.Size = new System.Drawing.Size(150, 24);
            this.lciExpireOnDate.TextSize = new System.Drawing.Size(0, 0);
            this.lciExpireOnDate.TextVisible = false;
            // 
            // emptySpaceItem18
            // 
            this.emptySpaceItem18.AllowHotTrack = false;
            this.emptySpaceItem18.Location = new System.Drawing.Point(189, 90);
            this.emptySpaceItem18.Name = "emptySpaceItem18";
            this.emptySpaceItem18.Size = new System.Drawing.Size(323, 40);
            this.emptySpaceItem18.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem19
            // 
            this.emptySpaceItem19.AllowHotTrack = false;
            this.emptySpaceItem19.Location = new System.Drawing.Point(146, 90);
            this.emptySpaceItem19.Name = "emptySpaceItem19";
            this.emptySpaceItem19.Size = new System.Drawing.Size(43, 88);
            this.emptySpaceItem19.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem21
            // 
            this.emptySpaceItem21.AllowHotTrack = false;
            this.emptySpaceItem21.Location = new System.Drawing.Point(339, 154);
            this.emptySpaceItem21.Name = "emptySpaceItem21";
            this.emptySpaceItem21.Size = new System.Drawing.Size(173, 24);
            this.emptySpaceItem21.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem20
            // 
            this.emptySpaceItem20.AllowHotTrack = false;
            this.emptySpaceItem20.Location = new System.Drawing.Point(445, 130);
            this.emptySpaceItem20.Name = "emptySpaceItem20";
            this.emptySpaceItem20.Size = new System.Drawing.Size(67, 24);
            this.emptySpaceItem20.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem22
            // 
            this.emptySpaceItem22.AllowHotTrack = false;
            this.emptySpaceItem22.Location = new System.Drawing.Point(0, 75);
            this.emptySpaceItem22.Name = "emptySpaceItem22";
            this.emptySpaceItem22.Size = new System.Drawing.Size(512, 15);
            this.emptySpaceItem22.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem23
            // 
            this.emptySpaceItem23.AllowHotTrack = false;
            this.emptySpaceItem23.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem23.Name = "emptySpaceItem23";
            this.emptySpaceItem23.Size = new System.Drawing.Size(512, 27);
            this.emptySpaceItem23.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgCompression
            // 
            this.lcgCompression.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lcgCompression.CaptionImageOptions.SvgImage")));
            this.lcgCompression.CaptionImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.lcgCompression.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciCompressionComboBox});
            this.lcgCompression.Location = new System.Drawing.Point(0, 227);
            this.lcgCompression.Name = "lcgCompression";
            this.lcgCompression.Size = new System.Drawing.Size(536, 73);
            this.lcgCompression.Text = "Compression";
            // 
            // lciCompressionComboBox
            // 
            this.lciCompressionComboBox.Control = this.imageComboBoxEditCompressionSetting;
            this.lciCompressionComboBox.Location = new System.Drawing.Point(0, 0);
            this.lciCompressionComboBox.Name = "lciCompressionComboBox";
            this.lciCompressionComboBox.Size = new System.Drawing.Size(512, 24);
            this.lciCompressionComboBox.Text = "Backup Compression Setting: ";
            this.lciCompressionComboBox.TextSize = new System.Drawing.Size(142, 13);
            // 
            // lcgBackupWindow
            // 
            this.lcgBackupWindow.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgBackupWindow.GroupBordersVisible = false;
            this.lcgBackupWindow.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciAccordian,
            this.lciNavigationFrame,
            this.lciCancelButton,
            this.emptySpaceItem2,
            this.emptySpaceItem5,
            this.simpleSeparator1,
            this.lciOkButton});
            this.lcgBackupWindow.Name = "lcgBackupWindow";
            this.lcgBackupWindow.Size = new System.Drawing.Size(784, 561);
            this.lcgBackupWindow.TextVisible = false;
            // 
            // lciAccordian
            // 
            this.lciAccordian.Control = this.accordianBackup;
            this.lciAccordian.Location = new System.Drawing.Point(0, 0);
            this.lciAccordian.Name = "lciAccordian";
            this.lciAccordian.Size = new System.Drawing.Size(204, 514);
            this.lciAccordian.TextSize = new System.Drawing.Size(0, 0);
            this.lciAccordian.TextVisible = false;
            // 
            // lciNavigationFrame
            // 
            this.lciNavigationFrame.Control = this.navigationFrameBackupWindow;
            this.lciNavigationFrame.Location = new System.Drawing.Point(204, 0);
            this.lciNavigationFrame.Name = "lciNavigationFrame";
            this.lciNavigationFrame.Size = new System.Drawing.Size(560, 514);
            this.lciNavigationFrame.TextSize = new System.Drawing.Size(0, 0);
            this.lciNavigationFrame.TextVisible = false;
            // 
            // lciCancelButton
            // 
            this.lciCancelButton.Control = this.simpleButtonCancel;
            this.lciCancelButton.Location = new System.Drawing.Point(669, 515);
            this.lciCancelButton.Name = "lciCancelButton";
            this.lciCancelButton.Size = new System.Drawing.Size(95, 26);
            this.lciCancelButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciCancelButton.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(638, 515);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(31, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 515);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(531, 26);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 514);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(764, 1);
            // 
            // lciOkButton
            // 
            this.lciOkButton.Control = this.simpleButtonOK;
            this.lciOkButton.Location = new System.Drawing.Point(531, 515);
            this.lciOkButton.Name = "lciOkButton";
            this.lciOkButton.Size = new System.Drawing.Size(107, 26);
            this.lciOkButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciOkButton.TextVisible = false;
            // 
            // imageCollectionBackupView
            // 
            this.imageCollectionBackupView.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionBackupView.ImageStream")));
            this.imageCollectionBackupView.InsertGalleryImage("checkbox_16x16.png", "office2013/content/checkbox_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/content/checkbox_16x16.png"), 0);
            this.imageCollectionBackupView.Images.SetKeyName(0, "checkbox_16x16.png");
            this.imageCollectionBackupView.InsertGalleryImage("time_16x16.png", "office2013/scheduling/time_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/scheduling/time_16x16.png"), 1);
            this.imageCollectionBackupView.Images.SetKeyName(1, "time_16x16.png");
            this.imageCollectionBackupView.InsertGalleryImage("close_16x16.png", "office2013/actions/close_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/close_16x16.png"), 2);
            this.imageCollectionBackupView.Images.SetKeyName(2, "close_16x16.png");
            // 
            // mvvmContextBackupView
            // 
            this.mvvmContextBackupView.ContainerControl = this;
            this.mvvmContextBackupView.ViewModelType = typeof(Databvase_Winforms.View_Models.BackupViewModel);
            // 
            // BackupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lcBackupWindow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "BackupView";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.accordianBackup)).EndInit();
            this.accordianBackup.ResumeLayout(false);
            this.accordianConnectionContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlConnection)).EndInit();
            this.layoutControlConnection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgConnectionGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciServerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCurrentUser)).EndInit();
            this.accordianProgressContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcProgressPanel)).EndInit();
            this.lcProgressPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditProgressStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlDatabaseBackup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgProgressPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcProgressStatusImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcBackupWindow)).EndInit();
            this.lcBackupWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrameBackupWindow)).EndInit();
            this.navigationFrameBackupWindow.ResumeLayout(false);
            this.navigationPageBackupGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupGeneral)).EndInit();
            this.lciBackupGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditCopyOnlyBackup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRecoveryModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBackupPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditDatabaseList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditBackupType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBackupGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBackupSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupDatabaseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRecoveryModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCopyOnlyBackup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBackupDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBrowseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            this.navigationPageMediaOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcMediaOptions)).EndInit();
            this.lcMediaOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditVerifyBackup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditContinueOnError.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPerformChecksum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditNewMediaSetDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewMediaSetName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupBackupNewMediaSet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMediaSetName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditMediaSetName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupAppendOrOverwriteBackupSet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupBackupToExisting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMediaOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgOverwriteMedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOverwriteMedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAppendOrOverwrite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCheckMediaSetName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMediaSetName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupNewMediaSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNewMediaSetDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNewMediaSetName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgReliability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVerifyBacupWhenFinished)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPerformChecksum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciContinueOnError)).EndInit();
            this.navigationPageBackupOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcBackupOptions)).EndInit();
            this.lcBackupOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditExpireOnDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditExpireOnDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditExpireAfterDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupBackupSetExpire.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBackupDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBackupSetName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditCompressionSetting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBackupOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBackupSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupSetExpire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExpireAfterDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExpireOnDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCompression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCompressionComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBackupWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAccordian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNavigationFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOkButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionBackupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextBackupView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.AccordionControl accordianBackup;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementBackupPages;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordianElementGeneral;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordianElementMedia;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordianElementBackupOptions;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordianConnectionContainer;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordianElementConnection;
        private DevExpress.XtraLayout.LayoutControl layoutControlConnection;
        private DevExpress.XtraLayout.LayoutControlGroup lcgConnectionGroup;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordianProgressContainer;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator2;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordianElementProgress;
        private DevExpress.XtraLayout.LayoutControl lcBackupWindow;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrameBackupWindow;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageBackupGeneral;
        private DevExpress.XtraLayout.LayoutControl lciBackupGeneral;
        private DevExpress.XtraLayout.LayoutControlGroup lcgBackupGeneral;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlGroup lcgBackupSource;
        private DevExpress.XtraLayout.LayoutControlItem lciBackupDatabaseName;
        private DevExpress.XtraLayout.LayoutControlItem lciBackupType;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageMediaOptions;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageBackupOptions;
        private DevExpress.XtraLayout.LayoutControlGroup lcgBackupWindow;
        private DevExpress.XtraLayout.LayoutControlItem lciAccordian;
        private DevExpress.XtraLayout.LayoutControlItem lciNavigationFrame;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private DevExpress.XtraLayout.LayoutControlItem lciCancelButton;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.LayoutControlItem lciOkButton;
        private DevExpress.XtraEditors.LabelControl labelControlCurrentUser;
        private DevExpress.XtraEditors.LabelControl labelControlServerName;
        private DevExpress.XtraLayout.LayoutControlItem lciServerName;
        private DevExpress.XtraLayout.LayoutControlItem lciCurrentUser;
        private DevExpress.XtraEditors.TextEdit textEditBackupPath;
        private DevExpress.XtraLayout.LayoutControlGroup lcgBackupDestination;
        private DevExpress.XtraLayout.LayoutControlItem lciBackupPath;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraEditors.TextEdit textEditRecoveryModel;
        private DevExpress.XtraLayout.LayoutControlItem lciRecoveryModel;
        private DevExpress.XtraLayout.LayoutControl lcProgressPanel;
        private DevExpress.XtraLayout.LayoutControlGroup lcgProgressPanel;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControlDatabaseBackup;
        private DevExpress.XtraLayout.LayoutControlItem lciBackupProgressBar;
        private DevExpress.XtraEditors.PictureEdit pictureEditProgressStatus;
        private DevExpress.XtraLayout.LayoutControlItem lcProgressStatusImage;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private DevExpress.Utils.ImageCollection imageCollectionBackupView;
        private DevExpress.XtraEditors.SimpleButton simpleButtonBrowse;
        private DevExpress.XtraLayout.LayoutControlItem lciBrowseButton;
        private DevExpress.XtraLayout.LayoutControl lcMediaOptions;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMediaOptions;
        private DevExpress.XtraEditors.RadioGroup radioGroupBackupToExisting;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem13;
        private DevExpress.XtraLayout.LayoutControlGroup lcgOverwriteMedia;
        private DevExpress.XtraLayout.LayoutControlItem lciOverwriteMedia;
        private DevExpress.XtraEditors.RadioGroup radioGroupAppendOrOverwriteBackupSet;
        private DevExpress.XtraLayout.LayoutControlItem lciAppendOrOverwrite;
        private DevExpress.XtraEditors.CheckEdit checkEditMediaSetName;
        private DevExpress.XtraLayout.LayoutControlItem lciCheckMediaSetName;
        private DevExpress.XtraEditors.TextEdit textEditMediaSetName;
        private DevExpress.XtraLayout.LayoutControlItem lcMediaSetName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem14;
        private DevExpress.XtraEditors.RadioGroup radioGroupBackupNewMediaSet;
        private DevExpress.XtraLayout.LayoutControlItem lciBackupNewMediaSet;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem15;
        private DevExpress.XtraEditors.MemoEdit memoEditNewMediaSetDescription;
        private DevExpress.XtraEditors.TextEdit textEditNewMediaSetName;
        private DevExpress.XtraLayout.LayoutControlItem lciNewMediaSetName;
        private DevExpress.XtraLayout.LayoutControlItem lciNewMediaSetDescription;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem16;
        private DevExpress.XtraEditors.CheckEdit checkEditContinueOnError;
        private DevExpress.XtraEditors.CheckEdit checkEditPerformChecksum;
        private DevExpress.XtraLayout.LayoutControlItem lciPerformChecksum;
        private DevExpress.XtraLayout.LayoutControlItem lciContinueOnError;
        private DevExpress.XtraEditors.CheckEdit checkEditVerifyBackup;
        private DevExpress.XtraLayout.LayoutControlItem lciVerifyBacupWhenFinished;
        private DevExpress.XtraLayout.LayoutControlGroup lcgReliability;
        private DevExpress.XtraLayout.LayoutControl lcBackupOptions;
        private DevExpress.XtraLayout.LayoutControlGroup lcgBackupOptions;
        private DevExpress.XtraEditors.RadioGroup radioGroupBackupSetExpire;
        private DevExpress.XtraEditors.TextEdit textEditBackupDescription;
        private DevExpress.XtraEditors.TextEdit textEditBackupSetName;
        private DevExpress.XtraLayout.LayoutControlItem lciBackupName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem17;
        private DevExpress.XtraLayout.LayoutControlItem lciBackupDescription;
        private DevExpress.XtraLayout.LayoutControlItem lciBackupSetExpire;
        private DevExpress.XtraLayout.LayoutControlGroup lcgBackupSet;
        private DevExpress.XtraEditors.DateEdit dateEditExpireOnDate;
        private DevExpress.XtraEditors.SpinEdit spinEditExpireAfterDays;
        private DevExpress.XtraLayout.LayoutControlItem lciExpireAfterDays;
        private DevExpress.XtraLayout.LayoutControlItem lciExpireOnDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem18;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem19;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem21;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem20;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem22;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem23;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContextBackupView;
        private DevExpress.XtraLayout.LayoutControlGroup lcgCompression;
        private DevExpress.XtraLayout.LayoutControlItem lciCompressionComboBox;
        private DevExpress.XtraEditors.CheckEdit checkEditCopyOnlyBackup;
        private DevExpress.XtraLayout.LayoutControlItem lciCopyOnlyBackup;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem24;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEditDatabaseList;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEditBackupType;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEditCompressionSetting;
    }
}