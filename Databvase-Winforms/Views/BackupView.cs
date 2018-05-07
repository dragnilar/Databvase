using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.View_Models;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Views
{
    public partial class BackupView : DevExpress.XtraEditors.XtraForm
    {
        Backup BackupProcess = new Backup();


        public BackupView()
        {
            InitializeComponent();
            HookupEvents();
            SetupControls();
            SetServerNamesOnPanel();
            if (!mvvmContextBackupView.IsDesignMode)
                InitializeBindings();
        }



        void HookupEvents()
        {
            accordianElementGeneral.Click += (sender, args) =>
                navigationFrameBackupWindow.SelectedPage = navigationPageBackupGeneral;
            accordianElementMedia.Click += (sender, args) =>
                navigationFrameBackupWindow.SelectedPage = navigationPageMediaOptions;
            accordianElementBackupOptions.Click += (sender, args) =>
                navigationFrameBackupWindow.SelectedPage = navigationPageBackupOptions;

            simpleButtonOK.Click += SimpleButtonOkOnClick;
            simpleButtonCancel.Click += SimpleButtonCancelOnClick;

            comboBoxEditDatabaseList.EditValueChanged += ComboBoxEditDatabaseListOnEditValueChanged;

            BackupProcess.Complete += BackupProcessOnComplete;
            BackupProcess.PercentComplete += BackupProcessOnPercentComplete;

            radioGroupBackupToExisting.SelectedIndexChanged += RadioGroupBackupToExistingOnSelectedIndexChanged;
            radioGroupBackupNewMediaSet.SelectedIndexChanged += RadioGroupBackupNewMediaSetOnSelectedIndexChanged;
        }


        private void BackupProcessOnPercentComplete(object sender, PercentCompleteEventArgs e)
        {
            pictureEditProgressStatus.Image = imageCollectionBackupView.Images[1];
            progressBarControlDatabaseBackup.Properties.Step = e.Percent;
            progressBarControlDatabaseBackup.PerformStep();
            progressBarControlDatabaseBackup.Update();
            
        }

        private void BackupProcessOnComplete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error.Number == 3014)
            {
                XtraMessageBox.Show(e.Error.Message, "Backup Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pictureEditProgressStatus.Image = imageCollectionBackupView.Images[0];
                lcProgressStatusImage.Text = "Complete";
                Close();
            }
            else
            {
                XtraMessageBox.Show(e.Error.Message, "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureEditProgressStatus.Image = imageCollectionBackupView.Images[2];
                lcProgressStatusImage.Text = "Error";
                progressBarControlDatabaseBackup.Properties.Step = 0;
                progressBarControlDatabaseBackup.PerformStep();
                progressBarControlDatabaseBackup.Update();
                
            }
        }


        private void SetupControls()
        {
            SetupDatabasesComboBox();
            SetupRecoveryModel();
            SetupBackupType();
        }

        private void SetServerNamesOnPanel()
        {
            labelControlServerName.Text = App.Connection.InstanceTracker.CurrentInstance.Name;
            labelControlCurrentUser.Text =
                App.Connection.InstanceTracker.CurrentInstance.ConnectionContext.TrueLogin;
        }

        private void SetupDatabasesComboBox()
        {
            var list = new List<string>();
            foreach (Database db in App.Connection.InstanceTracker.CurrentInstance.Databases) list.Add(db.Name);
            comboBoxEditDatabaseList.Properties.Items.AddRange(list);
            comboBoxEditDatabaseList.SelectedItem = App.Connection.InstanceTracker.CurrentDatabase.Name;
        }
        private void SetupRecoveryModel()
        {
            textEditRecoveryModel.Text = App.Connection.InstanceTracker.CurrentDatabase.RecoveryModel.ToString();
        }

        private void SetupBackupType()
        {
            comboBoxEditBackupType.Properties.Items.Add("Full");
            comboBoxEditBackupType.Properties.Items.Add("Differential");
            comboBoxEditBackupType.SelectedItem = "Full";
        }

        private void SimpleButtonCancelOnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void SimpleButtonOkOnClick(object sender, EventArgs e)
        {
            RunBackup();
        }

        private void RunBackup()
        {
            if (string.IsNullOrEmpty(textEditBackupPath.Text.Trim()))
            {
                XtraMessageBox.Show("You must enter a backup path");
                return;
            }

            try
            {
                BackupProcess.Action = BackupActionType.Database;
                BackupProcess.Database = comboBoxEditDatabaseList.SelectedItem.ToString();
                BackupProcess.Devices.AddDevice(textEditBackupPath.Text, DeviceType.File);
                BackupProcess.BackupSetName = comboBoxEditDatabaseList.SelectedItem.ToString() + " Full Database Backup";
                BackupProcess.BackupSetDescription = string.Empty;
                BackupProcess.Initialize = false;
                BackupProcess.Incremental = GetBackupType();
                lcProgressStatusImage.Text = "In Progress";
                pictureEditProgressStatus.Image = imageCollectionBackupView.Images[1];
                BackupProcess.SqlBackup(App.Connection.InstanceTracker.CurrentInstance);
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Error Starting Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureEditProgressStatus.Image = imageCollectionBackupView.Images[2];
                lcProgressStatusImage.Text = "Error";
            }

        }



        private bool GetBackupType()
        {
            return comboBoxEditBackupType.SelectedItem != "Full";
        }

        private void ComboBoxEditDatabaseListOnEditValueChanged(object sender, EventArgs e)
        {
            GetRecoveryModel();

        }

        private void GetRecoveryModel()
        {
            var databases = App.Connection.InstanceTracker.CurrentInstance.Databases;

            foreach (Database db in databases)
            {
                if (db.Name == comboBoxEditDatabaseList.EditValue.ToString())
                {
                    textEditRecoveryModel.Text = db.RecoveryModel.ToString();
                    break;
                }
            }
        }


        private void RadioGroupBackupToExistingOnSelectedIndexChanged(object sender, EventArgs e)
        {
            radioGroupBackupNewMediaSet.SelectedIndex = -1;
            textEditNewMediaSetName.Enabled = false;
            memoEditNewMediaSetDescription.Enabled = false;
            radioGroupAppendOrOverwriteBackupSet.Enabled = true;
            checkEditMediaSetName.Enabled = true;
            textEditMediaSetName.Enabled = true;
        }

        private void RadioGroupBackupNewMediaSetOnSelectedIndexChanged(object sender, EventArgs e)
        {
            radioGroupBackupToExisting.SelectedIndex = -1;
            textEditNewMediaSetName.Enabled = true;
            memoEditNewMediaSetDescription.Enabled = true;
            radioGroupAppendOrOverwriteBackupSet.Enabled = false;
            checkEditMediaSetName.Enabled = false;
            textEditMediaSetName.Enabled = false;
        }

        void InitializeBindings()
        {
            var fluent = mvvmContextBackupView.OfType<BackupViewModel>();
        }
    }
}