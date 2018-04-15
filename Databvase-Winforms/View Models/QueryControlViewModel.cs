using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Models;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class QueryControlViewModel
    {

        public QueryControlViewModel()
        {
            Entity = new QueryDocumentEntity {DocumentText = string.Empty};
            GridSource = null;
            ResultsMessage = string.Empty;
            QueryRunning = false;
            CurrentDatabase = string.Empty;
            DatabasesList = SQLServerInterface.GetDatabaseNames();
            AddIndicator = false;
        }

        public virtual QueryDocumentEntity Entity { get; set; }
        public virtual DataTable GridSource { get; set; }
        public virtual bool ClearGrid { get; set; }
        public virtual string ResultsMessage { get; set; }
        public virtual bool QueryRunning { get; set; }
        public virtual string CurrentDatabase { get; set; }
        public virtual List<string> DatabasesList { get; set; }
        public virtual bool AddIndicator { get; set; }


        /// <summary>
        ///     Executes an asynchronous query using the text on the query editor pane
        /// </summary>
        public async void AsynchronousQuery()
        {
            if (QueryRunning) return;

            QueryRunning = true;
            App.Connection.CurrentDatabase = CurrentDatabase;
            var sqlQuery = GetSQLQueryString();
            await Task.Run(() => this.GetService<IQueryEditorService>().RunQuery(sqlQuery)).ContinueWith(
                x => ProcessResults(x.Result),
                TaskScheduler.FromCurrentSynchronizationContext()).ConfigureAwait(false);
            QueryRunning = false;
        }

        private string GetSQLQueryString()
        {
            var sqlQueryString = this.GetService<IQueryEditorService>().GetSqlQueryFromQueryPane();

            return sqlQueryString;
        }

        private void ProcessResults(QueryResult result)
        {
            if (result != null)
                if (result.HasErrors)
                {
                    ResultsMessage = $"Errors Occured: \n{result.ResultsMessage}";
                }
                else
                {
                    ClearGrid = true;
                    GridSource = result.ResultsSet.Tables.Count > 0 ? result.ResultsSet.Tables[0] : null;
                    ClearGrid = false;
                    ResultsMessage = result.ResultsMessage;
                    AddIndicatorColumn();
                }
        }

        private void AddIndicatorColumn()
        {
            AddIndicator = true;
            AddIndicator = false;
        }

        public void Update()
        {
            //TODO - Implement some kind of functionality if necessary, otherwise do nothing here since this is needed for the MVVM context
        }
    }
}