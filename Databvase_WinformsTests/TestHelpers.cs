using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Models;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_WinformsTests
{
    public class TestHelpers
    {
        public  string TestDatabaseName = "GetTestDatabase";
        public  string TestTableName = "TestTable";
        public  string TestColumnName = "TestColumn";

        public void CreateAndPopulateTestDatabase()
        {
            var server = GetTestConnection().GetServer();
            DropTestDatabaseIfItExists(server);

            var db = GetTestDatabase(server);
            db.Create();

            server = null;

            server = GetTestConnection().GetServer();

            var testTable = new Table(db, TestTableName);

            var testColumn = new Column(testTable, TestColumnName, DataType.Int);

            testTable.Columns.Add(testColumn);

            testTable.Create();


        }

        public void DropTestDatabaseIfItExists(Server server = null)
        {
            if (server == null)
            {
                server = GetTestConnection().GetServer();
            }


            if (server.Databases.Contains(TestDatabaseName))
            {
                server.KillDatabase(TestDatabaseName);
            }

        }

        public SavedConnection GetTestConnection()
        {
            var connection = new SavedConnection
            {
                Instance = @"(LocalDB)\MSSQLLocalDB",
                NickName = "Test",
                WindowsAuthentication = true,
                Timeout = 30
            };

            return connection;
        }

        public Database GetTestDatabase(Server server)
        {
            var testDb = new Database(server, "GetTestDatabase");
            return testDb;
        }
    }
}
