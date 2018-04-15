using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Databvase_Winforms.Controls.QueryGrid
{
    public class QueryGridView : GridView
    {
        public GridColumn RowNumberColumn = new GridColumn();
        public QueryGridView()
        {
            InitializeGridView();
        }

        public QueryGridView(GridControl grid)
            : base(grid)
        {
            InitializeGridView();
        }

        private void InitializeGridView()
        {
            this.CustomUnboundColumnData += OnCustomUnboundColumnData;
            this.RowCellStyle += QueryGridView_RowCellStyle;
            this.CustomColumnDisplayText += OnCustomColumnDisplayText;
        }

        private void OnCustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == DBNull.Value)
            {
                e.DisplayText = "[NULL]";
            }
        }

        private void QueryGridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.CellValue == DBNull.Value)
            {
                e.Appearance.BackColor = Color.Red;
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
