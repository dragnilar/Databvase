using System;
using System.Text;
using Databvase_Winforms.Models.Data_Providers;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Models
{
    public class ScriptGenerator
    {

        private ScriptGenerationResultService ResultService => new ScriptGenerationResultService(new ServiceContainer(this));

        #region ScriptGenerators

        public void GenerateSelectAllStatement(ObjectExplorerNode node)
        {
            switch (node.Data)
            {
                case Table selectedTable:
                    ResultService.ResultWithNoErrors($"SELECT * FROM {GetFullTablePath(selectedTable)}", selectedTable.Parent.Name);
                    break;
                case View selectedView:
                    ResultService.ResultWithNoErrors($"SELECT * FROM {GetFullViewPath(selectedView)}", selectedView.Parent.Name);
                    break;
                default:
                    ResultService.ResultWithNoErrors(string.Empty, string.Empty);
                    break;
            }
        }

        public void GenerateSelectTopStatement(ObjectExplorerNode node)
        {
            switch (node.Data)
            {
                case Table selectedTable:
                    ResultService.ResultWithNoErrors($"SELECT TOP {App.Config.NumberOfRowsForTopSelectScript} * FROM {GetFullTablePath(selectedTable)}", selectedTable.Parent.Name);
                    break;
                case View selectedView:
                    ResultService.ResultWithNoErrors($"SELECT TOP {App.Config.NumberOfRowsForTopSelectScript} * FROM {GetFullViewPath(selectedView)}", selectedView.Parent.Name);
                    break;
                default:
                    ResultService.ResultWithNoErrors(string.Empty, string.Empty);
                    break;
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

        public void GenerateModifyScript(ObjectExplorerNode node)
        {
            switch (node.Data)
            {
                case UserDefinedFunction function:
                    {
                         GenerateFunctionScript(function, true);
                        break;
                    }
                case StoredProcedure storedProcedure:
                    {
                         GenerateStoredProcedureScript(storedProcedure, true);
                        break;
                    }
                default:
                {
                    ResultService.ResultWithNoErrors(string.Empty, string.Empty);
                    break;
                }
            }


        }

        public void GenerateAlterScript(ObjectExplorerNode node)
        {
            switch (node.Data)
            {
                case UserDefinedFunction function:
                    {
                         GenerateFunctionScript(function, false);
                        break;
                    }
                case StoredProcedure storedProcedure:
                    {
                         GenerateStoredProcedureScript(storedProcedure, false);
                        break;
                    }
                default:
                {
                    ResultService.ResultWithNoErrors(string.Empty, string.Empty);
                    break;
                }
            }
        }

        private void GenerateFunctionScript(UserDefinedFunction function, bool isModifyScript)
        {
            var scriptBuilder = new StringBuilder();
            try
            {
                scriptBuilder.Append(function.ScriptHeader(isModifyScript));
                scriptBuilder.Append(function.TextBody);
                ResultService.ResultWithNoErrors(scriptBuilder.ToString(), function.Parent.Name);
            }
            catch (Exception e)
            {
                ResultService.ResultWithException(true, e.Message);
            }
        }

        private void GenerateStoredProcedureScript(StoredProcedure storedProcedure,
            bool isModifyScript)
        {
            var scriptBuilder = new StringBuilder();
            try
            {
                scriptBuilder.Append(storedProcedure.ScriptHeader(isModifyScript));
                scriptBuilder.Append(storedProcedure.TextBody);
                ResultService.ResultWithNoErrors(scriptBuilder.ToString(), storedProcedure.Parent.Name);
            }
            catch (Exception e)
            {
                ResultService.ResultWithException(true, e.Message);
            }
        }

        public void GenerateBlankScript(string selectedDatabaseName)
        {
            ResultService.ResultWithNoErrors(string.Empty, selectedDatabaseName);
        }

        #endregion




    }
}
