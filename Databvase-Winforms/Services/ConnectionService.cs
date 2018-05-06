using System;
using System.Collections.Generic;
using System.Linq;
using Databvase_Winforms.Models;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Services
{
    public class ConnectionService
    {
        private (string, bool) NullConnectionResponse => ("Connection is null, please try again", false);
        public List<SavedConnection> CurrentConnections = new List<SavedConnection>();
        public InstanceAndDatabaseTracker InstanceTracker = new InstanceAndDatabaseTracker();


        public Server GetServerAtInstanceName(string instanceName, string dbName = null)
        {
            if (CurrentConnections.Any(x=>x.Instance == instanceName))
            {
                var connection = CurrentConnections.First(x => x.Instance == instanceName);
                return GetServer(connection, dbName);
            }

            return null;
        }

        public Server GetServerAtSavedConnection(SavedConnection connection, string dbName = null)
        {
            return GetServer(connection, dbName);
        }

        public Server GetServerAtCurrentInstanceAndDatabase()
        {
            if (InstanceTracker != null && CurrentConnections.Any())
            {
                var connection = CurrentConnections.First(x => x.Instance == InstanceTracker.CurrentInstance.Name);
                return GetServer(connection, InstanceTracker.CurrentDatabase.Name);
            }

            return null;

        }

        private  Server GetServer(SavedConnection connection, string dbName)
        {
            var server = new Server();
            server.ConnectionContext.ServerInstance = connection.Instance;
            server.ConnectionContext.NonPooledConnection = true;
            server.ConnectionContext.StatementTimeout = connection.Timeout;

            if (connection.WindowsAuthentication == false)
            {
                server.ConnectionContext.LoginSecure = false;
                server.ConnectionContext.Login = connection.UserName;
                server.ConnectionContext.Password = connection.Password;
            }
            else
            {
                server.ConnectionContext.LoginSecure = true;

            }

            if (dbName != null) server.ConnectionContext.DatabaseName = dbName;

            return server;
        }

        public (string errorMessage, bool valid) SetAndTestConnection(SavedConnection savedConnection)
        {
            if (savedConnection != null)
            {
                var currentServer = GetServerAtSavedConnection(savedConnection);
                var result = TestServerConnection(currentServer);

                if (!result.valid) return result;
                if (CurrentConnections.All(x => x.Instance != savedConnection.Instance))
                {
                    CurrentConnections.Add(savedConnection);
                }

                InstanceTracker.CurrentInstance = currentServer;
                InstanceTracker.CurrentDatabase = null;

                return result;

            }

            return NullConnectionResponse;
        }

        public (string errorMessage, bool valid) TestSavedConnection(SavedConnection savedConnection)
        {
            if (savedConnection != null)
            {
                var server = GetServerAtSavedConnection(savedConnection);
                return TestServerConnection(server);
            }

            return NullConnectionResponse;
        }

        private (string errorMessage, bool valid) TestServerConnection(Server server)
        {
            try
            {
                server.ConnectionContext.Connect();
                server.ConnectionContext.Disconnect();
                return (string.Empty, true);
            }
            catch (Exception ex)
            {

                return (ex.Message, false);
            }
        }

        public void DisconnectCurrentInstance()
        {
            var connectionToRemove = CurrentConnections.FirstOrDefault(x => x.Instance == InstanceTracker.CurrentInstance.Name);
            if (connectionToRemove != null)
            {
                CurrentConnections.Remove(connectionToRemove);
                InstanceTracker.CurrentInstance = !CurrentConnections.Any() ? null : GetServerAtInstanceName(CurrentConnections.First().Instance);
                InstanceTracker.CurrentDatabase = null;
            }
        }

        public SavedConnection GetCurrentConnection()
        {
            return CurrentConnections.First(r => r.Instance == InstanceTracker.CurrentInstance.Name);
        }
    }
}