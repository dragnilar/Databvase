using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace Databvase_Winforms.Messages
{
    public class QueryGridDataSourceMessage
    {
        public DataTable GridSource { get; set; }
        public string GridName { get; set; }
        public string QueryPaneName { get; set; }

        public QueryGridDataSourceMessage(DataTable gridSource, string gridName, string queryPaneName)
        {
            GridSource = gridSource;
            GridName = gridName;
            QueryPaneName = queryPaneName;
            SendMessage();
        }

        private void SendMessage()
        {
            Messenger.Default.Send(this, GetType().Name);
        }
    }
}
