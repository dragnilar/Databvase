using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.Controls.QueryGrid;

namespace Databvase_Winforms.Factories
{
    public class QueryGridFactory
    {
        public QueryGridControl BuildADockedGrid(int gridNumber = 0)
        {
            var gridControl = new QueryGridControl();
            var gridView = new QueryGridView();
            gridControl.ViewCollection.Add(gridView);
            gridControl.Name = $"Grid Control {gridNumber}";
            gridView.Name = $"Grid View {gridNumber}";
            gridControl.Dock = DockStyle.Fill;


            return gridControl;
        }
    }
}
