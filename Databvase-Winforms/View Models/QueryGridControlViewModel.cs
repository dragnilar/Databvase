using System;
using System.Data;
using Databvase_Winforms.Messages;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class QueryGridControlViewModel : IDisposable
    {
        private bool IsDisposed;


        public QueryGridControlViewModel()
        {
            SetDefaults();

            RegisterMessages();
        }

        public virtual DataTable GridSource { get; set; }
        public virtual string GridName { get; set; }

        public virtual string QueryPaneName { get; set; }


        public virtual bool AddIndicator { get; set; }

        public void Dispose()
        {
            GridSource?.Dispose();
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        private void SetDefaults()
        {
            GridSource = null;
            AddIndicator = false;
            GridName = string.Empty;
            QueryPaneName = string.Empty;
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<QueryGridDataSourceMessage>(this,
                typeof(QueryGridDataSourceMessage).Name, OnQueryGridDataSourceMessage);
        }

        private void OnQueryGridDataSourceMessage(QueryGridDataSourceMessage message)
        {
            if (IsDisposed) return;
            if (string.IsNullOrWhiteSpace(message.GridName)) return;
            if (message.GridSource == null) return;
            if (message.QueryPaneName != QueryPaneName) return;
            if (message.GridName == GridName) SetGridSource(message.GridSource);
        }

        private void SetGridSource(DataTable gridDataTable)
        {
            GridSource = gridDataTable;
            if (App.Config.ShowRowNumberColumn) AddRowNumberColumn();
        }

        private void AddRowNumberColumn()
        {
            AddIndicator = true;
            AddIndicator = false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            if (disposing) IsDisposed = true;
        }
    }
}