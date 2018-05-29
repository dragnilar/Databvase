using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Globals;
using Databvase_Winforms.Models.Data_Providers;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Utilities
{
    public static class DatabvaseSmoExtensions
    {

        public static void RemoveNodesForTable(this Table table, ObjectExplorerDataSource source)
        {
            var columnsToRemove = source.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.Column &&
                                                                                  ((Table)r.GetColumnFromNode().Parent) == table).ToList();
            foreach (var removable in columnsToRemove)
            {
                source.DataSource.Remove(removable);
            }
        }

        public static void RemoveNodesForDatabase(this Database database, ObjectExplorerDataSource source)
        {

                RemoveAllColumnsForDatabase(database, source);
                RemoveAllTablesForDatabase(database, source);
                RemoveAllViewsForDatabase(database, source);
                RemoveAllFunctionsForDatabase(database, source);
                RemoveAllStoredProceduresForDatabase(database, source);
                RemoveAllFoldersForDatabase(database, source);
        }

        private static void RemoveAllColumnsForDatabase(Database database, ObjectExplorerDataSource source)
        {
            var columnsToRemove = source.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.Column &&
                                                                                  r.GetDatabaseFromNode().Name == database.Name);
            source.RemoveListOfNodes(columnsToRemove);
        }

        private static void RemoveAllTablesForDatabase(Database database, ObjectExplorerDataSource source)
        {
            var tablesToRemove = source.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.Table &&
                                                                                 r.GetDatabaseFromNode().Name == database.Name);
            source.RemoveListOfNodes(tablesToRemove);
        }

        private static void RemoveAllViewsForDatabase(Database database, ObjectExplorerDataSource source)
        {
            var viewsToRemove = source.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.View &&
                                                                                r.GetDatabaseFromNode().Name == database.Name);
            source.RemoveListOfNodes(viewsToRemove);
        }

        private static void RemoveAllFunctionsForDatabase(Database database, ObjectExplorerDataSource source)
        {
            var functionsToRemove = source.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.Function &&
                                                                                    r.GetDatabaseFromNode().Name == database.Name);
            source.RemoveListOfNodes(functionsToRemove);
        }

        private static void RemoveAllStoredProceduresForDatabase(Database database, ObjectExplorerDataSource source)
        {
            var storedProceduresToRemove = source.DataSource.Where(r => r.Type == GlobalStrings.ObjectExplorerTypes.StoredProcedure &&
                                                                                           r.GetDatabaseFromNode().Name == database.Name);
            source.RemoveListOfNodes(storedProceduresToRemove);
        }

        private static void RemoveAllFoldersForDatabase(Database database, ObjectExplorerDataSource source)
        {
            var functionsToRemove = source.DataSource.Where(r => IsFolderForDatabase(r) &&
                                                                                    r.GetDatabaseFromNode().Name == database.Name);
            source.RemoveListOfNodes(functionsToRemove);
        }

        private static bool IsFolderForDatabase(ObjectExplorerNode node)
        {
            if (node.Type != GlobalStrings.ObjectExplorerTypes.Folder) return false;
            return node.DisplayName == GlobalStrings.FolderTypes.FunctionsFolder ||
                   node.DisplayName == GlobalStrings.FolderTypes.StoreProcedureFolder ||
                   node.DisplayName == GlobalStrings.FolderTypes.TableFolder ||
                   node.DisplayName == GlobalStrings.FolderTypes.ViewFolder;
        }

    }

      
}
