using System.Collections.Generic;
using LWSqlQueryTool_Winforms.Models;

namespace LWSqlQueryTool_Winforms.Services
{
    public static class ConnectionStringManager
    {
        public static List<SavedConnectionString> SavedConnectionStrings = GetTempConnectionStrings();

        private static List<SavedConnectionString> GetTempConnectionStrings()
        {
            var list = new List<SavedConnectionString>
            {
                new SavedConnectionString
                {
                    NickName = "Test Connection",
                    ConnectionString =
                        "Data Source=DRAGNILAR-PC\\MSSQLSERVER_LITE;Initial Catalog=TriviaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                }
            };


            return list;
        }

        public static string CurrentConnectionString { get; set; } = string.Empty;



    }
}
