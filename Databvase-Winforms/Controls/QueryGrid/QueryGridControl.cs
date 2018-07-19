using System;
using Databvase_Winforms.View_Models;
using DevExpress.Utils.MVVM;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;

namespace Databvase_Winforms.Controls.QueryGrid
{
    public class QueryGridControl: GridControl
    {
        private MVVMContext mvvmContextQueryGridControl = new MVVMContext();

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
            mvvmContextQueryGridControl.ViewModelType = typeof(QueryGridControlViewModel);
            if (!mvvmContextQueryGridControl.IsDesignMode)
            {
                InitializeBindings();
            }

            HookUpEvents();

        }

        public void SetGridName(string gridName)
        {
            mvvmContextQueryGridControl.GetViewModel<QueryGridControlViewModel>().GridName = gridName;
        }

        /// <summary>
        /// Sets the name of the query pane that the grid control belongs so that messages can find their way to the correct recipient.
        /// This could probably be refactored. This is also being used as a work around because the DX WinForms MVVM Framework does not
        /// seem to play nicely with Wpf.
        /// </summary>
        /// <param name="queryPaneName"></param>
        public void SetQueryPaneName(string queryPaneName)
        {
            mvvmContextQueryGridControl.GetViewModel<QueryGridControlViewModel>().QueryPaneName = queryPaneName;
        }

        private void HookUpEvents()
        {
            Disposed += OnDisposed;
        }

        private void OnDisposed(object sender, EventArgs e)
        {
            mvvmContextQueryGridControl.GetViewModel<QueryGridControlViewModel>().Dispose();
            mvvmContextQueryGridControl.Dispose();
        }

        private void AdjustProperties()
        {
            this.UseEmbeddedNavigator = true;
        }

        private void InitializeBindings()
        {
            var fluent = mvvmContextQueryGridControl.OfType<QueryGridControlViewModel>();
            fluent.SetBinding(this, x => x.DataSource, y => y.GridSource);
            fluent.SetTrigger(r => r.AddIndicator, showIndicator =>
            {
                if (showIndicator)
                {
                    ((QueryGridView) this.DefaultView).AddRowNumberColumn();
                }
            });
        }
    }
}
