using System;
using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Databvase_Winforms.Dialogs
{
    //TODO - This dialog could probably be refactored so that it is using a view model...
    public sealed partial class DocumentPrintExportDialog : XtraForm
    {
        public string SelectedDocumentName = string.Empty;

        private DocumentPrintExportDialog()
        {
            InitializeComponent();
            HookUpEvents();
        }

        /// <summary>
        ///     Displays a dialog that allows the user to select a grid to print.
        /// </summary>
        /// <param name="documentList"></param>
        public DocumentPrintExportDialog(List<string> documentList) : this()
        {
            gridControlPrintExport.DataSource = documentList;
            Text = "Select A Document To Print";
            simpleButtonOK.Text = "Print";
        }

        /// <summary>
        ///     Displays a dialog that allows the user to select a grid to export via the selected file type.
        /// </summary>
        /// <param name="documentList"></param>
        /// <param name="exportType"></param>
        public DocumentPrintExportDialog(List<string> documentList, string exportType) : this()
        {
            gridControlPrintExport.DataSource = documentList;
            Text = "Select A Document To Export";
            simpleButtonCancel.Text = $"Export to {exportType}";
        }

        private void HookUpEvents()
        {
            simpleButtonOK.Click += SimpleButtonOkOnClick;
            simpleButtonCancel.Click += (sender, args) => Close();
            gridViewPrintExport.DoubleClick += GridViewPrintExportOnDoubleClick;
        }


        private void SimpleButtonOkOnClick(object sender, EventArgs e)
        {
            SelectDocumentAndClose();
        }

        private void SelectDocumentAndClose()
        {
            var selectedRow = gridViewPrintExport.GetFocusedRow();
            SelectedDocumentName = selectedRow.ToString();
            Close();
        }

        private void GridViewPrintExportOnDoubleClick(object sender, EventArgs e)
        {
            var eventArgs = e as DXMouseEventArgs;
            var view = sender as GridView;
            if (eventArgs != null)
            {
                var info = view.CalcHitInfo(eventArgs.Location);
                if (!info.InRow && !info.InRowCell) return;
            }

            if (!(sender is GridView gridView)) return;
            gridView.SelectRow(gridView.FocusedRowHandle);
            DXMouseEventArgs.GetMouseArgs(gridView.GridControl, e).Handled = true;
            SelectDocumentAndClose();

        }
    }
}