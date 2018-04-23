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

        public (string script, string parentName) GenerateSelectAllStatement(object selectedObjectExplorerData)
        {
            switch (selectedObjectExplorerData)
            {
                case Table selectedTable:
                    return ($"SELECT * FROM {GetFullTablePath(selectedTable)}", selectedTable.Parent.Name);
                case View selectedView:
                    return ($"SELECT * FROM {GetFullViewPath(selectedView)}", selectedView.Parent.Name);
                default:
                    return (string.Empty, string.Empty);
            }
        }

        public (string script, string parentName) GenerateSelectTopStatement(object selectedObjectExplorerData)
        {
            switch (selectedObjectExplorerData)
            {
                case Table selectedTable:
                    return ($"SELECT TOP {App.Config.NumberOfRowsForTopSelectScript} * FROM {GetFullTablePath(selectedTable)}", selectedTable.Parent.Name);
                case View selectedView:
                    return ($"SELECT TOP {App.Config.NumberOfRowsForTopSelectScript} * FROM {GetFullViewPath(selectedView)}", selectedView.Parent.Name);
                default:
                    return (string.Empty, string.Empty);
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
    }
}
