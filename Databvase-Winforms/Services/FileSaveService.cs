using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Databvase_Winforms.Services
{

    internal class FileSaveService
    {

        public async void SaveQueryDialogAsync(string content)
        {
            var dialog = new XtraSaveFileDialog
            {
                Filter = "SQL Files (*.sql)|*.sql|Text Files(*.txt)|*.txt",
                Title = "Save Query As "
            };

            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                await Task.Run(() => SaveQueryFile(dialog.FileName, content))
                    .ContinueWith(x => ShowFileSaveSuccess(x.Result, dialog.FileName), TaskScheduler.FromCurrentSynchronizationContext()).ConfigureAwait(false);
            }
        }
        private bool SaveQueryFile(string filePath, string content)
        {
            try
            { 
                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteAsync(content).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing file" + e);
                return false;
            }

            return true;
        }

        private void ShowFileSaveSuccess(bool success, string fileName)
        {
            if (success)
            {
                XtraMessageBox.Show($"{fileName} has been saved successfully", "Query Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }
    }
}
