using System;
using System.Collections.Generic;
using Databvase_Winforms.Models;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Services
{
    public static class ConnectionService
    {

        public static Server CurrentServer { get; set; }

        public static bool SetAndTestConnection(SavedConnection savedConnection)
        {

            if (savedConnection != null)
            {
                CurrentServer = new Server();

                CurrentServer.ConnectionContext.ServerInstance = savedConnection.Instance;
                if (savedConnection.WindowsAuthentication == false)
                {
                    CurrentServer.ConnectionContext.Login = savedConnection.UserName;
                    CurrentServer.ConnectionContext.Password = savedConnection.Password;
                }
                else
                {
                    CurrentServer.ConnectionContext.LoginSecure = true;
                    CurrentServer.ConnectionContext.NonPooledConnection = true;
                    CurrentServer.ConnectionContext.StatementTimeout = savedConnection.Timeout;
                }

                return TestConnection();
            }

            return false;
        }

        private static bool TestConnection()
        {
            try
            {
                CurrentServer.ConnectionContext.Connect();
                CurrentServer.ConnectionContext.Disconnect();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
