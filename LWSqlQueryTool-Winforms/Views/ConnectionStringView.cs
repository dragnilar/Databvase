using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using LWSqlQueryTool_Winforms.Models;
using LWSqlQueryTool_Winforms.Services;
using LWSqlQueryTool_Winforms.View_Models;

namespace LWSqlQueryTool_Winforms.Views
{
    public partial class ConnectionStringView : Form
    {
        //TODO this is just plain nasty, clean it up
        public ConnectionStringView()
        {
            InitializeComponent();
            if (!mvvmContextConnectionStringView.IsDesignMode)
                InitializeBindings();
                MVVMContext.RegisterXtraMessageBoxService();

            HackControls();
        }

        //Hacks to enable feature on controls that are not natively supported by DX
        private void HackControls()
        {
            
            FieldInfo f = comboBoxEditInstances.Properties.GetType().GetField("fTextEditStyle", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (f != null) f.SetValue(comboBoxEditInstances.Properties, TextEditStyles.Standard);
        }

        private void ShowConnectionStringBuilder()
        {
            navigationFrame.SelectedPage = navigationPageConnetionStringBuilder;
        }

        private void ShowConnectionStringManager()
        {
            navigationFrame.SelectedPage = navigationPageConnectionStringManager;
        }



        private void InitializeBindings()
        {
            
            var fluent = mvvmContextConnectionStringView.OfType<ConnectionStringViewModel>();

            mvvmContextConnectionStringView.RegisterService(SplashScreenService.Create(splashScreenManager));
            

            fluent.BindCommand(simpleButtonCreateNewString, x=>x.GoToConnectionStringBuilder());
            fluent.BindCommand(simpleButtonCancelCreateConnection, x=>x.GoToConnectionStringManager());
            fluent.BindCommand(simpleButtonCancel, x=>x.Cancel());
            fluent.BindCommand(simpleButtonSaveAndTest, x=>x.TestAndSave());
            fluent.BindCommand(simpleButtonConnect, x=>x.Connect());
            fluent.BindCommand(simpleButtonQueryInstances, x=>x.GetInstances());

            fluent.SetBinding(textEditDatabaseName, x => x.EditValue, y => y.InitalCatalog);
            fluent.SetBinding(textEditNickName, x => x.EditValue, y => y.NickName);
            fluent.SetBinding(textEditPassword, x => x.EditValue, y => y.Password);
            fluent.SetBinding(textEditUserName, x => x.EditValue, y => y.UserId);
            fluent.SetBinding(lookUpEditConnectionStrings.Properties, x => x.DataSource,
                vm => vm.SavedConnectionStrings);
            fluent.SetBinding(lookUpEditConnectionStrings, x => x.EditValue, y => y.SelectedConnectionString);
            fluent.SetBinding(checkEditWindowsAuthentication, x => x.EditValue, y => y.UseWindowsAuthentication);
            fluent.SetBinding(spinEditConnectionTimeout, x => x.EditValue, y => y.ConnectTimeout);
            fluent.SetItemsSourceBinding(comboBoxEditInstances.Properties, cb=>cb.Items , x=>x.Instances,
                (i, e) => Equals(i.Value, e), entity => new ImageComboBoxItem(entity), null, null);
            fluent.SetBinding(comboBoxEditInstances, x => x.EditValue, vm => vm.DataSource);
            fluent.SetBinding(simpleButtonConnect, x => x.Enabled, vm => vm.CanConnect);



            fluent.SetTrigger(x => x.WindowState, (state) =>
            {
                switch (state)
                {
                    case ConnectionStringViewModel.State.Open:
                        break;
                    case ConnectionStringViewModel.State.ConnectionStringManager:
                        ShowConnectionStringManager();
                        break;
                    case ConnectionStringViewModel.State.ConnectionStringBuilder:
                        ShowConnectionStringBuilder();
                        break;
                    case ConnectionStringViewModel.State.Exit:
                        Close();
                        break;
                    default:
                        break;
                }
            });

            fluent.SetTrigger(x => x.UseWindowsAuthentication, (state) =>
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