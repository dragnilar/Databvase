using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Databvase_Winforms.Utilities
{
    public static class GridUtilities
    {
        public static string GetExportFileName(string extension, string filter)
        {
            var fileName = GetFileNameViaSavePrompt($"*.{extension}", filter);
            return string.IsNullOrEmpty(fileName) ? null : fileName;
        }



        public static void ExportGridAsFileType(GridView gridView, string fileType)
        {
            try
            {
                switch (fileType)
                {
                    case "pdf":
                        ExportGridAsPdf(gridView, fileType);
                        break;
                    case "xls":
                        ExportGridAsXls(gridView, fileType);
                        break;
                    case "xlsx":
                        ExportGridAsXlsx(gridView, fileType);
                        break;
                    case "rtf":
                        ExportGridAsRtf(gridView, fileType);
                        break;
                    case "txt":
                        ExportGridAsTxt(gridView, fileType);
                        break;
                    case "html":
                        ExportGridAsHtml(gridView, fileType);
                        break;
                    case "mht":
                        ExportGridAsMht(gridView, fileType);
                        break;
                    case "csv":
                        ExportGridAsCsv(gridView, fileType);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Error occured during export: \n" + e.Message);
            }

        }



        private static void ExportGridAsPdf(GridView gridView, string fileType)
        {
            var exportFileName = GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.PDFFilter);
            if (!string.IsNullOrEmpty(exportFileName))
            {
                gridView.ExportToPdf(exportFileName);
            }
        }

        public static string GetFileNameViaSavePrompt(string extension, string filters)
        {
            using (var dialog = new XtraSaveFileDialog())
            {
                dialog.Filter = filters;
                dialog.DefaultExt = extension;
                return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : string.Empty;
            }
        }

        private static void ExportGridAsXls(GridView gridView, string fileType)
        {
            var exportFileName = GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.XLSFilter);
            if (!string.IsNullOrEmpty(exportFileName))
            {
                gridView.ExportToXls(exportFileName);
            }
        }

        private static void ExportGridAsXlsx(GridView gridView, string fileType)
        {
            var exportFileName = GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.XLSXFilter);
            if (!string.IsNullOrEmpty(exportFileName))
            {
                gridView.ExportToXlsx(exportFileName);
            }
        }

        private static void ExportGridAsRtf(GridView gridView, string fileType)
        {
            var exportFileName = GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.RTFFilter);
            if (!string.IsNullOrEmpty(exportFileName))
            {
                gridView.ExportToRtf(exportFileName);
            }
        }

        private static void ExportGridAsTxt(GridView gridView, string fileType)
        {
            var exportFileName = GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.TXTFilter);
            if (!string.IsNullOrEmpty(exportFileName))
            {
                gridView.ExportToText(exportFileName);
            }
        }

        private static void ExportGridAsHtml(GridView gridView, string fileType)
        {
            var exportFileName = GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.HTMLFilter);
            if (!string.IsNullOrEmpty(exportFileName))
            {
                gridView.ExportToHtml(exportFileName);
            }
        }

        private static void ExportGridAsMht(GridView gridView, string fileType)
        {
            var exportFileName = GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.MHTFilter);
            if (!string.IsNullOrEmpty(exportFileName))
            {
                gridView.ExportToMht(exportFileName);
            }
        }

        private static void ExportGridAsCsv(GridView gridView, string fileType)
        {
            var exportFileName = GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.CSVFILTER);
            if (!string.IsNullOrEmpty(exportFileName))
            {
                gridView.ExportToCsv(exportFileName);
            }
        }
    }
}