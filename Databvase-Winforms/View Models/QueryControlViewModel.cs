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
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class QueryControlViewModel : IDocumentContent
    {

        public QueryControlViewModel()
        {
            Entity = new QueryDocumentEntity {DocumentText = string.Empty};
            GridSource = null;
            ResultsMessage = string.Empty;
            QueryRunning = false;
            CurrentDatabase = GetCurrentDatabaseFromTracker();
            DatabasesList = GetDatabaseNamesFromTracker();
            AddIndicator = false;
            DefaultTextEditorFont = App.Config.DefaultTextEditorFont;
            QueryConnection = App.Connection.GetCurrentConnection();
        }

        public virtual QueryDocumentEntity Entity { get; set; }
        public virtual DataTable GridSource { get; set; }
        public virtual bool ClearGrid { get; set; }
        public virtual string ResultsMessage { get; set; }
        public virtual bool QueryRunning { get; set; }
        public virtual string CurrentDatabase { get; set; }
        public virtual List<string> DatabasesList { get; set; }
        public virtual bool AddIndicator { get; set; }
        public virtual Font DefaultTextEditorFont { get; set; }
        public virtual SavedConnection QueryConnection { get; set; }
        public IDocumentOwner DocumentOwner { get; set; }
        public object Title { get; set; }
        //TODO - See if perhaps we can use a server object in here instead of having to keep a saved connection...


        /// <summary>
        ///     Executes an asynchronous query using the text on the query editor pane
        /// </summary>
        public async void AsynchronousQuery()
        {
            if (QueryRunning) return;

            QueryRunning = true;
            var sqlQuery = GetSQLQueryString();
            await Task.Run(() => this.GetService<IQueryEditorService>().RunQuery(sqlQuery, CurrentDatabase, QueryConnection )).ContinueWith(
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
                    ResultsMessage = $"Errors Occurred: \n{result.ResultsMessage}";
                }
                else
                {
                    ClearGrid = true;
                    GridSource = result.ResultsSet.Tables.Count > 0 ? result.ResultsSet.Tables[0] : null;
                    ClearGrid = false;
                    ResultsMessage = result.ResultsMessage;
                    if (App.Config.ShowRowNumberColumn)
                    {
                        AddRowNumberColumn();
                    }
                    
                }
        }

        private void AddRowNumberColumn()
        {
            AddIndicator = true;
            AddIndicator = false;
        }

        public void Update()
        {
            //TODO - Implement some kind of functionality if necessary, otherwise do nothing here since this is needed for the MVVM context
        }

        private string GetCurrentDatabaseFromTracker()
        {
            return App.Connection.InstanceTracker.CurrentDatabase != null ? App.Connection.InstanceTracker.CurrentDatabase.Name : string.Empty;
        }

        private List<string> GetDatabaseNamesFromTracker()
        {
            var list = new List<string>();
            foreach (Database db in App.Connection.InstanceTracker.CurrentInstance.Databases) list.Add(db.Name);

            return list;
        }


        public void OnClose(CancelEventArgs e)
        {
            //Do nothing for now...
        }

        public void OnDestroy()
        {
            //Do nothing for now...
        }


    }
}