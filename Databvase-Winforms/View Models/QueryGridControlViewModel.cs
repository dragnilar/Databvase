using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Messages;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace Databvase_Winforms.View_Models
{
    [POCOViewModel]
    public class QueryGridControlViewModel : IDisposable
    {
        public virtual DataTable GridSource { get; set; }
        public virtual string GridName { get; set; }
        public virtual string QueryPaneName { get; set; }
        //public virtual bool ClearGrid { get; set; }
        //public virtual bool GridDataIsReady { get; set; }
        public virtual bool AddIndicator { get; set; }
        private bool IsDisposed = false;
        


        public QueryGridControlViewModel()
        {
            SetDefaults();

            RegisterMessages();
        }

        private void SetDefaults()
        {
            GridSource = null;
            //ClearGrid = false;
            //GridDataIsReady = false;
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
            if (message.GridName == GridName)
            {
                SetGridSource(message.GridSource);
            }
        }

        private void SetGridSource(DataTable gridDataTable)
        {
            //ClearGrid = true;
            GridSource = gridDataTable;
           // GridDataIsReady = true;
           // ClearGrid = false;
           // GridDataIsReady = false;
            if (App.Config.ShowRowNumberColumn)
            {
                AddRowNumberColumn();
            }  
        }

        private void AddRowNumberColumn()
        {
            AddIndicator = true;
            AddIndicator = false;
        }

        public void Dispose()
        {
            GridSource?.Dispose();
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                IsDisposed = true;
            }
        }
    }
}
