using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace DatabvaseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Test Getting Databases");
                Console.WriteLine("2. Test Getting Instances");
                Console.WriteLine("3. Test A Query");
                Console.WriteLine("4. Test Insert and Update");
                Console.WriteLine("Enter an option with a key or press esc to quit.");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        DatabasesTest();
                        break;
                    case ConsoleKey.D2:
                        InstancesTest();
                        break;
                    case ConsoleKey.D3:
                        QueryTest();
                        break;
                    case ConsoleKey.D4:
                        UpdateInsertTest();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\n Invalid Key");
                        continue;
                }

                break;
            }
        }




        private static void EndOfMethod()
        {
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
            MainMenu();
        }

        private static void DatabasesTest()
        {
            Console.WriteLine("Databases on your server... ");
            var server = new Server(@"DRAGNILAR-PC\MSSQLSERVER_LITE");

            foreach (Database db in server.Databases)
            {
                Console.WriteLine("Database: " + db.Name );
            }

            EndOfMethod();
        }

        private static void InstancesTest()
        {
            Console.WriteLine("Getting instances...");
            var table = SmoApplication.EnumAvailableSqlServers(false);
            if (table.Rows.Count > 0 )
            {
                foreach (DataRow dr in table.Rows)
                {
                    Console.WriteLine("Instance Name: " + dr["Name"]);

                }
            }

            EndOfMethod();
        }

        private static void QueryTest()
        {
            Console.WriteLine("Doing a test query...");
            var server = new Server();
            server.ConnectionContext.LoginSecure = true;
            server.ConnectionContext.ServerInstance = @"DRAGNILAR-PC\MSSQLSERVER_LITE";
            server.ConnectionContext.DatabaseName = "MonsterDB";
            server.ConnectionContext.NonPooledConnection = true;
            server.ConnectionContext.Connect();
            if (server.ConnectionContext.IsOpen)
            {
                Console.WriteLine("Connected...");
                var result = server.ConnectionContext.ExecuteWithResults("select * from monsters");

                Console.WriteLine(result.Tables.Count > 0
                    ? "Query successful and returned results..."
                    : "Query successful and returned no results...");
            }
            else
            {
                Console.WriteLine("Connection failed...");
            }

            server.ConnectionContext.Disconnect();

            EndOfMethod();

        }

        private static void UpdateInsertTest()
        {
            Console.WriteLine("Doing a test query...");
            var server = new Server();

            server.ConnectionContext.LoginSecure = true;
            server.ConnectionContext.ServerInstance = @"DRAGNILAR-PC\MSSQLSERVER_LITE";
            server.ConnectionContext.DatabaseName = "MonsterDB";
            server.ConnectionContext.NonPooledConnection = true;
            server.ConnectionContext.Connect();
            if (server.ConnectionContext.IsOpen)
            {
                Console.WriteLine("Connected...");
                Console.WriteLine("Executing test insert...");
                server.ConnectionContext.ExecuteWithResults("insert into monsters (MonsterName, MonsterHP, MonsterType) values (\'Duplicate Monster\', 111111, \'Duplicate\')");

                Console.WriteLine("Command(s) completed successfully.");
                Console.ReadKey();

                Console.WriteLine("Executing test update...");
                server.ConnectionContext.ExecuteWithResults(
                    "update monsters set MonsterName = \'Really Duplicated Monster\' where MonsterName = \'Duplicate Monster\'");

                Console.WriteLine("Command(s) completed successfully.");
                Console.ReadKey();

                Console.WriteLine("Cleaning up...");
                server.ConnectionContext.ExecuteWithResults(
                    "delete from monsters where MonsterType = \'Duplicate\'");

                Console.WriteLine("Command(s) completed successfully.");
                Console.WriteLine("Done...");
                
            }
            else
            {
                Console.WriteLine("Connection failed...");
            }

            server.ConnectionContext.Disconnect();

            EndOfMethod();
        }

    }
}
