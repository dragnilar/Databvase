using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Models;
using Databvase_Winforms.Models.Data_Providers;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Services
{
    public class ScriptGeneratorService
    {

        public ScriptGenerationResult GenerateSelectAllStatement(ObjectExplorerNode node)
        {
            switch (node.Data)
            {
                case Table selectedTable:
                    return new ScriptGenerationResult($"SELECT * FROM {GetFullTablePath(selectedTable)}", selectedTable.Parent.Name);
                case View selectedView:
                    return new ScriptGenerationResult($"SELECT * FROM {GetFullViewPath(selectedView)}", selectedView.Parent.Name);
                default:
                    return new ScriptGenerationResult(string.Empty, string.Empty);
            }
        }



        public ScriptGenerationResult GenerateSelectTopStatement(ObjectExplorerNode node)
        {
            switch (node.Data)
            {
                case Table selectedTable:
                    return new ScriptGenerationResult($"SELECT TOP {App.Config.NumberOfRowsForTopSelectScript} * FROM {GetFullTablePath(selectedTable)}", selectedTable.Parent.Name);
                case View selectedView:
                    return new ScriptGenerationResult($"SELECT TOP {App.Config.NumberOfRowsForTopSelectScript} * FROM {GetFullViewPath(selectedView)}", selectedView.Parent.Name);
                default:
                    return new ScriptGenerationResult(string.Empty, string.Empty);
            }
        }

        private string GetFullTablePath(Table selectedTable)
        {
            return $"[{selectedTable.Parent.Name}].[{selectedTable.Schema}].[{selectedTable.Name}]";
        }

        private string GetFullViewPath(View selectedView)
        {
            return $"[{selectedView.Parent.Name}].[{selectedView.Schema}].[{selectedView.Name}]";
        }

        public ScriptGenerationResult GenerateModifyScript(ObjectExplorerNode node)
        {
            switch (node.Data)
            {
                case UserDefinedFunction function:
                {
                   return GenerateFunctionScript(function, true);
                }
                case StoredProcedure storedProcedure:
                {
                    return GenerateStoredProcedureScript(storedProcedure, true);
                }
            }

            return new ScriptGenerationResult(string.Empty, string.Empty);
        }

        public ScriptGenerationResult GenerateAlterScript(ObjectExplorerNode node)
        {
            switch (node.Data)
            {
                case UserDefinedFunction function:
                {
                    return GenerateFunctionScript(function, false);
                }
                case StoredProcedure storedProcedure:
                {
                    return GenerateStoredProcedureScript(storedProcedure, false);
                    }
            }

            return new ScriptGenerationResult(string.Empty, string.Empty);
        }

        private ScriptGenerationResult GenerateFunctionScript(UserDefinedFunction function, bool isModifyScript)
        {
            var scriptBuilder = new StringBuilder();
            try
            {
                scriptBuilder.Append(function.ScriptHeader(isModifyScript));
                scriptBuilder.Append(function.TextBody);
                return new ScriptGenerationResult(scriptBuilder.ToString(), function.Parent.Name);
            }
            catch (Exception e)
            {
                return new ScriptGenerationResult(true, e.Message);
            }
        }

        private ScriptGenerationResult GenerateStoredProcedureScript(StoredProcedure storedProcedure,
            bool isModifyScript)
        {
            var scriptBuilder = new StringBuilder();
            try
            {
                scriptBuilder.Append(storedProcedure.ScriptHeader(isModifyScript));
                scriptBuilder.Append(storedProcedure.TextBody);
                return new ScriptGenerationResult(scriptBuilder.ToString(), storedProcedure.Parent.Name);
            }
            catch (Exception e)
            {
                return new ScriptGenerationResult(true, e.Message);
            }
        }
    }
}
