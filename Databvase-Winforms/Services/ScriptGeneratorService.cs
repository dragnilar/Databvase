using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Services
{
    public class ScriptGeneratorService
    {

        public string GenerateSelectAllStatement(string tableName)
        {
            return $"SELECT * FROM {tableName}";
        }

        public string GenerateSelectTopStatement(string tableName)
        {
            var quantityString = "1000";

            return $"SELECT TOP {quantityString} * FROM {tableName}";
        }
    }
}
