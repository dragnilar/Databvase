using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraRichEdit;
using LWSqlQueryTool_Winforms.DAL;
using LWSqlQueryTool_Winforms.Models;

namespace LWSqlQueryTool_Winforms.Services
{
    interface IQueryEditorService
    {
        QueryResult RunQuery();
    }
    class QueryEditorService: IQueryEditorService
    {
        private RichEditControl _queryPane;

        public QueryEditorService(RichEditControl queryPane)
        {
            _queryPane = queryPane;
        }

        public QueryResult RunQuery()
        {

            var sqlQuery = string.Empty;

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
            if (string.IsNullOrEmpty(sqlQuery) || sqlQuery.StartsWith("--") || sqlQuery.StartsWith("/*"))
            {
                return null;
            }

            return SQLServerInterface.SendQueryStringAndGetResult(sqlQuery);
        }

        
    }
}
