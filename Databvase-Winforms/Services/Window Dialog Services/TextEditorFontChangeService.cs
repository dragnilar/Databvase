using System.Windows.Forms;
using Databvase_Winforms.Dialogs;

namespace Databvase_Winforms.Services.Window_Dialog_Services
{
    public interface ITextEditorFontChangeService
    {
        DialogResult ShowDialog();
    }
    public class TextEditorFontChangeService : ITextEditorFontChangeService
    {
        public DialogResult ShowDialog()
        {
            var dialog = new TextEditorFontChangeDialog {StartPosition = FormStartPosition.CenterParent};
            dialog.ShowDialog();
            return dialog.DialogResult;
        }
    }
}
