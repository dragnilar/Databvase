using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Globals
{
    public static class GlobalStrings
    {
        public static class FileFilters
        {
            public const string PDFFilter = "PDF Document (*.pdf)|*.pdf";
            public const string XLSFilter = "XLS File (*.XLS)|*.XLS";
            public const string XLSXFilter = "XLSX File (*.XLSX)|*.XLSX";
            public const string MHTFilter = "MHT File (*.MHT)|*.MHT";
            public const string RTFFilter = "RTF File (*.RTF)|*.RTF";
            public const string TXTFilter = "TXT File (*.TXT)|*.TXT";
            public const string HTMLFilter = "HTML File (*.HTML)|*.HTML";
            public const string CSVFILTER = "CSV FILE (*.CSV)|CSV";
        }

        public static class ObjectExplorerTypes
        {
            public const string Instance = "Instance";
            public const string Database = "Database";
            public const string Table = "Table";
            public const string Column = "Column";
            public const string Folder = "Folder";
            public const string View = "View";
            public const string StoredProcedure = "StoredProcedure";
            public const string Function = "Function";
            public const string Nothing = "Nothing";
        }

        public static class FolderTypes
        {
            public const string TableFolder = "Tables";
            public const string ViewFolder = "Views";
            public const string StoreProcedureFolder = "Stored Procedures";
            public const string FunctionsFolder = "Functions";
        }


    }
}
