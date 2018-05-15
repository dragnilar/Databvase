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
    public class QueryControlViewModel
    {
        public static QueryControlViewModel Create()
        {
            return ViewModelSource.Create<QueryControlViewModel>();
        }

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

        public virtual QueryDocumentEntity Entity { get;  set; }
        public virtual DataTable GridSource { get; set; }
        public virtual bool ClearGrid { get; set; }
        public virtual string ResultsMessage { get; set; }
        public virtual bool QueryRunning { get; set; }
        public virtual string CurrentDatabase { get; set; }
        public virtual List<string> DatabasesList { get; set; }
        public virtual bool AddIndicator { get; set; }
        public virtual Font DefaultTextEditorFont { get; set; }
        public virtual SavedConnection QueryConnection { get; set; }
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

        public void CopyFromQueryTextEditor()
        {
            this.GetService<IQueryEditorService>().Copy();
        }

        public void CutFromQueryTextEditor()
        {
            this.GetService<IQueryEditorService>().Cut();
        }

        public void PasteIntoQueryTextEditor()
        {
            this.GetService<IQueryEditorService>().Paste();
            this.GetService<IQueryEditorService>().ShowLineNumbers();
        }

        public void ShowLineNumbersOnTextEditor()
        {
            this.GetService<IQueryEditorService>().ShowLineNumbers();
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

        /// <summary>
        /// Appends the text on the query text editor entity's document text with a new document message's text. Also changes the currently database
        /// value (if one is included in the message).
        /// </summary>
        /// <param name="message"></param>
        public void ReceiveNewScriptMessageAndSetScriptText(NewScriptMessage message)
        {
            if (message != null)
            {
                Entity.DocumentText += message.Script;
                CurrentDatabase = message.SelectedDatabase;
            }

        }


    }
}