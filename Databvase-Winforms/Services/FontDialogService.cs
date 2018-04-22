using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.Controls;

namespace Databvase_Winforms.Services
{
    public interface IFontDialogService
    {
        Font ShowDialog(Font SelectedFont);
    }

    public class FontDialogService : IFontDialogService
    {
        public Font ShowDialog(Font SelectedFont)
        {

            var fontDialog = new XtraFontDialog(SelectedFont);
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedFont = fontDialog.ResultFont;
            }
            fontDialog.Dispose();
            return SelectedFont;

        }
    }
}
