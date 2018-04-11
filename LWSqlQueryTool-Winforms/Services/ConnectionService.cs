using Databvase_Winforms.Models;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Services
{
    public static class ConnectionService
    {
        public static string CurrentDatabase = string.Empty;

        public static SavedConnection CurrentConnection { get; set; }

        public static Server GetServerAtCurrentDatabase()
        {
            return GetServerAtCurrentConnection(CurrentDatabase);
        }

        public static Server GetServerAtCurrentConnection(string dbName = null)
        {
            return GetServer(CurrentConnection, dbName);
        }

        private static Server GetServerAtSpecificConnection(SavedConnection connection, string dbName = null)
        {
            return GetServer(connection, dbName);
        }

        private static Server GetServer(SavedConnection connection, string dbName)
        {
            var server = new Server();
            server.ConnectionContext.ServerInstance = connection.Instance;
            server.ConnectionContext.NonPooledConnection = true;
            server.ConnectionContext.StatementTimeout = connection.Timeout;

            if (connection.WindowsAuthentication == false)
            {
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


        public static bool SetAndTestConnection(SavedConnection savedConnection)
        {
            if (savedConnection != null)
            {
                CurrentConnection = savedConnection;

                var CurrentServer = GetServerAtCurrentConnection();

                return TestServerConnection(CurrentServer);
            }

            CurrentConnection = null;
            return false;
        }

        public static bool TestSavedConnection(SavedConnection savedConnection)
        {
            if (savedConnection != null)
            {
                var server = GetServerAtSpecificConnection(savedConnection);
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