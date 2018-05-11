using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Views;
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
        public void RunQueryBuilder()
        {
            var dxSqlDataSource = GetDataSourceForQueryBuilder();
            var query = ShowQueryBuilder(dxSqlDataSource);
            if (query != null)
            {
                new NewScriptMessage(FormatQueryBuilderOutput(query), App.Connection.CurrentDatabase.Name);
            }

        }

        private SqlDataSource GetDataSourceForQueryBuilder()
        {
            var form = GetMainWindow();
            IWaitFormActivator waitFormActivator = new WaitFormActivator(form, typeof(WaitFormWithCancel), true);
            IExceptionHandler exceptionHandler = new ExceptionHandler(UserLookAndFeel.Default, form);
            var currentServer = App.Connection.GetServerAtCurrentInstanceAndDatabase();
            var dxConnectionStringParameters =
                new CustomStringConnectionParameters(currentServer.ConnectionContext.ConnectionString);
            var dxSqlDataSource = new SqlDataSource(dxConnectionStringParameters);
            ConnectionHelper.OpenConnection(dxSqlDataSource.Connection, exceptionHandler, waitFormActivator,
                null);
            return dxSqlDataSource;
        }

        private static string ShowQueryBuilder(SqlDataSource dxSqlDataSource)
        {
            dxSqlDataSource.AddQueryWithQueryBuilder();
            var query = (dxSqlDataSource.Queries.FirstOrDefault() as SelectQuery)?.GetSql(dxSqlDataSource.Connection
                .GetDBSchema());
            return query;
        }

        private static string FormatQueryBuilderOutput(string query)
        {
            return AutoSqlWrapHelper.AutoSqlTextWrap(query, 9999);
        }

        private static Form GetMainWindow()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MainView))
                {
                    return form;
                }
            }

            return null;
        }
    }
}
