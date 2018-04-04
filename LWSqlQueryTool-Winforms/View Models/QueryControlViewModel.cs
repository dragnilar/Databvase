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

        public QueryControlViewModel()
        {
            Entity = new QueryDocumentEntity {DocumentText = string.Empty};
            GridSource = null;
        }

        public void Query()
        {
            var result = this.GetService<IQueryEditorService>().RunQuery();
            if (result != null)
            {
                if (result.HasErrors)
                {
                    XtraMessageBox.Show(result.ResultsMessage, "We Has ERrors?");

                }
                else
                {
                    ClearGrid = true;
                    GridSource = result.ResultsTable;
                    ClearGrid = false;
                }
            }

        }

        public void Update()
        {
            //TODO - Implement some kind of functionality if necessary, otherwise do nothing here since this is needed for the MVVM context
        }




    }
}
