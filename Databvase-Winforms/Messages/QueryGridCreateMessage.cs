using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace Databvase_Winforms.Messages
{
    public class QueryGridCreateMessage
    {
        public int NumberOfGrids { get; set; }
        public string QueryPaneName { get; set; }

        public QueryGridCreateMessage(int numberOfGrids, string queryPaneName)
        {
            QueryPaneName = queryPaneName;
            NumberOfGrids = numberOfGrids;
            SendMessage();
        }

        private void SendMessage()
        {
            Messenger.Default.Send(this, GetType().Name);
        }
    }
}
