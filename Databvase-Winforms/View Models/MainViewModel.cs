using System.Linq;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;

namespace Databvase_Winforms.View_Models
{
    [MetadataType(typeof(MetaData))]
    public class MainViewModel
    {

        public IDocumentManagerService DocumentManagerService => this.GetRequiredService<IDocumentManagerService>();
        public virtual int NumberOfQueries { get; set; }
        public virtual bool ShowRowNumberColumn {get; set; }

        public MainViewModel()
        {
            NumberOfQueries = 0;
            ShowRowNumberColumn = App.Config.ShowRowNumberColumn;
        }

        public void AddNewTab()
        {
            NumberOfQueries++;
            var vm = new QueryControlViewModel();
            var docInfo = new DocumentInfo
            {
                DocumentTitle = $"Query {NumberOfQueries}",
                DocumentType = "QueryControl"
            };
            var document = DocumentManagerService.CreateDocument(docInfo.DocumentType, vm);
            document.Title = docInfo.DocumentTitle;
            document.DestroyOnClose = true;
            document.Show();
        }


        private class DocumentInfo
        {
            public string DocumentType;
            public string DocumentTitle;

        }

        protected void OnShowRowNumberColumnChanged()
        {
            App.Config.ShowRowNumberColumn = ShowRowNumberColumn;
            App.Config.Save();
        }

        public class MetaData : IMetadataProvider<MainViewModel>
        {
            public void BuildMetadata(MetadataBuilder<MainViewModel> builder)
            {
                builder.Property(x => x.ShowRowNumberColumn)
                    .OnPropertyChangedCall(x => x.OnShowRowNumberColumnChanged());
            }
        }

    }

}