using System;
using System.Windows.Forms;
using Databvase_Winforms.Globals;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Databvase_Winforms.Controls.QueryGrid
{
    public static class GridExtensions
    {
        public static string GetExportFileName(string extension, string filter)
        {
            var fileName = GetFileNameViaSavePrompt($"*.{extension}", filter);
            return string.IsNullOrEmpty(fileName) ? null : fileName;
        }


        public static void ExportGridAsFileType(this GridView gridView, string fileType)
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


        private static void ExportGridAsPdf(this BaseView gridView, string fileType)
        {
            var exportFileName = GetFileNameViaSavePrompt(fileType, GlobalStrings.PDFFilter);
            if (!string.IsNullOrEmpty(exportFileName)) gridView.ExportToPdf(exportFileName);
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

        private static void ExportGridAsXls(this BaseView gridView, string fileType)
        {
            var exportFileName = GetFileNameViaSavePrompt(fileType, GlobalStrings.XLSFilter);
            if (!string.IsNullOrEmpty(exportFileName)) gridView.ExportToXls(exportFileName);
        }

        private static void ExportGridAsXlsx(this BaseView gridView, string fileType)
        {
            var exportFileName = GetFileNameViaSavePrompt(fileType, GlobalStrings.XLSXFilter);
            if (!string.IsNullOrEmpty(exportFileName)) gridView.ExportToXlsx(exportFileName);
        }

        private static void ExportGridAsRtf(this BaseView gridView, string fileType)
        {
            var exportFileName = GetFileNameViaSavePrompt(fileType, GlobalStrings.RTFFilter);
            if (!string.IsNullOrEmpty(exportFileName)) gridView.ExportToRtf(exportFileName);
        }

        private static void ExportGridAsTxt(this BaseView gridView, string fileType)
        {
            var exportFileName = GetFileNameViaSavePrompt(fileType, GlobalStrings.TXTFilter);
            if (!string.IsNullOrEmpty(exportFileName)) gridView.ExportToText(exportFileName);
        }

        private static void ExportGridAsHtml(this BaseView gridView, string fileType)
        {
            var exportFileName = GetFileNameViaSavePrompt(fileType, GlobalStrings.HTMLFilter);
            if (!string.IsNullOrEmpty(exportFileName)) gridView.ExportToHtml(exportFileName);
        }

        private static void ExportGridAsMht(this BaseView gridView, string fileType)
        {
            var exportFileName = GetFileNameViaSavePrompt(fileType, GlobalStrings.MHTFilter);
            if (!string.IsNullOrEmpty(exportFileName)) gridView.ExportToMht(exportFileName);
        }

        private static void ExportGridAsCsv(this BaseView gridView, string fileType)
        {
            var exportFileName = GetFileNameViaSavePrompt(fileType, GlobalStrings.CSVFILTER);
            if (!string.IsNullOrEmpty(exportFileName)) gridView.ExportToCsv(exportFileName);
        }
    }
}