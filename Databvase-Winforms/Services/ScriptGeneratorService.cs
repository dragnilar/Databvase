using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Models.Data_Providers;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Services
{
    public class ScriptGeneratorService
    {

        public (string script, string parentName) GenerateSelectAllStatement(ObjectExplorerNode node)
        {
            switch (node.Data)
            {
                case Table selectedTable:
                    return ($"SELECT * FROM {GetFullTablePath(selectedTable)}", selectedTable.Parent.Name);
                case View selectedView:
                    return ($"SELECT * FROM {GetFullViewPath(selectedView)}", selectedView.Parent.Name);
                default:
                    return (string.Empty, string.Empty);
            }
        }

        public (string script, string parentName) GenerateSelectTopStatement(ObjectExplorerNode node)
        {
            switch (node.Data)
            {
                case Table selectedTable:
                    return ($"SELECT TOP {App.Config.NumberOfRowsForTopSelectScript} * FROM {GetFullTablePath(selectedTable)}", selectedTable.Parent.Name);
                case View selectedView:
                    return ($"SELECT TOP {App.Config.NumberOfRowsForTopSelectScript} * FROM {GetFullViewPath(selectedView)}", selectedView.Parent.Name);
                default:
                    return (string.Empty, string.Empty);
            }
        }

        public (string script, string parentName) GenerateModifyScript(ObjectExplorerNode node)
        {
            var scriptBuilder = new StringBuilder();
            switch (node.Data)
            {
                case UserDefinedFunction function:
                {
                    scriptBuilder.Append(function.ScriptHeader(true));
                    scriptBuilder.Append(function.TextBody);
                    return (scriptBuilder.ToString(), function.Parent.Name);
                }
                case StoredProcedure storedProcedure:
                {
                    scriptBuilder.Append(storedProcedure.ScriptHeader(true));
                    scriptBuilder.Append(storedProcedure.TextBody);
                    return (scriptBuilder.ToString(), storedProcedure.Parent.Name);
                }
            }

            return (string.Empty, string.Empty);
        }

        public (string script, string parentName) GenerateAlterScript(ObjectExplorerNode node)
        {
            var scriptBuilder = new StringBuilder();
            switch (node.Data)
            {
                case UserDefinedFunction function:
                {
                    scriptBuilder.Append(function.ScriptHeader(false));
                    scriptBuilder.Append(function.TextBody);
                    return (scriptBuilder.ToString(), function.Parent.Name);
                }
                case StoredProcedure storedProcedure:
                {
                    scriptBuilder.Append(storedProcedure.ScriptHeader(false));
                    scriptBuilder.Append(storedProcedure.TextBody);
                    return (scriptBuilder.ToString(), storedProcedure.Parent.Name);
                }
            }

            return (string.Empty, string.Empty);
        }

        private string GetFullTablePath(Table selectedTable)
        {
            return $"[{selectedTable.Parent.Name}].[{selectedTable.Schema}].[{selectedTable.Name}]";
        }

        private string GetFullViewPath(View selectedView)
        {
            return $"[{selectedView.Parent.Name}].[{selectedView.Schema}].[{selectedView.Name}]";
        }
    }
}
