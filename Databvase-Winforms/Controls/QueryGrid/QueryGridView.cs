using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Databvase_Winforms.Properties;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Databvase_Winforms.Controls.QueryGrid
{
    public class QueryGridView : GridView
    {
        public GridColumn RowNumberColumn = new GridColumn();
        public PopupMenu RightClickPopupMenu = new PopupMenu();
        private BarManager RightClickBarManager = new BarManager();
        public QueryGridView()
        {
            InitializeGridView();
            AdjustProperties();
        }

        public QueryGridView(GridControl grid)
            : base(grid)
        {
            InitializeGridView();
            AdjustProperties();
        }

        private void InitializeGridView()
        {
            this.CustomUnboundColumnData += OnCustomUnboundColumnData;
            this.RowCellStyle += QueryGridView_RowCellStyle;
            this.CustomColumnDisplayText += OnCustomColumnDisplayText;
            SetUpPopUpMenu();
            this.PopupMenuShowing += OnPopupMenuShowing;
        }

        private void SetUpPopUpMenu()
        {
            RightClickBarManager.Images = GetPopupMenuImages();
            RightClickBarManager.Form = this.GridControl;
            RightClickPopupMenu.Manager = RightClickBarManager;
            RightClickPopupMenu.AddItems(GetPopupItems());


        }

        private BarItem[] GetPopupItems()
        {
            return new BarItem[] {CreateCopyCellsItem(), CreateSelectAllItem()};
        }

        private BarButtonItem CreateCopyCellsItem()
        {
            BarButtonItem copyCellsItem = new BarButtonItem(RightClickBarManager, "Copy Selected Cells", 0);
            copyCellsItem.ItemClick += CopyCellsItemOnItemClick;
            return copyCellsItem;
        }

        private BarButtonItem CreateSelectAllItem()
        {
            BarButtonItem selectAllItem = new BarButtonItem(RightClickBarManager, "Select All", 1);
            selectAllItem.ItemClick += SelectAllItem_ItemClick;
            return selectAllItem;
        }

        private ImageCollection GetPopupMenuImages()
        {
            var imageCollection = new ImageCollection();
            imageCollection.Images.Add(Resources.Copy_16x16);
            imageCollection.Images.Add(Resources.SelectAll_16x16);
            return imageCollection;

        }



        private void SelectAllItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectAll();
        }

        private void CopyCellsItemOnItemClick(object sender, ItemClickEventArgs e)
        {
            CopyToClipboard();
        }

        private void OnPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                RightClickPopupMenu.ShowPopup(Control.MousePosition);
            }


        }

        private void AdjustProperties()
        {
            OptionsBehavior.Editable = false;
            OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            OptionsSelection.MultiSelect = true;
            OptionsView.ColumnAutoWidth = false;

        }

        private void OnCustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == DBNull.Value)
            {
                e.DisplayText = App.Config.NullGridText;
            }

            if (e.Column.ColumnType == typeof(bool))
            {
                if (e.Value != DBNull.Value)
                {
                    e.DisplayText = (bool)e.Value ? "True" : "False";
                }
                else
                {
                    e.DisplayText = App.Config.NullGridText;
                }
                
            }
        }

        private void QueryGridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.CellValue == DBNull.Value)
            {
                e.Appearance.BackColor = App.Config.NullGridCellColor;
            }
        }

        private void OnCustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == RowNumberColumn)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }



        public void AddRowNumberColumn()
        {
            BeginUpdate();
            RowNumberColumn.Caption = "#";
            RowNumberColumn.FieldName = "Row";
            RowNumberColumn.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            RowNumberColumn.Visible = true;
            Columns.Add(RowNumberColumn);
            RowNumberColumn.VisibleIndex = 0;
            RowNumberColumn.BestFit();
            EndUpdate();
        }





        

    }


}
