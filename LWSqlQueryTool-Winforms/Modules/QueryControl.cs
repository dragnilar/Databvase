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
            richEditControlQueryEditor.KeyDown += RichEditControlQueryEditorOnKeyDown;
            if (!mvvmContextQueryControl.IsDesignMode)
                InitializeBindings();
        }

        private void RichEditControlQueryEditorOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                var sqlCrap = "";
                if (richEditControlQueryEditor.Document.Selection.Length > 1)
                {
                    var selection = richEditControlQueryEditor.Document.Selection;
                    sqlCrap = richEditControlQueryEditor.Document.GetText(selection);
                }
                else
                {
                    sqlCrap = richEditControlQueryEditor.Text;

                }
                try
                {
                    var goNecction =
                        new SqlConnection(ConnectionStringService.CurrentConnectionString);

                    var cmd = new SqlCommand();
                    SqlDataReader reader;
                    cmd.CommandText = sqlCrap;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = goNecction;

                    goNecction.Open();
                    reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);
                        gridViewResults.Columns.Clear();
                        gridControlResults.DataSource = dataTable;

                    }

                    reader.Dispose();
                    goNecction.Close();




                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString(), "We has errors?");
                }
            }
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
        }
    }
}
