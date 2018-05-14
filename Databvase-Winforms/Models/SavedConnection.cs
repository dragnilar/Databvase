using System;
using System.Collections.Generic;
using System.Linq;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Models
{
    /// <summary>
    ///  A saved connection is a connection that can be used to connect to a SQL Server Database. It provides methods to test and validate itself.
    /// </summary>
    public class SavedConnection
    {
        public string NickName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string Instance { get; set; }
        public int Timeout { get; set; }

        /// <summary>
        /// Returns the saved connections Nickname value
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return NickName;
        }

        /// <summary>
        /// Returns true if the connection is valid (I.E. It does not violate any rules such as no username).
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            var errorMessageList = new List<string>();

            ValidateNickname(errorMessageList);

            if (string.IsNullOrEmpty(Instance)) errorMessageList.Add("No server/instance specified");

            if (Timeout < 1) errorMessageList.Add("Connection timeout must be at least 1 second");

            if (!WindowsAuthentication)
                if (string.IsNullOrEmpty(UserName))
                    errorMessageList.Add("You must specify a User Id if you are not using Windows Authentication");

            var errorHeader = "Error(s) Creating Connection String";

            return new ValidatorService(new ServiceContainer(this)).CheckErrors(errorMessageList, errorHeader);

        }

        private void ValidateNickname(List<string> errorMessageList)
        {
            if (string.IsNullOrEmpty(NickName))
            {
                errorMessageList.Add("Nickname is required.");
            }

            if (App.Config.ConnectionStrings.Any(r => r.NickName == NickName))
            {
                errorMessageList.Add("Nickname is already being used by another saved string, please enter a different one.");
            }
        }

        /// <summary>
        /// Tests the current saved connection and returns a tuple indicating whether or not the saved connection can successfully connect to a server.
        /// </summary>
        /// <returns>String containing any possible error messages and true/false indicating whether or not the connection was successful</returns>
        public (string errorMessage, bool valid) TestConnection()
        {
            var server = GetServer();
            return TestServerConnection(server);
        }

        private (string errorMessage, bool isValid) TestServerConnection(Server server)
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


        /// <summary>
        /// Returns an SMO server object based off of the parameters used on the current instance of SavedConnection. You may optionally specify a database
        /// to connect to for the server object by passing in a database name. 
        /// </summary>
        /// <param name="dataBaseName">Optional, the name of a database that you wish to connect to using the returned SMO server</param>
        /// <returns></returns>
        public Server GetServer(string dataBaseName = null)
        {
            var server = new Server();
            server.ConnectionContext.ServerInstance = Instance;
            server.ConnectionContext.NonPooledConnection = true;
            server.ConnectionContext.StatementTimeout = Timeout;

            if (WindowsAuthentication == false)
            {
                server.ConnectionContext.LoginSecure = false;
                server.ConnectionContext.Login = UserName;
                server.ConnectionContext.Password = Password;
            }
            else
            {
                server.ConnectionContext.LoginSecure = true;

            }

            if (dataBaseName != null) server.ConnectionContext.DatabaseName = dataBaseName;

            return server;

        }
    }
}