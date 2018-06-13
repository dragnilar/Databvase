using Microsoft.VisualStudio.TestTools.UnitTesting;
using Databvase_Winforms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Models;
using Databvase_WinformsTests;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.DAL.Tests
{
    [TestClass()]
    public class SQLQueryTests
    {
        TestHelpers testHelper = new TestHelpers();

        [TestMethod()]
        public void SendQueryAndGetResultTest()
        {
            testHelper.CreateAndPopulateTestDatabase();

            var testQueryObject = new SQLQuery();


            var testInsertStatement = $"INSERT INTO {testHelper.TestTableName} ({testHelper.TestColumnName}) values(1),(2),(3),(4),(5),(6)";

            var result = testQueryObject.SendQueryAndGetResult(testInsertStatement, testHelper.TestDatabaseName,
                testHelper.GetTestConnection());

            Assert.IsTrue(result.HasErrors == false);
            Assert.IsTrue(result.ResultsMessage == "Command(s) completed successfully");
            
            Console.WriteLine("Insert statement passed successfully");

            var testSelectStatement = $"SELECT * FROM {testHelper.TestTableName}";


            result = testQueryObject.SendQueryAndGetResult(testSelectStatement, testHelper.TestDatabaseName, testHelper.GetTestConnection());


            Assert.IsTrue(result.HasErrors == false);
            Assert.IsTrue(result.ResultsSet.Tables.Count > 0);

            Console.WriteLine("Select statement passed successfully");

            testHelper.DropTestDatabaseIfItExists();



        }


    }
}