using System.Collections.Generic;
using System.Linq;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;

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
        /// Returns true if it can make a successful connection to a SQL Server database.
        /// </summary>
        /// <returns></returns>
        public (string errorMessage, bool valid) TestConnection()
        {
            return App.Connection.TestSavedConnection(this);
        }
    }
}