using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.DAL;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Models;
using DevExpress.Mvvm;
using ScintillaNET;

namespace Databvase_Winforms.Controls.ScintillaNetEditor
{
    public class ScintillaEdit : Scintilla
    {


        public ScintillaEdit()
        {
            InitializeScintilla();
            
        }

        private void InitializeScintilla()
        {
            SetupScintilla();
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<SettingsUpdatedMessage>(this, typeof(SettingsUpdatedMessage).Name, ApplySettingsUpdate);
        }

        #region Setup And Styling

        private void SetupScintilla()
        {


            CaretForeColor = Color.Black; //TODO - Create setting for this
            

            Margins[0].Width = 16;

            ApplyTextEditorStyles();


            Lexer = Lexer.Sql;

            ApplySqlSyntaxColors();
            ApplyKeywordsForLexer();
            UsePopup(false);
        }

        private void ApplyTextEditorStyles()
        {

            StyleResetDefault();
            ApplyFontChange();
            ApplyTextEditorColors();
            StyleClearAll();
            ApplyLineNumberColors();


        }

        private void ApplyTextEditorColors()
        {
            Styles[Style.Default].BackColor = App.Config.TextEditorBackgroundColor;
        }

        private void ApplyLineNumberColors() 
        {
            Styles[Style.LineNumber].BackColor = Color.Gray;
            Styles[Style.LineNumber].ForeColor = App.Config.TextEditorLineNumberColor;
        }

        private void ApplyFontChange()
        {
            Styles[Style.Default].Font = App.Config.DefaultTextEditorFont.Name;
            Styles[Style.Default].SizeF = App.Config.DefaultTextEditorFont.Size;
            Styles[Style.Default].Bold = App.Config.DefaultTextEditorFont.Bold;
            Styles[Style.Default].Italic = App.Config.DefaultTextEditorFont.Italic;
            Styles[Style.Default].Underline = App.Config.DefaultTextEditorFont.Underline;


        }

        private void ApplyKeywordsForLexer()
        {
            string keywords1 =
                "add alter as asc authorization backup begin break browse bulk by cascade case check checkpoint close clustered column commit compute constraint containstable continue create current current_date cursor database dbcc deallocate declare default delete deny desc disk distinct distributed double drop dump else end errlvl escape except exec execute exit external fetch file fillfactor for foreign freetext freetexttable from full function goto grant group having holdlock identity identity_insert identitycol if index insert intersect into key kill lineno load merge national nocheck nonclustered of off offsets on open opendatasource openquery openrowset openxml option order over percent plan precision primary print proc procedure public raiserror read readtext reconfigure references replication restore restrict return revert revoke rollback rowcount rowguidcol rule save schema securityaudit select semantickeyphrasetable semanticsimilaritydetailstable semanticsimilaritytable set setuser shutdown statistics table tablesample textsize then to top tran transaction trigger truncate union unique updatetext use user values varying view waitfor when where while with within group writetext";
            string keywords2 =
                "coalesce collate contains convert current_time current_timestamp current_user nullif session_user system_user try_convert tsequal update";
            string keywords3 =
                "all and any between cross exists in inner is join left like not null or outer pivot right some unpivot";
            SetKeywords(0, keywords1);
            SetKeywords(1, keywords2);
            SetKeywords(2, keywords3);
        }

        private void ApplySqlSyntaxColors()
        {
            Styles[Style.Sql.Word].ForeColor = App.Config.TextEditorKeywordColor;
            Styles[Style.Sql.Word].Bold = true;
            Styles[Style.Sql.Identifier].ForeColor = App.Config.TextEditorDefaultColor;
            Styles[Style.Sql.Character].ForeColor = App.Config.TextEditorStringColor;
            Styles[Style.Sql.Number].ForeColor = Color.FromArgb(255, 205, 34); //TODO - Create setting for this
            Styles[Style.Sql.Operator].ForeColor = Color.FromArgb(232, 226, 183); //TODO - Create setting for this
            Styles[Style.Sql.Comment].ForeColor = App.Config.TextEditorCommentsColor;
            Styles[Style.Sql.CommentLine].ForeColor = App.Config.TextEditorCommentsColor;
        }

        private void ApplySettingsUpdate(SettingsUpdatedMessage message)
        {
            if (message.Type == SettingsUpdatedMessage.SettingsUpdateType.TextEditorStyles)
            {
                if (!IsDisposed)
                {
                    ApplyTextEditorStyles();
                    ApplySqlSyntaxColors();
                }

            }
        }

        #endregion


        public QueryResult RunQuery(string sqlQuery, string dbName, SavedConnection connection)
        {
            //TODO - See if this actually hurts performance, if so either switch back to static or something else so its always available.
            var queryUnit = new SQLQuery();
            return sqlQuery == null ? null : queryUnit.SendQueryAndGetResult(sqlQuery, dbName, connection);
        }

        public string GetSqlQueryFromQueryPane()
        {
            string sqlQuery = null;

            if (!string.IsNullOrWhiteSpace(SelectedText))
            {
                sqlQuery += SelectedText;
            }
            else
            {
                sqlQuery = Text;
            }

            //TODO - Comment parsing needs to be improved
            if (string.IsNullOrEmpty(sqlQuery) || sqlQuery.StartsWith("--") || sqlQuery.StartsWith("/*")) return null;

            return sqlQuery;
        }
    }
}
