using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Dialogs;

namespace Databvase_Winforms.Services
{
    public interface IQueryBuilderService
    {
        void ShowQueryBuilder();
    }

    public class QueryBuilderService : IQueryBuilderService
    {
        public void ShowQueryBuilder()
        {
            new QueryBuilderDialogWrapper().RunQueryBuilder();
        }
    }
}
