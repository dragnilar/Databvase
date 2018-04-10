using Databvase_Winforms.DAL;
using Databvase_Winforms.Models;
using DevExpress.XtraRichEdit;

namespace Databvase_Winforms.Services
{
    internal interface IQueryEditorService
    {
        QueryResult RunQuery(string sqlQuery);
        string GetSqlQueryFromQueryPane();
    }

    internal class QueryEditorService : IQueryEditorService
    {
        private readonly RichEditControl _queryPane;

        public QueryEditorService(RichEditControl queryPane)
        {
            _queryPane = queryPane;
        }

        public QueryResult RunQuery(string sqlQuery)
        {
            return sqlQuery == null ? null : SQLServerInterface.SendQueryAndGetResult(sqlQuery);
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