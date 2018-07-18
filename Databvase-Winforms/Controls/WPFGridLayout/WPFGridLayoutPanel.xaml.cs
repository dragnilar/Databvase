using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Databvase_Winforms.Factories;
using System.Windows.Forms.Integration;
using Databvase_Winforms.Controls.QueryGrid;
using Databvase_Winforms.Messages;
using DevExpress.Mvvm;

namespace Databvase_Winforms.Controls.WPFGridLayout
{
    /// <summary>
    /// Interaction logic for WPFGridLayoutPanel.xaml
    /// </summary>
    public partial class WPFGridLayoutPanel : UserControl
    {
        public string QueryPaneName { get; set; }
        /// <summary>
        /// A layout panel that uses the WPF Grid to display DevExpress QueryGrids in a tabular fashion. Multiple grids are separated by splitters.
        /// </summary>
        public WPFGridLayoutPanel()
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
                if (LayoutGrid.Children.Count > 0)
                {
                    ClearGrid();
                }

                SetupGrid(message.NumberOfGrids);
            }

        }


        #region Printing And Exporting

        public void PrintGrid()
        {
            if (LayoutGrid.Children.Count == 1)
            {
                PrintSingleGrid();
            }

            else
            {
                //TODO - Implement printing multiple grids...
            }
        }

        private void PrintSingleGrid()
        {
            //TODO - This is duplicate code, possibly could be refactored
            var element = LayoutGrid.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 0);
            if (!(element is WindowsFormsHost host)) return;
            var control = host.Child;
            if (control is QueryGridControl grid)
            {
                var gridView = grid.DefaultView as QueryGridView;
                gridView?.ShowRibbonPrintPreview();
            }
        }

        public void ExportGrid(string fileExtension)
        {

            if (LayoutGrid.Children.Count == 1)
            {
                ExportSingleGrid(fileExtension);
            }
            else
            {
                //TODO - Implement exporting multiple grids...
            }

        }

        private void ExportSingleGrid(string fileExtension)
        {
            //TODO - This is duplicate code, possibly could be refactored
            var element = LayoutGrid.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 0);
            if (!(element is WindowsFormsHost host)) return;
            var control = host.Child;
            if (control is QueryGridControl grid)
            {
                var gridView = grid.DefaultView as QueryGridView;
                gridView?.ExportGridAsFileType(fileExtension);
            }
        }

        #endregion

        #region Grid Management

        /// <summary>
        /// Sets up the WPF grid for either single grid or multi grid mode. If the number of grids is greater than 1, it uses multi grid mode.
        /// Otherwise it uses single grid mode.
        /// </summary>
        /// <param name="numberOfGrids"></param>
        private void SetupGrid(int numberOfGrids)
        {
            if (numberOfGrids == 1)
            {
                AddRows(1);
                AddQueryGridControl(0);
            }
            else
            {
                AddRowsAndMultipleQueryGrids(numberOfGrids);
            }


        }

        /// <summary>
        /// Clears the WPF grid of all elements and Windows Forms controls. The Windows Forms controls are explicitly disposed.
        /// </summary>
        private void ClearGrid()
        {
            foreach (var control in LayoutGrid.Children)
            {
                if (!(control is WindowsFormsHost host)) continue;
                var grid = host.Child;
                grid.Dispose();
            }
            LayoutGrid.Children.Clear();
            LayoutGrid.RowDefinitions.Clear();
        }

        /// <summary>
        /// Adds the specified number of rows to the WPF grid and then proceeds to run through the add multiple results grids routine.
        /// The number of grids is determined by the number of rows created on the WPF grid.
        /// </summary>
        /// <param name="numberOfRows"></param>
        private void AddRowsAndMultipleQueryGrids(int numberOfRows)
        {
            AddRows(numberOfRows);

            AddMultipleQueryGrids(numberOfRows);
        }

        /// <summary>
        /// Adds rows to the WPF Grid. If there is more than 1 row, the grids are added using the multiple rows method.
        /// Otherwise we use single grid. The major difference between the two is the height property for the row definition.
        /// </summary>
        /// <param name="numberOfRows"></param>
        private void AddRows(int numberOfRows)
        {

            if (numberOfRows > 1)
            {
                numberOfRows = numberOfRows + 1; //We have to add a third row as an empty space so that the bottom splitter can expand.
                for (int i = 0; i < numberOfRows; i++)
                {
                    AddRowDefinitionForMultipleRows(i);
                }
            }
            else
            {
                AddSingleRow();
            }
        }

        /// <summary>
        /// This is the add multiple query grid routine. The number of rows passed in is the number of query grids created.
        /// </summary>
        private void AddMultipleQueryGrids(int numberOfRows)
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                AddQueryGridControl(i);
                AddSplitterToGrid(i);
            }
        }

        /// <summary>
        /// Adds multiple rows to the grid. These rows have their height property set to GridLength.Auto to ensure that
        /// all of the Query Grid controls are sized properly.
        /// </summary>
        /// <param name="rowNumber"></param>
        private void AddRowDefinitionForMultipleRows(int rowNumber)
        {
            var row = new RowDefinition
            {
                Name = $"Row{rowNumber}",
                Height = GridLength.Auto
            };
            LayoutGrid.RowDefinitions.Add(row);
        }

        /// <summary>
        /// Adds a single row to the grid. This should only be used when query grid is being shown because these grids will
        /// display the grids at their maximum size.
        /// </summary>
        private void AddSingleRow()
        {
            var row = new RowDefinition {Name = $"Row{0}"};
            LayoutGrid.RowDefinitions.Add(row);
        }

        /// <summary>
        /// Adds a Query Grid Control to the WPF Grid. The row number passed in determine which row to place the query grid control.
        /// </summary>
        /// <param name="rowNumber"></param>
        private void AddQueryGridControl(int rowNumber)
        {
            var grid = new QueryGridFactory().BuildADockedGrid(rowNumber);
            grid.SetQueryPaneName(QueryPaneName); //NOTE - This is being used as a work around since the DX Windows Forms MVVM Framework does not seem to play nice with WPF.
            var host = new WindowsFormsHost { Child = grid };
            Grid.SetRow(host, rowNumber);
            var margin = host.Margin;
            margin.Bottom = 5;
            host.Margin = margin;
            LayoutGrid.Children.Add(host);
        }

        /// <summary>
        /// Adds a splitter control to the specified grid row. The splitter control will always have its Z Index set to 1 so that
        /// it displays on the bottom of the Windows Forms control residing inside the grid row.
        /// </summary>
        /// <param name="rowNumber"></param>
        private void AddSplitterToGrid(int rowNumber)
        {
            var splitter = new GridSplitter
            {
                Name = $"Splitter{rowNumber}",
                Height = 5,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Bottom


            };
            LayoutGrid.Children.Add(splitter);
            Grid.SetRow(splitter, rowNumber);
            Panel.SetZIndex(splitter, 1);

        }

        #endregion



    }
}
