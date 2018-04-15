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
        public GridColumn IndicatorColumn = new GridColumn();
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
        }

        private void OnCustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == IndicatorColumn)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }



        public void AddRowNumberColumn()
        {
            BeginUpdate();
            IndicatorColumn.Caption = "#";
            IndicatorColumn.FieldName = "Row";
            IndicatorColumn.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            IndicatorColumn.Visible = true;
            Columns.Add(IndicatorColumn);
            IndicatorColumn.VisibleIndex = 0;
            EndUpdate();
        }



        

    }


}
