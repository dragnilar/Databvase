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
        private InstanceAndDatabaseTracker _instanceTracker = new InstanceAndDatabaseTracker();
        public readonly List<SavedConnection> CurrentConnections = new List<SavedConnection>();
        public Database CurrentDatabase => _instanceTracker.CurrentDatabase;
        public Server CurrentServer => _instanceTracker.CurrentInstance;




        #region Instance Tracker Methods

        public void DisconnectCurrentInstance()
        {
            var connectionToRemove = CurrentConnections.FirstOrDefault(x => x.Instance == _instanceTracker.CurrentInstance.Name);
            if (connectionToRemove != null)
            {
                CurrentConnections.Remove(connectionToRemove);
                _instanceTracker.CurrentInstance = !CurrentConnections.Any() ? null : GetServerAtInstanceName(CurrentConnections.First().Instance);
                _instanceTracker.CurrentDatabase = null;
            }
        }

        public InstanceAndDatabaseTracker GetCurrentTracker()
        {
            return _instanceTracker;
        }

        public void UpdateInstanceTracker(InstanceAndDatabaseTracker tracker)
        {
            _instanceTracker = tracker;
        }

        #endregion

        #region Get Server Methods

        public Server GetServerAtInstanceName(string instanceName, string dbName = null)
        {
            if (CurrentConnections.Any(x => x.Instance == instanceName))
            {
                var connection = CurrentConnections.First(x => x.Instance == instanceName);
                return GetAServer(connection, dbName);
            }

            return null;
        }

        public Server GetServerAtSavedConnection(SavedConnection connection, string dbName = null)
        {
            return GetAServer(connection, dbName);
        }

        public Server GetServerAtCurrentInstanceAndDatabase()
        {
            if (_instanceTracker != null && CurrentConnections.Any())
            {
                var connection = CurrentConnections.First(x => x.Instance == _instanceTracker.CurrentInstance.Name);
                return GetAServer(connection, _instanceTracker.CurrentDatabase.Name);
            }

            return null;

        }

        private Server GetAServer(SavedConnection connection, string dbName)
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

        #endregion

        #region Saved Connection Methods

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

                _instanceTracker.CurrentInstance = currentServer;
                _instanceTracker.CurrentDatabase = null;

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

        public SavedConnection GetCurrentConnection()
        {
            return CurrentConnections.First(r => r.Instance == _instanceTracker.CurrentInstance.Name);
        }

        #endregion






    }
}