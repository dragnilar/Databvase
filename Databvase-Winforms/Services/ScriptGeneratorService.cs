﻿using System;
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
            return $"SELECT * FROM {GetFullTablePath(selectedTable)}";
        }

        public string GenerateSelectTopStatement(Table selectedTable)
        {
            var quantityString = "1000";

            return $"SELECT TOP {quantityString} * FROM {GetFullTablePath(selectedTable)}";
        }

        private string GetFullTablePath(Table selectedTable)
        {
            return $"[{selectedTable.Parent.Name}].[{selectedTable.Schema}].[{selectedTable.Name}]";
        }
    }
}