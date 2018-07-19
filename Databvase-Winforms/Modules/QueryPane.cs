using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Databvase_Winforms.Controls;
using Databvase_Winforms.Controls.DockPanelLayout;
using Databvase_Winforms.Controls.QueryGrid;
using Databvase_Winforms.Controls.WPFGridLayout;
using Databvase_Winforms.Factories;
using Databvase_Winforms.Globals;
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
        private IGridLayout _currentGridLayout;

        public QueryPane()
        {
            InitializeComponent();
            HookupEvents();
            SetupGridButtons();
            if (!mvvmContextQueryControl.IsDesignMode)
                mvvmContextQueryControl.ViewModelSet += MvvmContextQueryControlOnViewModelSet;
            MVVMContext.RegisterXtraMessageBoxService();
            ApplyGridLayout();
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
            _currentGridLayout.PrintQueryResultGrids();
        }
        private void ExportGrid(string fileTypeExtension)
        {
            _currentGridLayout.ExportQueryResultsGrids(fileTypeExtension);
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

        private void ApplyGridLayout()
        {
            switch (App.Config.GridLayoutTypePreference)
            {
                case GlobalEnumerations.GridLayoutType.Wpf:
                    SetupWpfGridLayout();
                    break;
                case GlobalEnumerations.GridLayoutType.DockPanel:
                    SetupDockPanelLayout();
                    break;
                default:
                    SetupWpfGridLayout(); //Default to Wpf Grid Layout for now...
                    break;
            }
        }

        private void SetupWpfGridLayout()
        {
            var wpfGridLayout = new WPFGridLayoutPanel();
            _currentGridLayout = wpfGridLayout;
            var elementHostWpfGridLayoutPanel = new ElementHost
            {
                Dock = DockStyle.Fill,
                Child = wpfGridLayout
            };
            xtraTabPageResultsGrid.Controls.Add(elementHostWpfGridLayoutPanel);
        }

        private void SetupDockPanelLayout()
        {
            var xtraScrollableControl = new XtraScrollableControl();
            xtraScrollableControl.Dock = DockStyle.Fill;
            var dockLayoutPanel = new DockLayoutPanel {Dock = DockStyle.Fill, AutoScroll = true};
            _currentGridLayout = dockLayoutPanel;
            xtraScrollableControl.Controls.Add(dockLayoutPanel);
            xtraTabPageResultsGrid.Controls.Add(xtraScrollableControl);

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

            _currentGridLayout.QueryPaneName =
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