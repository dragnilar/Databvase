using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Services;
using Databvase_Winforms.Utilities;
using Databvase_Winforms.View_Models;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.MVVM;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.Utils.Text;

namespace Databvase_Winforms.Modules
{
    public partial class QueryControl : XtraUserControl
    {
        public QueryControl()
        {
            InitializeComponent();
            HookupEvents();
            SetupGridButtons();
            ShowLineNumbers();
            if (!mvvmContextQueryControl.IsDesignMode)
                InitializeBindings();
        }



        public RibbonControl Ribbon => ribbonControlQueryControl;

        private void ShowLineNumbers()
        {
            //We want line numbers on the query editor because they are nice to have... :P
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.RestartType = LineNumberingRestart.Continuous;
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.Start = 1;
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.CountBy = 1;
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.Distance = 0.1f;
        }

        private void HookupEvents()
        {
            SaveQueryButton.ItemClick += SaveQueryButton_ItemClick;
            gridViewResults.CustomColumnDisplayText += GridViewResultsOnCustomColumnDisplayText;
            gridViewResults.RowCellStyle += GridViewResultsOnRowCellStyle;
        }

        private void GridViewResultsOnRowCellStyle(object o, RowCellStyleEventArgs e)
        {
            if (e.CellValue == DBNull.Value)
            {
                e.Appearance.BackColor = Color.Red;
            }
        }

        private void GridViewResultsOnCustomColumnDisplayText(object o, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == DBNull.Value)
            {
                e.DisplayText = "[NULL]";
            }
        }

        private void SaveQueryButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Its probably better to leave this in the view because its using stuff baked into the view.
            richEditControlQueryEditor.SaveDocumentAs();
        }

        private void SetupGridButtons()
        {
            barButtonItemPrintGrid.ItemClick += (sender, args) => gridViewResults.ShowRibbonPrintPreview();
            barButtonItemExportGridToExcel.ItemClick += (sender, args) => ExportGrid("xls");
            barButtonItemExportToXLSX.ItemClick += (sender, args) => ExportGrid("xlsx");
            barButtonItemExportToHTML.ItemClick += (sender, args) => ExportGrid("html");
            barButtonItemExportToMHT.ItemClick += (sender, args) => ExportGrid("mht");
            barButtonItemExportToPDF.ItemClick += (sender, args) => ExportGrid("pdf");
            barButtonItemExportToRTF.ItemClick += (sender, args) => ExportGrid("rtf");
            barButtonItemExportToText.ItemClick += (sender, args) => ExportGrid("txt");
            barButtonItemExportToCSV.ItemClick += (sender, args) => ExportGrid("csv");
        }

        private void ExportGrid(string fileType)
        {
            GridUtilities.ExportGridAsFileType(gridViewResults, fileType);
        }

        public void SetScriptToDatabase(NewScriptMessage message)
        {
            richEditControlQueryEditor.Document.Text = message.Script;
            barEditItemDatabaseList.EditValue = message.SelectedDatabase;
            ShowLineNumbers();
        }

        #region MVVMContext

        private void InitializeBindings()
        {
            //Instantiate fluent API
            var fluent = mvvmContextQueryControl.OfType<QueryControlViewModel>();

            //Register services
            mvvmContextQueryControl.RegisterService(new QueryEditorService(richEditControlQueryEditor));

            SetBindingSourceForQueryEditor(fluent);

            //Event to command
            fluent.EventToCommand<ItemClickEventArgs>(QueryButton, "ItemClick", x => x.AsynchronousQuery());

            //With Key events
            fluent.WithKey(richEditControlQueryEditor, Keys.F5).KeyToCommand(x => x.AsynchronousQuery());

            SetBindingForControls(fluent);

            SetTriggers(fluent);
        }

        private void SetBindingSourceForQueryEditor(MVVMContextFluentAPI<QueryControlViewModel> fluent)
        {
            fluent.SetObjectDataSourceBinding(bindingSourceQueryControl, x => x.Entity, x => x.Update());
            fluent.ViewModel.RaisePropertyChanged(x => x.Entity);
        }

        private void SetBindingForControls(MVVMContextFluentAPI<QueryControlViewModel> fluent)
        {
            fluent.SetBinding(gridControlResults, x => x.DataSource, y => y.GridSource);
            fluent.SetBinding(memoEditResults, x => x.EditValue, y => y.ResultsMessage);
            fluent.SetBinding(repositoryItemLookUpEditDatabaseList, x => x.DataSource, y => y.DatabasesList);
            fluent.SetBinding(barEditItemDatabaseList, x => x.EditValue, y => y.CurrentDatabase);
        }

        private void SetTriggers(MVVMContextFluentAPI<QueryControlViewModel> fluent)
        {
            //Grid clear trigger
            fluent.SetTrigger(x => x.ClearGrid, clear =>
            {
                if (clear) gridViewResults.Columns.Clear();
            });

            fluent.SetTrigger(x => x.QueryRunning, state => { QueryButton.Enabled = !state; });
            fluent.SetTrigger(x => x.AddIndicator, add =>
            {
                if (add)
                {
                    gridViewResults.AddRowNumberColumn();
                }

            });
        }

        #endregion
    }
}