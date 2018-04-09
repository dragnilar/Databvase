using System.Data;
using System.Threading.Tasks;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors;
using LWSqlQueryTool_Winforms.Models;
using LWSqlQueryTool_Winforms.Services;

namespace LWSqlQueryTool_Winforms.View_Models
{
    [POCOViewModel()]
    public class QueryControlViewModel
    {
        public virtual QueryDocumentEntity Entity { get; set; }
        public virtual DataTable GridSource { get; set; }
        public virtual bool ClearGrid { get; set; }
        public virtual string ResultsMessage { get; set; }
        public virtual bool QueryRunning { get; set; }

        public QueryControlViewModel()
        {
            Entity = new QueryDocumentEntity {DocumentText = string.Empty};
            GridSource = null;
            ResultsMessage = string.Empty;
            QueryRunning = false;
        }



        /// <summary>
        /// Executes an asynchronous query using the text on the query editor pane
        /// </summary>
        public async void AsynchronousQuery()
        {
            if (QueryRunning)
            {
                return;
            }

            QueryRunning = true;
            var sqlQuery = GetSQLQueryString();
            await Task.Run(() => this.GetService<IQueryEditorService>().RunQuery(sqlQuery)).ContinueWith((x) => ProcessResults(x.Result), 
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
            {
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
                }
            }
        }

        public void Update()
        {
            //TODO - Implement some kind of functionality if necessary, otherwise do nothing here since this is needed for the MVVM context
        }




    }
}
