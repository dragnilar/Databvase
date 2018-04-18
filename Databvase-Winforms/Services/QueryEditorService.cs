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
            return sqlQuery == null ? null : SQLServerInterface.SendQueryAndGetResult(sqlQuery, dbName, connection);
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

    }
}