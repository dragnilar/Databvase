using System;
using System.Windows.Forms;
using Databvase_Winforms.Dialogs;
using Databvase_Winforms.Messages;
using Databvase_Winforms.View_Models;
using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Databvase_Winforms.Views
{
    public partial class BackupView : XtraForm
    {
        public BackupView()
        {
            InitializeComponent();
            HookupEvents();
            SetupControls();
            if (!mvvmContextBackupView.IsDesignMode)
                InitializeBindings();
            RegisterMessages();
            RegisterService();
        }


        private void RegisterService()
        {
            MVVMContext.RegisterXtraMessageBoxService();
        }

        private void HookupEvents()
        {
            accordianElementGeneral.Click += (sender, args) =>
                navigationFrameBackupWindow.SelectedPage = navigationPageBackupGeneral;
            accordianElementMedia.Click += (sender, args) =>
                navigationFrameBackupWindow.SelectedPage = navigationPageMediaOptions;
            accordianElementBackupOptions.Click += (sender, args) =>
                navigationFrameBackupWindow.SelectedPage = navigationPageBackupOptions;

            simpleButtonBrowse.Click += SimpleButtonBrowseOnClick;

            radioGroupBackupToExisting.SelectedIndexChanged += RadioGroupBackupToExistingOnSelectedIndexChanged;
            radioGroupBackupNewMediaSet.SelectedIndexChanged += RadioGroupBackupNewMediaSetOnSelectedIndexChanged;
        }


        private void SetupControls()
        {
            SetupRecoveryModel();
            SetupRadioGroups();
        }


        private void RegisterMessages()
        {
            Messenger.Default.Register<BackupPathMessage>(this, typeof(BackupPathMessage).Name, OnBackupPathReceived);
        }

        private void OnBackupPathReceived(BackupPathMessage message)
        {
            if (message != null) textEditBackupPath.Text = message.BackupPath;
        }

        private void SetupRecoveryModel()
        {
            textEditRecoveryModel.Text = App.Connection.CurrentDatabase?.RecoveryModel.ToString();
        }

        private void SetupRadioGroups()
        {
            radioGroupBackupToExisting.SelectedIndex = 0;
            radioGroupBackupNewMediaSet.SelectedIndex = -1;
            textEditNewMediaSetName.Enabled = false;
            memoEditNewMediaSetDescription.Enabled = false;
        }

        private void SimpleButtonBrowseOnClick(object sender, EventArgs e)
        {
            var serverFolderExp = new ServerFolderExplorer();
            serverFolderExp.StartPosition = FormStartPosition.CenterParent;
            serverFolderExp.ShowDialog();
            serverFolderExp.Dispose();
        }


        private void RadioGroupBackupToExistingOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroupBackupToExisting.SelectedIndex == 0)
            {
                radioGroupBackupNewMediaSet.SelectedIndex = -1;
                textEditNewMediaSetName.Enabled = false;
                memoEditNewMediaSetDescription.Enabled = false;
                radioGroupAppendOrOverwriteBackupSet.Enabled = true;
                checkEditMediaSetName.Enabled = true;
                textEditMediaSetName.Enabled = true;
            }
        }

        private void RadioGroupBackupNewMediaSetOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroupBackupNewMediaSet.SelectedIndex == 0)
            {
                radioGroupBackupToExisting.SelectedIndex = -1;
                textEditNewMediaSetName.Enabled = true;
                memoEditNewMediaSetDescription.Enabled = true;
                radioGroupAppendOrOverwriteBackupSet.Enabled = false;
                checkEditMediaSetName.Enabled = false;
                textEditMediaSetName.Enabled = false;
            }
        }

        private void InitializeBindings()
        {
            var fluent = mvvmContextBackupView.OfType<BackupViewModel>();
            SetTriggers(fluent);
            BindCommands(fluent);
            SetDataBindings(fluent);
        }

        private void SetTriggers(MVVMContextFluentAPI<BackupViewModel> fluent)
        {
            fluent.SetTrigger(vm => vm.State, state =>
            {
                switch (state)
                {
                    case BackupViewModel.WindowState.Open:
                        break;
                    case BackupViewModel.WindowState.Closed:
                        Close();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(state), state, null);
                }
            });

            fluent.SetTrigger(vm => vm.IncrementalBackupOption,
                b => { comboBoxEditBackupType.SelectedIndex = b ? 1 : 0; });

            fluent.SetTrigger(vm => vm.StatusImageIndex,
                i => { pictureEditProgressStatus.Image = imageCollectionBackupView.Images[i]; });
        }

        private void BindCommands(MVVMContextFluentAPI<BackupViewModel> fluent)
        {
            fluent.BindCommand(simpleButtonOK, vm => vm.ValidateAndRunBackup());
            fluent.BindCommand(simpleButtonCancel, vm => vm.Cancel());
        }

        private void SetDataBindings(MVVMContextFluentAPI<BackupViewModel> fluent)
        {
            fluent.SetBinding(progressBarControlDatabaseBackup, x => x.EditValue,
                vm => vm.BackupPercentageComplete);
            fluent.SetBinding(lcProgressStatusImage, x => x.Text, vm => vm.ProgressMessage);
            fluent.SetBinding(textEditBackupPath, x => x.Text, vm => vm.BackupName);
            fluent.SetBinding(labelControlServerName, x => x.Text, vm => vm.CurrentInstanceName);
            fluent.SetBinding(labelControlCurrentUser, x => x.Text, vm => vm.CurrentLoginName);
            fluent.SetBinding(textEditRecoveryModel, x => x.Text, vm => vm.RecoveryModel);
            fluent.SetBinding(checkEditVerifyBackup, x => x.Checked, vm => vm.VerifyBackupOnComplete);
            fluent.SetBinding(checkEditPerformChecksum, x => x.Checked, vm => vm.PerformChecksum);
            fluent.SetBinding(checkEditContinueOnError, x => x.Checked, vm => vm.ContinueAfterError);
            fluent.SetItemsSourceBinding(comboBoxEditDatabaseList.Properties, cb => cb.Items, x => x.DatabaseList,
                (i, e) => Equals(i.Value, e), entity => new ImageComboBoxItem(entity), null, null);
            fluent.SetBinding(comboBoxEditDatabaseList, x => x.EditValue, vm => vm.CurrentDatabase);
            fluent.SetItemsSourceBinding(comboBoxEditBackupType.Properties, cb => cb.Items, x => x.IncrementalTypes,
                (i, e) => Equals(i.Value, e), entity => new ImageComboBoxItem(entity), null, null);
            fluent.SetBinding(comboBoxEditBackupType, x => x.EditValue, vm => vm.IncrementalTypeString);
            fluent.SetBinding(checkEditCopyOnlyBackup, x => x.Checked, vm => vm.CopyOnly);
        }
    }
}