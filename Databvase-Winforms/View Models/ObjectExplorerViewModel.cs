using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Models;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.XtraTreeList;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class ObjectExplorerViewModel
    {

        public ObjectExplorerViewModel()
        {

        }

        public void ScriptSelectAllForTable(Table selectedTable, string dbName)
        {
            var selectStatement = new ScriptGeneratorService().GenerateSelectAllStatement(selectedTable);
            var scriptMessage = new NewScriptMessage(selectStatement, dbName);

            Messenger.Default.Send(scriptMessage, NewScriptMessage.NewScriptSender);
        }

        public List<string> GetInstancesList()
        {
            //Only one instance at a time right now...
            var instancesList = new List<string>();
            instancesList.Add(App.Connection.CurrentConnection.Instance);
            return instancesList;
        }


    }
}