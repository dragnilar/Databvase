using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.Messages;
using DevExpress.Mvvm;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using Databvase_Winforms.Factories;
using Databvase_Winforms.Controls.QueryGrid;
using Databvase_Winforms.Dialogs;
using DevExpress.Data.Helpers;

namespace Databvase_Winforms.Controls.DockPanelLayout
{
    public partial class DockLayoutPanel : DevExpress.XtraEditors.XtraUserControl, IGridLayout
    {
        public string QueryPaneName { get; set; }

        public DockLayoutPanel()
        {
            InitializeComponent();
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<QueryGridCreateMessage>(this, typeof(QueryGridCreateMessage).Name,
                OnQueryGridCreateMessage);
        }

        private void OnQueryGridCreateMessage(QueryGridCreateMessage message)
        {
            if (message.QueryPaneName == QueryPaneName)
            {
                dockManagerPanels.Clear();

                for (int i = 0; i < message.NumberOfGrids; i++)
                {
                    AddGridPanels(i);
                }
            }

        }

        #region Panel Management

        private void AddGridPanels(int gridNumber)
        {
            var gridControl = new QueryGridFactory().BuildADockedGrid(gridNumber);
            gridControl.SetQueryPaneName(QueryPaneName);
            var panel = dockManagerPanels.AddPanel(DockingStyle.Top);
            panel.Text = $"Results Set {gridNumber}";
            panel.Controls.Add(gridControl);
        }

        #endregion

        #region Printing And Exporting


        public void PrintQueryResultGrids()
        {
            if (dockManagerPanels.Panels.Count == 1)
            {
                PrintSingleGrid();
            }
            else
            {
                PrintMultipleGrids();
            }
        }

        private void PrintSingleGrid()
        {
            var control = dockManagerPanels.Panels[0].Controls[0];
            if (control is QueryGridControl grid)
            {
                var gridView = grid.DefaultView as QueryGridView;
                gridView?.ShowRibbonPrintPreview();
            }
        }

        private void PrintMultipleGrids()
        {
            var gridNamesList = GetListOfGridNames();

            if (gridNamesList.Count <= 0) return;
            {
                var printDialog =
                    new DocumentPrintExportDialog(gridNamesList)
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                printDialog.ShowDialog();
                var selectedGrid = printDialog.SelectedDocumentName;
                printDialog.Dispose();
                PrintSelectedGrid(selectedGrid);
            }
        }

        private void PrintSelectedGrid(string selectedGrid)
        {
            var control = GetControlFromPanelsWithName(selectedGrid);
            if (control == null) return;
            if ((!(control is QueryGridControl grid))) return;
            var gridView = grid.DefaultView as QueryGridView;
            gridView?.ShowRibbonPrintPreview();
        }

        public void ExportQueryResultsGrids(string fileExtension)
        {
            if (dockManagerPanels.Panels.Count == 1)
            {
                ExportSingleGrid(fileExtension);
            }
            else
            {
                ExportMultipleGrids(fileExtension);
            }
        }

        private void ExportSingleGrid(string fileExtension)
        {
            var control = dockManagerPanels.Panels[0].Controls[0];
            if (control is QueryGridControl grid)
            {
                var gridView = grid.DefaultView as QueryGridView;
                gridView?.ExportGridAsFileType(fileExtension);
            }
        }

        private void ExportMultipleGrids(string fileExtension)
        {
            var gridNamesList = GetListOfGridNames();

            if (gridNamesList.Count <= 0) return;
            {
                var printDialog =
                    new DocumentPrintExportDialog(gridNamesList, fileExtension)
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                printDialog.ShowDialog();
                var selectedGrid = printDialog.SelectedDocumentName;
                printDialog.Dispose();
                ExportSelectedGrid(selectedGrid, fileExtension);
            }
        }

        private void ExportSelectedGrid(string selectedGrid, string fileExtension)
        {
            var control = GetControlFromPanelsWithName(selectedGrid);
            if (control == null) return;
            if ((!(control is QueryGridControl grid))) return;
            var gridView = grid.DefaultView as QueryGridView;
            gridView?.ExportGridAsFileType(fileExtension);
        }

        private List<string> GetListOfGridNames()
        {
            var gridNamesList = new List<string>();
            var controlContainers = dockManagerPanels.Panels.Select(x => x.Controls[0]).ToList();
            foreach (var controlContainer in controlContainers)
            {
                foreach (var control in controlContainer.Controls)
                {
                    if (!(control is QueryGridControl grid)) continue;
                    gridNamesList.Add(grid.Name);
                }

            }

            return gridNamesList;
        }

        private Control GetControlFromPanelsWithName(string controlName)
        {
            var controlContainers = dockManagerPanels.Panels.SelectMany(x => x.Controls.Cast<ControlContainer>());

            return controlContainers.SelectMany(container => container.Controls.Cast<Control>()).FirstOrDefault(control => control.Name == controlName);
        }

        #endregion

    }
}
