using DevExpress.Mvvm;

namespace Databvase_Winforms.Models
{
    public class QueryDocumentEntity : BindableBase
    {
        private string _documentText;

        public string DocumentText
        {
            get => _documentText;
            set => SetProperty(ref _documentText, value, "DocumentText");
        }

    }
}