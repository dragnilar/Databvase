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

        #region Grid Management

        private void SetupGrid(int numberOfGrids)
        {
            if (numberOfGrids == 1)
            {
                AddRows(1);
                AddGrid(1, 0);
            }
            else
            {
                AddRowsAndMultipleGrids(numberOfGrids);
            }


        }

        private void ClearGrid()
        {
            foreach (object control in LayoutGrid.Children)
            {
                if (control is WindowsFormsHost host)
                {
                    var grid = host.Child;
                    grid.Dispose();
                }
            }
            LayoutGrid.Children.Clear();
            LayoutGrid.RowDefinitions.Clear();
        }

        private void AddRowsAndMultipleGrids(int numberOfRows)
        {
            AddRows(numberOfRows);

            var gridNumber = 0;

            AddMultipleGrids();
        }

        private void AddRows(int numberOfRows)
        {
            if (numberOfRows > 1)
            {
                numberOfRows = numberOfRows * 2;
            }
            for (int i = 0; i < numberOfRows; i++)
            {
                var row = new RowDefinition();
                row.Name = $"Row{i}";
                row.Height = GridLength.Auto;
                LayoutGrid.RowDefinitions.Add(row);
            }
        }

        private void AddSingleRow(int rowNumber)
        {
            var row = new RowDefinition();
            row.Name = $"Row{rowNumber}";
            row.Height = GridLength.Auto;
            LayoutGrid.RowDefinitions.Add(row);
        }

        private void AddGrid(int gridNumber, int rowNumber)
        {
            var grid = new QueryGridFactory().BuildADockedGrid(gridNumber);
            grid.SetQueryPaneName(QueryPaneName);
            var host = new WindowsFormsHost { Child = grid };
            Grid.SetRow(host, rowNumber);
            LayoutGrid.Children.Add(host);
        }

        private void AddSplitter(int rowNumber)
        {
            var splitter = new GridSplitter
            {
                Name = $"Splitter{rowNumber}",
                Height = 5,
                HorizontalAlignment = HorizontalAlignment.Stretch,


            };
            Grid.SetRow(splitter, rowNumber);
            LayoutGrid.Children.Add(splitter);
        }

        private void AddMultipleGrids()
        {
            var gridNumber = 1;
            for (int i = 0; i < LayoutGrid.RowDefinitions.Count; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                if (i % 2 == 0)
                {

                    AddSplitter(i);
                }
                else
                {
                    AddGrid(gridNumber, i);
                    gridNumber++;
                }


            }

            AddSplitterAfterLastRow(LayoutGrid.RowDefinitions.Count + 1);
        }

        private void AddSplitterAfterLastRow(int i)
        {
            AddSingleRow(LayoutGrid.RowDefinitions.Count + 1);
            AddSplitter(LayoutGrid.RowDefinitions.Count + 1);
        }

        #endregion



    }
}
