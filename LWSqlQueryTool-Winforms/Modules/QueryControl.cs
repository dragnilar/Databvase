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
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Model;
using DevExpress.XtraRichEdit.API.Native;
using LWSqlQueryTool_Winforms.Services;
using LWSqlQueryTool_Winforms.View_Models;

namespace LWSqlQueryTool_Winforms.Modules
{
    public partial class QueryControl : DevExpress.XtraEditors.XtraUserControl
    {
        public QueryControl()
        {
            InitializeComponent();
            SetupQueryEditor();
            if (!mvvmContextQueryControl.IsDesignMode)
                InitializeBindings();
        }

        public void SaveQuery()
        {
            richEditControlQueryEditor.SaveDocumentAs();
        }

        private void SetupQueryEditor()
        {
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.RestartType = DevExpress.XtraRichEdit.API.Native.LineNumberingRestart.Continuous;
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.Start = 1;
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.CountBy = 1;
            richEditControlQueryEditor.Document.Sections[0].LineNumbering.Distance = 0.1f;
        }

        void InitializeBindings()
        {
            var fluent = mvvmContextQueryControl.OfType<QueryControlViewModel>();
            mvvmContextQueryControl.RegisterService(new QueryEditorService(richEditControlQueryEditor));
            fluent.SetObjectDataSourceBinding(bindingSourceQueryControl, x => x.Entity, x => x.Update());
            fluent.ViewModel.RaisePropertyChanged(x=>x.Entity);
            fluent.WithKey(richEditControlQueryEditor, Keys.F5).KeyToCommand(x => x.Query());
            fluent.SetBinding(gridControlResults, x => x.DataSource, y => y.GridSource);
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
