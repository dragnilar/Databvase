using Databvase_Winforms.DAL;
using Databvase_Winforms.Models;
using DevExpress.Mvvm;

namespace Databvase_Winforms.Services
{
    internal interface IQueryEditorService
    {
        QueryResult RunQuery(string sqlQuery, string dbName, SavedConnection connection);
    }

    internal class QueryEditorService : IQueryEditorService
    {

        public QueryResult RunQuery(string sqlQuery, string dbName, SavedConnection connection)
        {
            //TODO - See if this actually hurts performance, if so either switch back to static or something else so its always available.
            var queryUnit = new SQLQuery();
            return sqlQuery == null ? null : queryUnit.SendQueryAndGetResult(sqlQuery, dbName, connection);
        }

    }
}