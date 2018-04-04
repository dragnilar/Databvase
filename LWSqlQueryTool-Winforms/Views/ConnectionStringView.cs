using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
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

            HookupEvents();
            SetUpSauces();
        }

        private void SetUpSauces()
        {
            lookUpEditConnectionStrings.Properties.DataSource = ConnectionStringManager.SavedConnectionStrings;
        }

        private void HookupEvents()
        {
            simpleButtonCancelCreateConnection.Click += SimpleButtonCancelCreateConnection_Click;
            simpleButtonCreateNewString.Click += SimpleButtonCreateNewString_Click;
            simpleButtonQueryDatabases.Click += SimpleButtonQueryDatabases_Click;
            simpleButtonQueryInstances.Click += SimpleButtonQueryInstances_Click;
            simpleButtonSave.Click += SimpleButtonSaveOnClick;
            simpleButtonConnect.Click += SimpleButtonConnectOnClick;
            simpleButtonCancel.Click += SimpleButtonCancelOnClick;
        }

        private void SimpleButtonCancelOnClick(object sender, EventArgs eventArgs)
        {
            ConnectionStringManager.CurrentConnectionString = null;
            Close();
        }

        private void SimpleButtonConnectOnClick(object sender, EventArgs eventArgs)
        {
            var connectionstring = ((SavedConnectionString) lookUpEditConnectionStrings.EditValue).ConnectionString;
            if (TestConnection(connectionstring))
            {
                ConnectionStringManager.CurrentConnectionString = connectionstring;
                Close();
            }
        }

        private void SimpleButtonSaveOnClick(object sender, EventArgs eventArgs)
        {
            //Test the connection and save it if it works
            TestAndSave();
        }

        private void TestAndSave()
        {
            //TODO - LOTS OF GOOD PLACES TO FAIL HERE!!!
            var builder = new SqlConnectionStringBuilder();

            builder.DataSource = comboBoxEditInstances.EditValue.ToString();
            builder.InitialCatalog = comboBoxEditDatabases.EditValue.ToString();
            builder.ConnectTimeout = 30;
            builder.UserID = textEditUserName.EditValue.ToString();
            builder.Password = textEditPassword.EditValue.ToString();

            if (TestConnection(builder.ConnectionString))
            {
                ConnectionStringManager.SavedConnectionStrings.Add(
                    new SavedConnectionString
                    {
                        NickName = "BLAH",
                        ConnectionString = builder.ConnectionString
                    });


                ShowConnectionStringManager();
            }


        }

        private void SimpleButtonQueryInstances_Click(object sender, EventArgs e)
        {
            //Get instances
        }

        private void SimpleButtonQueryDatabases_Click(object sender, EventArgs e)
        {
            //Get databvases
        }

        private void SimpleButtonCreateNewString_Click(object sender, EventArgs e)
        {
            ShowConnectionStringBuilder();
        }

        private void SimpleButtonCancelCreateConnection_Click(object sender, EventArgs e)
        {
            ShowConnectionStringManager();
        }

        private void ShowConnectionStringBuilder()
        {
            navigationFrame.SelectedPage = navigationPageConnetionStringBuilder;
        }

        private void ShowConnectionStringManager()
        {
            navigationFrame.SelectedPage = navigationPageConnectionStringManager;
        }

        private bool TestConnection(string connectionString)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var command = new SqlCommand())
                    {
                        command.CommandText = "SELECT 1";
                        command.Connection = conn;
                        command.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.ToString(), "Connection Failed");
                return false;
            }


            return true;
        }

        private void InitializeBindings()
        {
            var fluent = mvvmContextConnectionStringView.OfType<ConnectionStringViewModel>();
        }



    }
}