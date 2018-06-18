using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Databvase_Winforms.Controls.QueryGrid;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Services;
using Databvase_Winforms.View_Models;
using DevExpress.Mvvm;
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
            if (!mvvmContextQueryControl.IsDesignMode)
                mvvmContextQueryControl.ViewModelSet += MvvmContextQueryControlOnViewModelSet;
        }




        public RibbonControl Ribbon => ribbonControlQueryControl;

        private void HookupEvents()
        {
            SaveQueryButton.ItemClick += SaveQueryButton_ItemClick;
            gridViewResults.PopupMenuShowing += GridViewResultsOnPopupMenuShowing;
            barButtonCopyCells.ItemClick += (sender, args) => gridViewResults.CopyToClipboard();
            barButtonItemSelectAll.ItemClick += (sender, args) => gridViewResults.SelectAll();
            barButtonItemCopy.ItemClick += (s, e) => queryTextEditor.Copy();
            barButtonItemPaste.ItemClick += (s, e) => queryTextEditor.Paste();
            barButtonItemCut.ItemClick += (s, e) => queryTextEditor.Cut();
            queryTextEditor.KeyDown += QueryTextEditorOnKeyDown;

        }

        private void QueryTextEditorOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                mvvmContextQueryControl.GetViewModel<QueryControlViewModel>().AsynchronousQuery(queryTextEditor.GetSqlQueryFromQueryPane());
            }
        }

        private void GridViewResultsOnPopupMenuShowing(object o, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row )
            {
                popupMenuQueryGrid.ShowPopup(MousePosition);
            }
        }

        private void SaveQueryButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Its probably better to leave this in the view because its using stuff baked into the view.
            //queryTextEditor.
        }

        private void SetupGridButtons()
        {
            barButtonItemPrintGrid.ItemClick += (sender, args) => gridViewResults.ShowRibbonPrintPreview();
            barButtonItemExportGridToExcel.ItemClick += (sender, args) => gridViewResults.ExportGridAsFileType("xls");
            barButtonItemExportToXLSX.ItemClick += (sender, args) => gridViewResults.ExportGridAsFileType("xlsx");
            barButtonItemExportToHTML.ItemClick += (sender, args) => gridViewResults.ExportGridAsFileType("html");
            barButtonItemExportToMHT.ItemClick += (sender, args) => gridViewResults.ExportGridAsFileType("mht");
            barButtonItemExportToPDF.ItemClick += (sender, args) => gridViewResults.ExportGridAsFileType("pdf");
            barButtonItemExportToRTF.ItemClick += (sender, args) => gridViewResults.ExportGridAsFileType("rtf");
            barButtonItemExportToText.ItemClick += (sender, args) => gridViewResults.ExportGridAsFileType("txt");
            barButtonItemExportToCSV.ItemClick += (sender, args) => gridViewResults.ExportGridAsFileType("csv");
        }

        /// <summary>
        /// Appends the text on the query text editor entity's document text with a new document message's text. Also changes the currently database
        /// value (if one is included in the message).
        /// </summary>
        /// <param name="message"></param>
        public void ReceiveNewScriptMessageAndSetScriptText(NewScriptMessage message)
        {
            if (message != null)
            {
                queryTextEditor.Text += message.Script;
                barEditItemDatabaseList.EditValue = message.SelectedDatabase;
            }

        }

        #region MVVMContext

        private void MvvmContextQueryControlOnViewModelSet(object sender, ViewModelSetEventArgs e)
        {
            //Instantiate fluent API
            var fluent = mvvmContextQueryControl.OfType<QueryControlViewModel>();

            //Register services
            mvvmContextQueryControl.RegisterService(new QueryEditorService());

            //Event to command
            fluent.EventToCommand<ItemClickEventArgs>(QueryButton, "ItemClick", x => x.AsynchronousQuery(string.Empty), 
                args=> queryTextEditor.GetSqlQueryFromQueryPane());


            SetBindingForControls(fluent);

            SetTriggers(fluent);

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

            fluent.SetTrigger(x => x.ControlState, state =>
            {
                switch (state)
                {
                    case QueryControlViewModel.QueryResultState.ShowGrid:
                        xtraTabControlResultsPane.SelectedTabPage = xtraTabPageResultsGrid;
                        break;
                    case QueryControlViewModel.QueryResultState.ShowMessages:
                        xtraTabControlResultsPane.SelectedTabPage = xtraTabPageMessages;
                        break;
                    case QueryControlViewModel.QueryResultState.Default:
                        xtraTabControlResultsPane.SelectedTabPage = xtraTabPageResultsGrid; //For now just default to the grid
                        break;
                    default:
                        break;
                }
            });


        }


        #endregion
    }
}