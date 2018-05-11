using Databvase_Winforms.Controls.QueryTextEditor;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Models;
using DevExpress.Mvvm;

namespace Databvase_Winforms.Services
{
    internal interface IQueryEditorService
    {
        QueryResult RunQuery(string sqlQuery, string dbName, SavedConnection connection);
        string GetSqlQueryFromQueryPane();
        void Copy();
        void Cut();
        void Paste();
    }

    internal class QueryEditorService : IQueryEditorService
    {
        private readonly QueryTextEditor _queryPane;

        public QueryEditorService(QueryTextEditor queryPane)
        {
            _queryPane = queryPane;
        }

        public QueryResult RunQuery(string sqlQuery, string dbName, SavedConnection connection)
        {
            //TODO - See if this actually hurts performance, if so either switch back to static or something else so its always available.
            var queryUnit = new SQLQuery();
            return sqlQuery == null ? null : queryUnit.SendQueryAndGetResult(sqlQuery, dbName, connection);
        }

        public string GetSqlQueryFromQueryPane()
        {
            string sqlQuery;

            if (_queryPane.Document.Selection.Length > 1)
            {
                var selection = _queryPane.Document.Selection;
                sqlQuery = _queryPane.Document.GetText(selection);
            }
            else
            {
                sqlQuery = _queryPane.Text;
            }

            //TODO - Comment parsing needs to be improved
            if (string.IsNullOrEmpty(sqlQuery) || sqlQuery.StartsWith("--") || sqlQuery.StartsWith("/*")) return null;

            return sqlQuery;
        }

        public void Copy()
        {
            _queryPane.Copy();
        }

        public void Cut()
        {
            _queryPane.Cut();
            
        }

        public void Paste()
        {
            _queryPane.Paste();
        }

    }
}