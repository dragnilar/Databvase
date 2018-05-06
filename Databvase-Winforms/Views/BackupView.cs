using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Views
{
    public partial class BackupView : DevExpress.XtraEditors.XtraForm
    {
        public BackupView()
        {
            InitializeComponent();
            HookupEvents();
            SetupControls();
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
        }



        private void SetupControls()
        {
            SetupDatabasesComboBox();
            SetupRecoveryModel();
            SetupBackupType();
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
            //Do a backup
        }
    }
}