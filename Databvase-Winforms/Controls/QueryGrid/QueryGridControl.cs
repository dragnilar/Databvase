using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;

namespace Databvase_Winforms.Controls.QueryGrid
{
    public class QueryGridControl: GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            return CreateView("QueryGridView");
        }
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new QueryGridRegistrator());
        }

        public QueryGridControl()
        {
            AdjustProperties();
        }

        private void AdjustProperties()
        {
            this.UseEmbeddedNavigator = true;
        }
    }
}
