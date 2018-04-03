using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LWSqlQueryTool_Winforms.Models;

namespace LWSqlQueryTool_Winforms.Services
{
    public class SchemaService
    {
        public static void GetSchema()
        {
            var goNecction =
                new SqlConnection(ConnectionStringManager.CurrentConnectionString);

            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = goNecction;

            goNecction.Open();

            var tables = goNecction.GetSchema("Tables");
            var columns = goNecction.GetSchema("Columns");
            var dbName = goNecction.Database;

            var convertedList = (from rw in tables.AsEnumerable()
                select new SQLTable
                {
                    TableName = Convert.ToString(rw["TABLE_NAME"]),
                    TableSchema = Convert.ToString(rw["TABLE_SCHEMA"])
                }).ToList();

            goNecction.Close();
        }
    }
}
