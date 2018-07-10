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
        /// <summary>
        /// Returns a query grid control set to fully docked. The name of the control and its default view will be based off of the
        /// integer argument. NOTE: If you do not pass an integer, the method will assume the grid number is 0.
        /// </summary>
        /// <param name="gridNumber">Named number of the desired grid (I.E. 5 will yield a grid named Grid Control 5</param>
        /// <returns></returns>
        public QueryGridControl BuildADockedGrid(int gridNumber = 0)
        {
            var gridControl = new QueryGridControl();
            var gridView = new QueryGridView();
            gridControl.ViewCollection.Add(gridView);
            gridControl.Name = $"Grid Control {gridNumber}";
            gridView.Name = $"Grid View {gridNumber}";
            gridControl.Dock = DockStyle.Fill;
            gridControl.SetGridName($"Grid Control {gridNumber}");


            return gridControl;
        }
    }
}
