using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.Messages;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Native.Sql;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.UI.Native;
using DevExpress.DataAccess.UI.Sql;
using DevExpress.DataAccess.UI.Wizard.Services;
using DevExpress.DataAccess.Wizard.Native;
using DevExpress.DataAccess.Wizard.Services;
using DevExpress.LookAndFeel;

namespace Databvase_Winforms.Dialogs
{
    public class QueryBuilderDialogWrapper
    {
        private Form form = new Form();



        public void ShowQueryBuilder()
        {
            IWaitFormActivator waitFormActivator = new WaitFormActivator(form, typeof(WaitFormWithCancel), true);
            IExceptionHandler exceptionHandler = new ExceptionHandler(UserLookAndFeel.Default, form);
            var currentServer = App.Connection.GetServerAtSpecificInstance(App.Connection.InstanceTracker.CurrentInstance.Name, App.Connection.InstanceTracker.CurrentDatabase.Name);
            var dxConnectionStringParameters =
                new CustomStringConnectionParameters(currentServer.ConnectionContext.ConnectionString);
            var dxSqlDataSource = new SqlDataSource(dxConnectionStringParameters);
            ConnectionHelper.OpenConnection(dxSqlDataSource.Connection, exceptionHandler, waitFormActivator,
                null);
            dxSqlDataSource.AddQueryWithQueryBuilder();

            var query = (dxSqlDataSource.Queries.FirstOrDefault() as SelectQuery)?.GetSql(dxSqlDataSource.Connection
                .GetDBSchema());
            if (query != null)
            {
                new NewScriptMessage(FormatQueryBuilderOutput(query), App.Connection.InstanceTracker.CurrentDatabase.Name);
            }

        }

        private static string FormatQueryBuilderOutput(string query)
        {
            return AutoSqlWrapHelper.AutoSqlTextWrap(query, 9999);
        }
    }
}
