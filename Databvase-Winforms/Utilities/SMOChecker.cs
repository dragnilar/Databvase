using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Utilities
{
    public static class SMOChecker
    {
        //TODO - Work in progress...
        static bool _returnValue;

        public static bool HasChildren(object smoObject)
        {
            var action = SMOActionDictionary[smoObject.GetType()];
            action(smoObject);
            return _returnValue;
        }


        private static void TableHasColumns(object smoObject)
        {
            _returnValue = ((Table) smoObject).Columns.Count > 0;
        }

        private static void DatabaseHasTables(object smoObject)
        {
            _returnValue = ((Database) smoObject).Tables.Count > 0;
        }

        private static void ServerHasDatabases(object smoObject)
        {
            _returnValue = ((Server) smoObject).Databases.Count > 0;
        }

        private static Dictionary<Type, Action<object>> SMOActionDictionary = new Dictionary<Type, Action<object>>
        {
            {typeof(Table), TableHasColumns},
            {typeof(Database), DatabaseHasTables},
            {typeof(Server), ServerHasDatabases}
        };
    }

      
}
