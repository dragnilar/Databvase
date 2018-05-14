using System;
using System.Collections.Generic;
using System.Linq;
using Databvase_Winforms.Models;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Services
{
    public class ConnectionService
    {
        private InstanceAndDatabaseTracker _mainInstanceAndDatabaseTracker = new InstanceAndDatabaseTracker();
        public readonly List<SavedConnection> CurrentConnections = new List<SavedConnection>();
        public Database CurrentDatabase => _mainInstanceAndDatabaseTracker.CurrentDatabase;
        public Server CurrentServer => _mainInstanceAndDatabaseTracker.CurrentInstance;
        private static (string, bool) NullConnectionResponse => ("Connection is null, please try again", false);

        #region Instance Tracker Methods

        public void DisconnectCurrentInstance()
        {
            var connectionToRemove = CurrentConnections.FirstOrDefault(x => x.Instance == _mainInstanceAndDatabaseTracker.CurrentInstance.Name);
            if (connectionToRemove != null)
            {
                CurrentConnections.Remove(connectionToRemove);
                _mainInstanceAndDatabaseTracker.CurrentInstance = !CurrentConnections.Any() ? null : GetServerAtInstanceName(CurrentConnections.First().Instance);
                _mainInstanceAndDatabaseTracker.CurrentDatabase = null;
            }
        }

        public InstanceAndDatabaseTracker GetCurrentTracker()
        {
            return _mainInstanceAndDatabaseTracker;
        }

        public void UpdateInstanceAndDatabaseTracker(InstanceAndDatabaseTracker tracker)
        {
            _mainInstanceAndDatabaseTracker = tracker;
        }

        #endregion

        #region Get Server Methods

        public Server GetServerAtInstanceName(string instanceName, string dbName = null)
        {
            if (CurrentConnections.Any(x => x.Instance == instanceName))
            {
                var connection = CurrentConnections.First(x => x.Instance == instanceName);
                return connection.GetServer(dbName);
            }

            return null;
        }

        #endregion

        #region Saved Connection Methods

        public (string errorMessage, bool valid) SetAndTestConnection(SavedConnection savedConnection)
        {

            if (savedConnection != null)
            {
                var server = savedConnection.GetServer();
                var result = savedConnection.TestConnection();

                if (!result.valid) return result;
                if (CurrentConnections.All(x => x.Instance != savedConnection.Instance))
                {
                    CurrentConnections.Add(savedConnection);
                }

                _mainInstanceAndDatabaseTracker.CurrentInstance = server;
                _mainInstanceAndDatabaseTracker.CurrentDatabase = null;

                return result;

            }

            return NullConnectionResponse;
        }

        public SavedConnection GetCurrentConnection()
        {
            return CurrentConnections.First(r => r.Instance == _mainInstanceAndDatabaseTracker.CurrentInstance.Name);
        }

        #endregion

    }
}