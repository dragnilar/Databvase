using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.Handler;
using DevExpress.XtraGrid.Views.Base.ViewInfo;

namespace Databvase_Winforms.Controls.QueryGrid
{
    public class QueryGridRegistrator : GridInfoRegistrator
    {
        public override string ViewName => "QueryGridView";

        public override BaseView CreateView(GridControl grid)
        {
            return new QueryGridView(grid as QueryGridControl);
        }

        public override BaseViewInfo CreateViewInfo(BaseView view)
        {
            return new QueryGridViewInfo(view as QueryGridView);
        }

        public override BaseViewHandler CreateHandler(BaseView view)
        {
            return new QueryGridHandler(view as QueryGridView);
        }

        public override BaseViewPainter CreatePainter(BaseView view)
        {
            return new QueryGridViewPainter(view as QueryGridView);
        }
    }
}
