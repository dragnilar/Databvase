using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM.Services;
using LWSqlQueryTool_Winforms.DAL;
using LWSqlQueryTool_Winforms.Models;
using LWSqlQueryTool_Winforms.Services;

namespace LWSqlQueryTool_Winforms.View_Models
{
    [POCOViewModel()]
    public class ConnectionStringViewModel
    {
        public virtual bool UseWindowsAuthentication { get; set; }
        public virtual string DataSource { get; set; }
        public virtual string InitalCatalog { get; set; }
        public virtual int ConnectTimeout { get; set; }
        public virtual string UserId { get; set; }
        public virtual string Password { get; set; }
        public virtual string NickName { get; set; }
        public virtual List<string> Datasources { get; set; } //TODO - Need to look into if this is even feasible...
        public virtual List<SQLServerInstance> Instances { get; set; }
        public virtual State WindowState { get; set; }
        public virtual SavedConnectionString SelectedConnectionString { get; set; }
        public virtual List<SavedConnectionString> SavedConnectionStrings { get; set; }
        public virtual bool CanConnect { get; set; }


        protected ISplashScreenService SplashScreenService => this.GetService<ISplashScreenService>();
        protected IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();


        public ConnectionStringViewModel()
        {
            InitalizeValues();
            SelectedConnectionString = null;
            SavedConnectionStrings = App.Config.ConnectionStrings;
            CanConnect = false;
        }

        void InitalizeValues()
        {
            UseWindowsAuthentication = false;
            DataSource = string.Empty;
            InitalCatalog = string.Empty;
            ConnectTimeout = 30;
            UserId = string.Empty;
            Password = string.Empty;
            WindowState = State.Open;
        }

        //Simple Dependency For SelectedConnectionString, binds at runtime
        protected void OnSelectedConnectionStringChanged()
        {
            CanConnect = SelectedConnectionString != null;
        }

        public void Connect()
        {
            if (TestConnection(SelectedConnectionString.ConnectionString))
            {
                ConnectionStringService.CurrentConnectionString = SelectedConnectionString.ConnectionString;
                WindowState = State.Exit;
            }


        }

        public void Cancel()
        {
            ConnectionStringService.CurrentConnectionString = null;
            WindowState = State.Exit;

        }

        public void GoToConnectionStringBuilder()
        {
            WindowState = State.ConnectionStringBuilder;
        }

        public void GoToConnectionStringManager()
        {
            InitalizeValues();
            WindowState = State.ConnectionStringManager;
        }

        public void TestAndSave()
        {
            if (!IsConnectionValid())
            {
                return;
            }

            if (IsNickNameADuplicate())
            {
                MessageBoxService.ShowMessage("Nickname is already being used by another saved string, please enter a different one.");
                return;
            }

            var builder = BuildConnection();

            if (TestConnection(builder.ConnectionString))
            {
                var ConnectionStringToBeBuilt = new SavedConnectionString
                {
                    NickName = NickName,
                    ConnectionString = builder.ConnectionString
                };

                SaveConnectionStringAndUpdateViewModel(ConnectionStringToBeBuilt);


                WindowState = State.ConnectionStringManager;
            }
        }

        private bool IsNickNameADuplicate()
        {
            if (App.Config.ConnectionStrings.Any(r=>r.NickName == NickName))
            {
                return true;
            }

            return false;
        }

        private void SaveConnectionStringAndUpdateViewModel(SavedConnectionString connectionString)
        {
            App.Config.ConnectionStrings.Add(connectionString);

            App.Config.Save();

            SelectedConnectionString =
                SavedConnectionStrings.FirstOrDefault(r => r.NickName == connectionString.NickName);
        }


        public void GetInstances()
        {
            try
            {
                SplashScreenService.ShowSplashScreen();
                Instances = SQLServerInterface.GetInstances();
                SplashScreenService.HideSplashScreen();
            }
            catch (Exception e)
            {
                SplashScreenService.HideSplashScreen();

                MessageBoxService.ShowMessage("An error occured getting the instances: \n " + e);
            }


        }



        private bool TestConnection(string connectionString)
        {
            return SQLServerInterface.TestConnection(connectionString);
        }

        private SqlConnectionStringBuilder BuildConnection()
        {
            //TODO - ADD VALIDATION?
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = DataSource,
                InitialCatalog = InitalCatalog,
                ConnectTimeout = ConnectTimeout
            };

            if (!UseWindowsAuthentication)
            {
                builder.UserID = UserId;
                builder.Password = Password;
            }
            else
            {
                builder.IntegratedSecurity = true;
            }

            return builder;
        }

        private bool IsConnectionValid()
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(DataSource))
            {
                errors.Add("No server/instance specified");
            }

            if (string.IsNullOrEmpty(InitalCatalog))
            {
                errors.Add("No database specified");
            }

            if (ConnectTimeout < 1)
            {
                errors.Add("Connection timeout must be at least 1 second");
            }

            if (!UseWindowsAuthentication)
            {
                if (string.IsNullOrEmpty(UserId))
                {
                    errors.Add("You must specify a User Id if you are not using Windows Authentication");
                }
            }

            if (errors.Count <= 0) return true;
            var errorBuilder = new StringBuilder("There are errors with the connection string, please review them below: \n");
            foreach (var error in errors)
            {
                errorBuilder.AppendLine(error);
            }
            MessageBoxService.ShowMessage(errorBuilder.ToString(), "Error(s) Creating Connection String", MessageButton.OK, MessageIcon.Error);

            return false;

        }



        public enum State
        {
            Open,
            ConnectionStringManager,
            ConnectionStringBuilder,
            Exit
        }

    }
}
