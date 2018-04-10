using System;
using System.Collections.Generic;
using Databvase_Winforms.Models;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Services
{
    public static class ConnectionService
    {

        public static SavedConnection CurrentConnection { get; set; }
        public static string CurrentDatabase = "MonsterDB";

        public static Server GetServerAtCurrentDatabase()
        {
            return GetServer(CurrentDatabase);
        }

        public static Server GetServer(string dbName = null)
        {
            var CurrentServer = new Server();

            CurrentServer.ConnectionContext.ServerInstance = CurrentConnection.Instance;
            if (CurrentConnection.WindowsAuthentication == false)
            {
                CurrentServer.ConnectionContext.Login = CurrentConnection.UserName;
                CurrentServer.ConnectionContext.Password = CurrentConnection.Password;
            }
            else
            {
                CurrentServer.ConnectionContext.LoginSecure = true;
                CurrentServer.ConnectionContext.NonPooledConnection = true;
                CurrentServer.ConnectionContext.StatementTimeout = CurrentConnection.Timeout;
            }

            if (dbName != null)
            {
                CurrentServer.ConnectionContext.DatabaseName = dbName;
            }

            return CurrentServer;

        }



        public static bool SetAndTestConnection(SavedConnection savedConnection)
        {

            if (savedConnection != null)
            {
                CurrentConnection = savedConnection;

                var CurrentServer = GetServer();

                return TestServerConnection(CurrentServer);
            }

            CurrentConnection = null;
            return false;
        }

        public static bool TestSavedConnection(SavedConnection savedConnection)
        {
            if (savedConnection != null)
            {
                var server = GetServer();

                return TestServerConnection(server);
            }

            return false;
        }

        private static bool TestServerConnection(Server server)
        {
            try
            {
                server.ConnectionContext.Connect();
                server.ConnectionContext.Disconnect();
                return true;
            }
            catch
            {
                return false;
            }
        }






    }
}
