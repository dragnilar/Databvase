using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Models;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class ConnectionWindowViewModel
    {
        public enum State
        {
            Open,
            ConnectionStringManager,
            ConnectionStringBuilder,
            Exit
        }


        public ConnectionWindowViewModel()
        {
            InitalizeValues();
            SelectedConnection = null;
            SavedConnectionStrings = App.Config.ConnectionStrings;
            CanConnect = false;
        }

        public virtual bool UseWindowsAuthentication { get; set; }
        public virtual string DataSource { get; set; }
        public virtual int ConnectTimeout { get; set; }
        public virtual string UserId { get; set; }
        public virtual string Password { get; set; }
        public virtual string NickName { get; set; }
        public virtual List<SQLServerInstance> Instances { get; set; }
        public virtual State WindowState { get; set; }
        public virtual SavedConnection SelectedConnection { get; set; }
        public virtual List<SavedConnection> SavedConnectionStrings { get; set; }
        public virtual bool CanConnect { get; set; }
        public virtual bool ShowOnStartup { get; set; }


        protected ISplashScreenService SplashScreenService => this.GetService<ISplashScreenService>();
        protected IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();

        private void InitalizeValues()
        {
            UseWindowsAuthentication = false;
            DataSource = string.Empty;
            ConnectTimeout = 30;
            UserId = string.Empty;
            Password = string.Empty;
            WindowState = State.Open;
            ShowOnStartup = App.Config.ShowConnectionWindowOnStartup;
        }

        //Simple Dependency For SelectedConnectionString, binds at runtime
        protected void OnSelectedConnectionChanged()
        {
            CanConnect = SelectedConnection != null;
        }

        //Simple Dependency For ShowOnStartUp, binds at runtime
        protected void OnShowOnStartUpChanged()
        {
            App.Config.ShowConnectionWindowOnStartup = ShowOnStartup;
            App.Config.Save();
        }

        public void Connect()
        {
            var result = App.Connection.SetAndTestConnection(SelectedConnection);
            if (result.valid)
            {
                new InstanceConnectedMessage(App.Connection.InstanceTracker);
                WindowState = State.Exit;
            }
            else
            {
                ShowErrorMessage($"Error occurred connecting to Server instance \n {result.errorMessage}", "Connection Error");
            }

        }

        public void Cancel()
        {
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

            var connection = BuildConnection();
            if (!connection.IsValid())
            {
                return;
            }

            var testResult = connection.TestConnection();
            if (testResult.valid)
            {
                SaveConnectionToBeBuilt(connection);
                WindowState = State.ConnectionStringManager;
            }
            else
            {
                ShowErrorMessage($"{testResult.errorMessage}",
                    "Connection Test Failed");
            }
        }

        private void SaveConnectionToBeBuilt(SavedConnection connection)
        {
            App.Config.ConnectionStrings.Add(connection);

            App.Config.Save();

            SelectedConnection =
                SavedConnectionStrings.FirstOrDefault(r => r.NickName == connection.NickName);
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
                ShowErrorMessage("An error occurred getting the instances: \n " + e, "Error");
            }
        }

        private SavedConnection BuildConnection()
        {
            var connection = new SavedConnection
            {
                Instance = DataSource,
                Timeout = ConnectTimeout,
                NickName = NickName
            };

            if (!UseWindowsAuthentication)
            {
                connection.UserName = UserId;
                connection.Password = Password;
            }
            else
            {
                connection.WindowsAuthentication = true;
            }

            return connection;
        }

        private void ShowErrorMessage(string message, string header)
        {
            MessageBoxService.ShowMessage(message, header, MessageButton.OK, MessageIcon.Error);
        }
    }
}