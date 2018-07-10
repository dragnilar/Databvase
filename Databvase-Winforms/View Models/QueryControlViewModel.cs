using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Models;
using Databvase_Winforms.Services;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using System.Drawing;
using System.Linq;
using Databvase_Winforms.Messages;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class QueryControlViewModel
    {
        public static QueryControlViewModel Create()
        {
            return ViewModelSource.Create<QueryControlViewModel>();
        }

        public QueryControlViewModel()
        {   
            ResultsMessage = string.Empty;
            QueryRunning = false;
            CurrentDatabase = GetCurrentDatabaseFromTracker();
            DatabasesList = GetDatabaseNamesFromTracker();
            DefaultTextEditorFont = App.Config.DefaultTextEditorFont;
            QueryConnection = App.Connection.GetCurrentConnection();
            ControlState = QueryResultState.Default;
            QueryPaneName = string.Empty;
        }

        public enum QueryResultState
        {
            Default,
            ShowGrid,
            ShowMessages
        }
        public virtual QueryResultState ControlState { get; set; }
        public virtual string ResultsMessage { get; set; }
        public virtual bool QueryRunning { get; set; }
        public virtual string CurrentDatabase { get; set; }
        public virtual List<string> DatabasesList { get; set; }
        public virtual Font DefaultTextEditorFont { get; set; }
        public virtual SavedConnection QueryConnection { get; set; }
        public virtual string QueryPaneName { get; set; }

        protected IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();
        //TODO - See if perhaps we can use a server object in here instead of having to keep a saved connection...


        /// <summary>
        ///     Executes an asynchronous query using the text on the query editor pane
        /// </summary>
        public async void AsynchronousQuery(string queryString)
        {
            if (QueryRunning) return;

            QueryRunning = true;
            await Task.Run(() => this.GetService<IQueryEditorService>().RunQuery(queryString, CurrentDatabase, QueryConnection )).ContinueWith(
                x => ProcessResults(x.Result),
                TaskScheduler.FromCurrentSynchronizationContext()).ConfigureAwait(false);
            
            QueryRunning = false;
        }

        /// <summary>
        /// Saves the current query in the query pane to a file.
        /// </summary>
        /// <param name="content"></param>
        public void SaveCurrentQuery(string content)
        {
            new FileSaveService().SaveQueryDialogAsync(content);
        }

        private void ProcessResults(QueryResult result)
        {
            if (result != null)
                if (result.HasErrors)
                {
                    ResultsMessage = $"Errors Occurred: \n{result.ResultsMessage}";
                    ControlState = QueryResultState.ShowMessages;
                }
                else
                {
                    UpgradeGridStateWithResults(result);
                }
        }

        private void UpgradeGridStateWithResults(QueryResult result)
        {
            new QueryGridCreateMessage(result.ResultsSet.Tables.Count, QueryPaneName);

            for (int i = 0; i < result.ResultsSet.Tables.Count; i++)
            {
                var gridNumber = i + 1;
                new QueryGridDataSourceMessage(result.ResultsSet.Tables[i], $"Grid Control {gridNumber}", QueryPaneName);
            }

            
        }

        private string GetCurrentDatabaseFromTracker()
        {
            return App.Connection.CurrentDatabase != null ? App.Connection.CurrentDatabase.Name : string.Empty;
        }

        private List<string> GetDatabaseNamesFromTracker()
        {
            var list = new List<string>();
            foreach (Database db in App.Connection.CurrentServer.Databases) list.Add(db.Name);

            return list;
        }


    }
}