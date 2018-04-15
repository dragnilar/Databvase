using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Services
{
    public class ScriptGeneratorService
    {

        public string GenerateSelectAllStatement(Table selectedTable)
        {
            return $"SELECT * FROM [{selectedTable.Schema}].[{selectedTable.Name}]";
        }

        public string GenerateSelectTopStatement(string tableName)
        {
            var quantityString = "1000";

            return $"SELECT TOP {quantityString} * FROM {tableName}";
        }
    }
}
