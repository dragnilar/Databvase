﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Models;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class ConnectionStringViewModel
    {
        public enum State
        {
            Open,
            ConnectionStringManager,
            ConnectionStringBuilder,
            Exit
        }


        public ConnectionStringViewModel()
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
        }

        //Simple Dependency For SelectedConnectionString, binds at runtime
        protected void OnSelectedConnectionChanged()
        {
            CanConnect = SelectedConnection != null;
        }

        public void Connect()
        {
            if (App.Connection.SetAndTestConnection(SelectedConnection)) WindowState = State.Exit;
        }

        public void Cancel()
        {
            App.Connection.CurrentConnection = null;
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

            if (!connection.TestConnection())
            {
                SaveConnectionToBeBuilt(connection);
                WindowState = State.ConnectionStringManager;
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

                MessageBoxService.ShowMessage("An error occurred getting the instances: \n " + e);
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
    }
}