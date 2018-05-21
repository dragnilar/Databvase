using System;
using System.Windows.Forms;
using Databvase_Winforms.Dialogs;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Models;
using Databvase_Winforms.View_Models;
using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Microsoft.SqlServer.Management.Smo;

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
            RegisterService();
            RegisterMessages();
        }


        private void RegisterService()
        {
            MVVMContext.RegisterXtraMessageBoxService();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<BackupPathMessage>(this, typeof(BackupPathMessage).Name, OnBackupPathReceived);
        }

        private void OnBackupPathReceived(BackupPathMessage message)
        {
            if (message != null) textEditBackupPath.Text = message.BackupPath;
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
            SetupRadioGroups();
            SetupComboBoxes();
        }

        private void SetupRadioGroups()
        {
            radioGroupBackupToExisting.SelectedIndex = 0;
            radioGroupBackupNewMediaSet.SelectedIndex = -1;
            textEditNewMediaSetName.Enabled = false;
            memoEditNewMediaSetDescription.Enabled = false;
            radioGroupBackupSetExpire.Properties.Items.AddEnum(typeof(BackupViewModel.ExpirationDateOption));
        }

        private void SetupComboBoxes()
        {
            imageComboBoxEditCompressionSetting.Properties.Items.AddEnum(typeof(BackupCompressionOptions));
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

        #region MVVM Bindings

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

            fluent.SetTrigger(vm => vm.BackupEntityForVm.IncrementalBackupOption,
                b => { imageComboBoxEditBackupType.SelectedIndex = b ? 1 : 0; });

            fluent.SetTrigger(vm => vm.StatusImageIndex,
                i => { pictureEditProgressStatus.Image = imageCollectionBackupView.Images[i]; });

            fluent.SetTrigger(vm => vm.ExpireOption,
                exo =>
                {
                    switch (exo)
                    {
                        case BackupViewModel.ExpirationDateOption.On:
                            dateEditExpireOnDate.Enabled = true;
                            spinEditExpireAfterDays.Enabled = false;
                            break;
                        case BackupViewModel.ExpirationDateOption.After:
                            dateEditExpireOnDate.Enabled = false;
                            spinEditExpireAfterDays.Enabled = true;
                            break;
                    }
                });
        }

        private void BindCommands(MVVMContextFluentAPI<BackupViewModel> fluent)
        {
            fluent.BindCommand(simpleButtonOK, vm => vm.ValidateAndRunBackup());
            fluent.BindCommand(simpleButtonCancel, vm => vm.Cancel());
        }

        private void SetDataBindings(MVVMContextFluentAPI<BackupViewModel> fluent)
        {
            SetEntityDataBindings(fluent);
            SetMiscDataBindings(fluent);
            SetComboBoxDataBindings(fluent);
        }

        private void SetMiscDataBindings(MVVMContextFluentAPI<BackupViewModel> fluent)
        {
            fluent.SetBinding(progressBarControlDatabaseBackup, x => x.EditValue,
                vm => vm.BackupPercentageComplete);
            fluent.SetBinding(lcProgressStatusImage, x => x.Text, vm => vm.ProgressMessage);
            fluent.SetBinding(labelControlServerName, x => x.Text, vm => vm.CurrentInstanceName);
            fluent.SetBinding(labelControlCurrentUser, x => x.Text, vm => vm.CurrentLoginName);
            fluent.SetBinding(checkEditVerifyBackup, x => x.Checked, vm => vm.VerifyBackupOnComplete);
            fluent.SetBinding(radioGroupBackupSetExpire, x => x.EditValue, vm => vm.ExpireOption);
        }

        private void SetEntityDataBindings(MVVMContextFluentAPI<BackupViewModel> fluent)
        {
            //TODO - See if there's a simpler way to do this, this feels really... old fashioned.
            var entityBindingSource = new BindingSource {DataSource = typeof(BackupContainer)};
            SetEntityBindingsForTextEdits(entityBindingSource);
            SetEntityBindingsForCheckEdits(entityBindingSource);
            spinEditExpireAfterDays.DataBindings.Add(new Binding("EditValue", entityBindingSource, "ExpireAfterDays",
                true,
                DataSourceUpdateMode.OnPropertyChanged));
            dateEditExpireOnDate.DataBindings.Add(new Binding("EditValue", entityBindingSource, "ExpireDate", true,
                DataSourceUpdateMode.OnPropertyChanged));
            SetEntityBindingsForComboBoxes(entityBindingSource);
            fluent.SetObjectDataSourceBinding(entityBindingSource, x => x.BackupEntityForVm, x => x.Update());
        }

        private void SetEntityBindingsForTextEdits(BindingSource entityBindingSource)
        {
            textEditRecoveryModel.DataBindings.Add(new Binding("EditValue", entityBindingSource, "RecoveryModelString",
                true,
                DataSourceUpdateMode.OnPropertyChanged));
            textEditBackupPath.DataBindings.Add(new Binding("EditValue", entityBindingSource, "BackupPath",
                true, DataSourceUpdateMode.OnPropertyChanged));
            textEditBackupSetName.DataBindings.Add(new Binding("EditValue", entityBindingSource,
                "CurrentBackup.BackupSetName",
                true, DataSourceUpdateMode.OnPropertyChanged));
            textEditBackupDescription.DataBindings.Add(new Binding("EditValue", entityBindingSource,
                "CurrentBackup.BackupSetDescription", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void SetEntityBindingsForCheckEdits(BindingSource entityBindingSource)
        {
            checkEditPerformChecksum.DataBindings.Add(new Binding("EditValue", entityBindingSource,
                "CurrentBackup.Checksum"));
            checkEditCopyOnlyBackup.DataBindings.Add(new Binding("EditValue", entityBindingSource,
                "CurrentBackup.CopyOnly"));
            checkEditContinueOnError.DataBindings.Add(new Binding("EditValue", entityBindingSource,
                "CurrentBackup.ContinueAfterError"));
        }

        private void SetEntityBindingsForComboBoxes(BindingSource entityBindingSource)
        {
            imageComboBoxEditDatabaseList.DataBindings.Add(new Binding("EditValue", entityBindingSource, "CurrentDatabase",
                true, DataSourceUpdateMode.OnPropertyChanged));
            imageComboBoxEditCompressionSetting.DataBindings.Add(new Binding("EditValue", entityBindingSource,
                "CurrentBackup.CompressionOption",
                true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void SetComboBoxDataBindings(MVVMContextFluentAPI<BackupViewModel> fluent)
        {
            fluent.SetItemsSourceBinding(imageComboBoxEditDatabaseList.Properties, cb => cb.Items, x => x.DatabaseList,
                (i, e) => Equals(i.Value, e), entity => new ImageComboBoxItem(entity), null, null);
            fluent.SetItemsSourceBinding(imageComboBoxEditBackupType.Properties, cb => cb.Items, x => x.IncrementalTypes,
                (i, e) => Equals(i.Value, e), entity => new ImageComboBoxItem(entity), null, null);
            fluent.SetBinding(imageComboBoxEditBackupType, x => x.EditValue, vm => vm.IncrementalTypeString);
        }

        #endregion
    }
}