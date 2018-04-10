using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Databvase_Winforms.Utilities
{
    public static class GridUtilities
    {
        public static string GetExportFileName(string extension, string filter)
        {
            var fileName = GetFileNameViaSavePrompt($"*.{extension}", filter);
            return string.IsNullOrEmpty(fileName) ? null : fileName;
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
    }
}