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
            queryTextEditor.SaveDocumentAs();
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

        #region MVVMContext

        private void MvvmContextQueryControlOnViewModelSet(object sender, ViewModelSetEventArgs e)
        {
            //Instantiate fluent API
            var fluent = mvvmContextQueryControl.OfType<QueryControlViewModel>();

            //Register services
            mvvmContextQueryControl.RegisterService(new QueryEditorService(queryTextEditor));

            //Set binding source for the query editor
            SetBindingSourceForQueryEditor(fluent);

            //Event to command
            fluent.EventToCommand<ItemClickEventArgs>(QueryButton, "ItemClick", x => x.AsynchronousQuery());

            //With Key events
            fluent.WithKey(queryTextEditor, Keys.F5).KeyToCommand(x => x.AsynchronousQuery());

            SetBindingForControls(fluent);

            SetTriggers(fluent);

            //Bind commands
            fluent.BindCommand(barButtonItemCopy, x => x.CopyFromQueryTextEditor());
            fluent.BindCommand(barButtonItemCut, x => x.CutFromQueryTextEditor());
            fluent.BindCommand(barButtonItemPaste, x => x.PasteIntoQueryTextEditor());
        }

        private void SetBindingSourceForQueryEditor(MVVMContextFluentAPI<QueryControlViewModel> fluent)
        {
            var bindingSourceQueryControl = new BindingSource();
            queryTextEditor.DataBindings.Add("Text", bindingSourceQueryControl, "DocumentText", false,
                DataSourceUpdateMode.OnPropertyChanged);
            fluent.SetObjectDataSourceBinding(bindingSourceQueryControl, x => x.Entity, x => x.Update());
            fluent.ViewModel.RaisePropertyChanged(x => x.Entity);
        }

        private void SetBindingForControls(MVVMContextFluentAPI<QueryControlViewModel> fluent)
        {
            fluent.SetBinding(gridControlResults, x => x.DataSource, y => y.GridSource);
            fluent.SetBinding(memoEditResults, x => x.EditValue, y => y.ResultsMessage);
            fluent.SetBinding(repositoryItemLookUpEditDatabaseList, x => x.DataSource, y => y.DatabasesList);
            fluent.SetBinding(barEditItemDatabaseList, x => x.EditValue, y => y.CurrentDatabase);
            fluent.SetBinding(queryTextEditor.Appearance.Text, x => x.Font, vm => vm.DefaultTextEditorFont);

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