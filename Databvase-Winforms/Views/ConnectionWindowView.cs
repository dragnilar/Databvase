using System;
using System.Reflection;
using Databvase_Winforms.View_Models;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Databvase_Winforms.Views
{
    public partial class ConnectionWindowView : XtraForm
    {
        
        //TODO this is just plain nasty, clean it up
        public ConnectionWindowView()
        {
            InitializeComponent();
            if (!mvvmContextConnectionWindowView.IsDesignMode)
                InitializeBindings();
            MVVMContext.RegisterXtraMessageBoxService();

            HackControls();
            HookupEvents();
        }

        private void HookupEvents()
        {
            simpleButtonShowPassword.Click += SimpleButtonShowPasswordOnClick;
        }

        private void SimpleButtonShowPasswordOnClick(object sender, EventArgs e)
        {
            if (simpleButtonShowPassword.Text == "Show Password")
            {

                textEditPassword.Properties.PasswordChar = '\0';
                simpleButtonShowPassword.Text = "Hide Password";
            }
            else
            {
                textEditPassword.Properties.PasswordChar = '*';
                simpleButtonShowPassword.Text = "Show Password";
            }
        }

        //Hacks to enable feature on controls that are not inherently supported by DX
        private void HackControls()
        {
            var fieldInfo = comboBoxEditInstances.Properties.GetType().GetField("fTextEditStyle",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (fieldInfo != null) fieldInfo.SetValue(comboBoxEditInstances.Properties, TextEditStyles.Standard);
        }

        private void ShowConnectionBuilder()
        {
            navigationFrame.SelectedPage = navigationPageConnectionBuilder;
        }

        private void ShowConnectionManager()
        {
            navigationFrame.SelectedPage = navigationPageConnectionManager;
        }


        private void InitializeBindings()
        {
            var fluent = mvvmContextConnectionWindowView.OfType<ConnectionWindowViewModel>();

            mvvmContextConnectionWindowView.RegisterService(SplashScreenService.Create(splashScreenManager));


            fluent.BindCommand(simpleButtonCreateNewString, x => x.GoToConnectionBuilder());
            fluent.BindCommand(simpleButtonCancelCreateConnection, x => x.GoToConnectionManager());
            fluent.BindCommand(simpleButtonCancel, x => x.Cancel());
            fluent.BindCommand(simpleButtonSaveAndTest, x => x.TestAndSave());
            fluent.BindCommand(simpleButtonConnect, x => x.Connect());
            fluent.BindCommand(simpleButtonQueryInstances, x => x.GetInstances());

            fluent.SetBinding(textEditNickName, x => x.EditValue, y => y.NickName);
            fluent.SetBinding(textEditPassword, x => x.EditValue, y => y.Password);
            fluent.SetBinding(textEditUserName, x => x.EditValue, y => y.UserId);
            fluent.SetBinding(lookUpEditSavedConnections.Properties, x => x.DataSource,
                vm => vm.SavedConnections);
            fluent.SetBinding(lookUpEditSavedConnections, x => x.EditValue, y => y.SelectedConnection);
            fluent.SetBinding(checkEditWindowsAuthentication, x => x.EditValue, y => y.UseWindowsAuthentication);
            fluent.SetBinding(spinEditConnectionTimeout, x => x.EditValue, y => y.ConnectTimeout);
            fluent.SetItemsSourceBinding(comboBoxEditInstances.Properties, cb => cb.Items, x => x.Instances,
                (i, e) => Equals(i.Value, e), entity => new ImageComboBoxItem(entity), null, null);
            fluent.SetBinding(comboBoxEditInstances, x => x.EditValue, vm => vm.DataSource);
            fluent.SetBinding(simpleButtonConnect, x => x.Enabled, vm => vm.CanConnect);
            fluent.SetBinding(checkEditShowOnStartup, x => x.Checked, x => x.ShowOnStartup);


            fluent.SetTrigger(x => x.WindowState, state =>
            {
                switch (state)
                {
                    case ConnectionWindowViewModel.State.Open:
                        break;
                    case ConnectionWindowViewModel.State.ConnectionManager:
                        ShowConnectionManager();
                        break;
                    case ConnectionWindowViewModel.State.ConnectionBuilder:
                        ShowConnectionBuilder();
                        break;
                    case ConnectionWindowViewModel.State.Exit:
                        Close();
                        break;
                    default:
                        break;
                }
            });

            fluent.SetTrigger(x => x.UseWindowsAuthentication, state =>
            {
                switch (state)
                {
                    case false:
                        textEditPassword.Enabled = true;
                        textEditUserName.Enabled = true;
                        break;
                    case true:
                        textEditPassword.Enabled = false;
                        textEditUserName.Enabled = false;
                        break;
                    default:
                        break;
                }
            });
        }
    }
}