using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Databvase_Winforms.Controls.QueryGrid;
using Databvase_Winforms.Factories;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Services;
using Databvase_Winforms.View_Models;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils;
using DevExpress.Utils.CommonDialogs;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.Utils.Text;

namespace Databvase_Winforms.Modules
{
    public partial class QueryPane : XtraUserControl
    {
        public QueryPane()
        {
            InitializeComponent();
            HookupEvents();
            SetupGridButtons();
            if (!mvvmContextQueryControl.IsDesignMode)
                mvvmContextQueryControl.ViewModelSet += MvvmContextQueryControlOnViewModelSet;
            MVVMContext.RegisterXtraMessageBoxService();
        }


        public RibbonControl Ribbon => ribbonControlQueryControl;

        private void HookupEvents()
        {
            barButtonItemCopy.ItemClick += (s, e) => scintilla.Copy();
            barButtonItemPaste.ItemClick += (s, e) => scintilla.Paste();
            barButtonItemCut.ItemClick += (s, e) => scintilla.Cut();
            scintilla.KeyDown += ScintillaOnKeyDown;
            scintilla.MouseClick += ScintillaOnMouseClick;
            ribbonControlQueryControl.Manager.UseAltKeyForMenu = false;
        }

        private void ScintillaOnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenuScintilla.ShowPopup(MousePosition);
            }
        }

        private void ScintillaOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                mvvmContextQueryControl.GetViewModel<QueryPaneViewModel>().AsynchronousQuery(scintilla.GetSqlQueryFromQueryPane());
            }
        }

        private void SetupGridButtons()
        {
            barButtonItemPrintGrid.ItemClick += (sender, args) => PrintGrid();
            barButtonItemExportGridToExcel.ItemClick += (sender, args) => ExportGrid("xls");
            barButtonItemExportToXLSX.ItemClick += (sender, args) => ExportGrid("xlsx");
            barButtonItemExportToHTML.ItemClick += (sender, args) => ExportGrid("html");
            barButtonItemExportToMHT.ItemClick += (sender, args) => ExportGrid("mht");
            barButtonItemExportToPDF.ItemClick += (sender, args) => ExportGrid("pdf");
            barButtonItemExportToRTF.ItemClick += (sender, args) => ExportGrid("rtf");
            barButtonItemExportToText.ItemClick += (sender, args) => ExportGrid("txt");
            barButtonItemExportToCSV.ItemClick += (sender, args) => ExportGrid("csv");
        }

        private void PrintGrid()
        {
            wpfGridLayoutPanelQueryControl.PrintGrid();
        }
        private void ExportGrid(string fileTypeExtension)
        {
            wpfGridLayoutPanelQueryControl.ExportGrid(fileTypeExtension);
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
                scintilla.Text += message.Script;
                barEditItemDatabaseList.EditValue = message.SelectedDatabase;
            }

        }

        #region MVVMContext

        private void MvvmContextQueryControlOnViewModelSet(object sender, ViewModelSetEventArgs e)
        {
            //Instantiate fluent API
            var fluent = mvvmContextQueryControl.OfType<QueryPaneViewModel>();

            //Register services
            mvvmContextQueryControl.RegisterService(new QueryEditorService());

            //Event to command
            fluent.EventToCommand<ItemClickEventArgs>(QueryButton, "ItemClick", x => x.AsynchronousQuery(string.Empty), 
                args=> scintilla.GetSqlQueryFromQueryPane());


            SetBindingForControls(fluent);

            SetTriggers(fluent);

            fluent.EventToCommand<ItemClickEventArgs>(SaveQueryButton, "ItemClick", x=>x.SaveCurrentQuery(string.Empty), args => scintilla.Text);

            wpfGridLayoutPanelQueryControl.QueryPaneName =
                mvvmContextQueryControl.GetViewModel<QueryPaneViewModel>().QueryPaneName;

        }

        private void SetBindingForControls(MVVMContextFluentAPI<QueryPaneViewModel> fluent)
        {
            fluent.SetBinding(memoEditResults, x => x.EditValue, y => y.ResultsMessage);
            fluent.SetBinding(repositoryItemLookUpEditDatabaseList, x => x.DataSource, y => y.DatabasesList);
            fluent.SetBinding(barEditItemDatabaseList, x => x.EditValue, y => y.CurrentDatabase);

        }

        private void SetTriggers(MVVMContextFluentAPI<QueryPaneViewModel> fluent)
        {

            fluent.SetTrigger(x => x.ControlState, state =>
            {
                switch (state)
                {
                    case QueryPaneViewModel.QueryResultState.ShowGrid:
                        xtraTabControlResultsPane.SelectedTabPage = xtraTabPageResultsGrid;
                        break;
                    case QueryPaneViewModel.QueryResultState.ShowMessages:
                        xtraTabControlResultsPane.SelectedTabPage = xtraTabPageMessages;
                        break;
                    case QueryPaneViewModel.QueryResultState.Default:
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