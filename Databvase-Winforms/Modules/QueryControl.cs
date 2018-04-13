using System.Windows.Forms;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Services;
using Databvase_Winforms.Utilities;
using Databvase_Winforms.View_Models;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Native;

namespace Databvase_Winforms.Modules
{
    public partial class QueryControl : XtraUserControl
    {
        public QueryControl()
        {
            InitializeComponent();
            SetupQueryEditor();
            SetupGridButtons();
            if (!mvvmContextQueryControl.IsDesignMode)
                InitializeBindings();
        }

        public RibbonControl Ribbon => ribbonControlQueryControl;


        private void SetupQueryEditor()
        {
            //We want line numbers on the query editor because they are nice to have... :P
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.RestartType = LineNumberingRestart.Continuous;
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.Start = 1;
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.CountBy = 1;
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.Distance = 0.1f;
            SaveQueryButton.ItemClick += SaveQueryButton_ItemClick;
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
        }

        private void ExportGrid(string fileType)
        {
            switch (fileType)
            {
                case "pdf":
                    gridViewResults.ExportToPdf(GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.PDFFilter));
                    break;
                case "xls":
                    gridViewResults.ExportToXls(GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.XLSFilter));
                    break;
                case "xlsx":
                    gridViewResults.ExportToXlsx(GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.XLSXFilter));
                    break;
                case "rtf":
                    gridViewResults.ExportToRtf(GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.RTFFilter));
                    break;
                case "txt":
                    gridViewResults.ExportToText(GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.TXTFilter));
                    break;
                case "html":
                    gridViewResults.ExportToHtml(GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.HTMLFilter));
                    break;
                case "mht":
                    gridViewResults.ExportToMht(GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.MHTFilter));
                    break;
                case "csv":
                    gridViewResults.ExportToCsv(GridUtilities.GetFileNameViaSavePrompt(fileType, Globals.GlobalStrings.CSVFILTER));
                    break;
                default:
                    break;
            }
        }

        public void SetScriptToDatabase(NewScriptMessage message)
        {
            richEditControlQueryEditor.Text = message.Script;
            barEditItemDatabaseList.EditValue = message.SelectedDatabase;
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
        }

        #endregion
    }
}