using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Utilities
{
    public class SMOChecker
    {
        public bool SqlObjectHasChildren(object t)
        {
            switch (t)
            {
                case Table table:
                    return table.Columns.Count > 0;
                case Database database:
                    return database.Tables.Count > 0;
                case Server server:
                    return server.Databases.Count > 0;
                    default:
                        return false;
            }
        }

        
    }

      
}
