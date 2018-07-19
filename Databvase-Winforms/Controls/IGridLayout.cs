using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databvase_Winforms.Controls
{
    public interface IGridLayout
    {
        void PrintQueryResultGrids();
        void ExportQueryResultsGrids(string fileExtension);
        string QueryPaneName { get; set; }
    }
}
