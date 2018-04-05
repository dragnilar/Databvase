using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Model;
using DevExpress.XtraRichEdit.API.Native;
using LWSqlQueryTool_Winforms.Services;
using LWSqlQueryTool_Winforms.View_Models;

namespace LWSqlQueryTool_Winforms.Modules
{
    public partial class QueryControl : DevExpress.XtraEditors.XtraUserControl
    {
        public RibbonControl Ribbon => ribbonControlQueryControl;

        public QueryControl()
        {
            InitializeComponent();
            SetupQueryEditor();
            if (!mvvmContextQueryControl.IsDesignMode)
                InitializeBindings();
        }


        private void SaveQueryButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Its probably better to leave this in the view because its using stuff baked into the view.
            richEditControlQueryEditor.SaveDocumentAs();
        }



        private void SetupQueryEditor()
        {
            //We want line numbers on the query editor because they are nice to have... :P
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.RestartType = DevExpress.XtraRichEdit.API.Native.LineNumberingRestart.Continuous;
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.Start = 1;
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.CountBy = 1;
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.Distance = 0.1f;
        }

        void InitializeBindings()
        {
            //Instantiate fluent API
            var fluent = mvvmContextQueryControl.OfType<QueryControlViewModel>();

            //Register services
            mvvmContextQueryControl.RegisterService(new QueryEditorService(richEditControlQueryEditor));

            //Data source binding for query editor
            fluent.SetObjectDataSourceBinding(bindingSourceQueryControl, x => x.Entity, x => x.Update());
            fluent.ViewModel.RaisePropertyChanged(x=>x.Entity);

            //Event to command
            fluent.EventToCommand<ItemClickEventArgs>(QueryButton, "ItemClick", x => x.Query());

            //With Key events
            fluent.WithKey(richEditControlQueryEditor, Keys.F5).KeyToCommand(x => x.Query());

            //Bindings
            fluent.SetBinding(gridControlResults, x => x.DataSource, y => y.GridSource);
            fluent.SetBinding(memoEditResults, x => x.EditValue, y => y.ResultsMessage);

            //Triggers
            fluent.SetTrigger(x=>x.ClearGrid, (clear)  =>
            {
                if (clear)
                {
                    gridViewResults.Columns.Clear();
                }
            });

        }


    }
}
