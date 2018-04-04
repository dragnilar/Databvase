using System.Data;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors;
using LWSqlQueryTool_Winforms.Models;
using LWSqlQueryTool_Winforms.Services;

namespace LWSqlQueryTool_Winforms.View_Models
{
    [POCOViewModel()]
    public class QueryControlViewModel
    {
        byte[] document = default(byte[]);
        public virtual QueryDocumentEntity Entity { get; set; }
        public virtual DataTable GridSource { get; set; }
        public virtual bool ClearGrid { get; set; }
        public virtual string ResultsMessage { get; set; }

        public QueryControlViewModel()
        {
            Entity = new QueryDocumentEntity {DocumentText = string.Empty};
            GridSource = null;
            ResultsMessage = string.Empty;
        }

        public void Query()
        {
            var result = this.GetService<IQueryEditorService>().RunQuery();
            if (result != null)
            {
                if (result.HasErrors)
                {
                    ResultsMessage = $"Errors Occured: \n{result.ResultsMessage}";
                }
                else
                {
                    ClearGrid = true;
                    GridSource = result.ResultsTable;
                    ClearGrid = false;
                    ResultsMessage = result.ResultsMessage;
                }

               
            }

        }

        public void Update()
        {
            //TODO - Implement some kind of functionality if necessary, otherwise do nothing here since this is needed for the MVVM context
        }




    }
}
