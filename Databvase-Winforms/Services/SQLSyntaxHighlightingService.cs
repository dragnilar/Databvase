using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Services;

namespace Databvase_Winforms.Services
{
    /// <summary>
    /// Source: https://www.devexpress.com/Support/Center/Example/Details/E4139/how-to-implement-t-sql-language-syntax-highlighting-by-creating-syntax-highlight-tokens
    /// </summary>
    internal class SQLSyntaxHighlightingService : ISyntaxHighlightService
    {
        #region #parsetokens

        private readonly Document document;

        private readonly SyntaxHighlightProperties defaultSettings =
            new SyntaxHighlightProperties {ForeColor = App.Config.TextEditorDefaultColor };

        private readonly SyntaxHighlightProperties keywordSettings =
            new SyntaxHighlightProperties {ForeColor = App.Config.TextEditorKeywordColor };

        private readonly SyntaxHighlightProperties stringSettings =
            new SyntaxHighlightProperties {ForeColor = App.Config.TextEditorStringColor };

        private readonly SyntaxHighlightProperties commentSettings =
            new SyntaxHighlightProperties{ForeColor = App.Config.TextEditorCommentsColor};

        private readonly string[] keywords =
        {
            "INSERT", "SELECT", "CREATE", "TABLE", "USE", "IDENTITY", "ON", "OFF", "NOT", "NULL", "WITH", "SET",
            "FROM", "WHERE", "JOIN", "DBCC", "AND", "OR", "ALTER", "AS", "BETWEEN", "DATABASE", "INDEX", "VIEW",
            "DELETE", "DROP", "EXISTS", "GROUP BY", "HAVING", "IN", "INTO", "INNER JOIN", "LEFT JOIN",
            "RIGHT JOIN", "FULL JOIN", "LIKE", "ORDER BY", "SELECT *", "SELECT DISTINCT", "SELECT",
            "SELECT TOP", "TRUNCATE TABLE", "UNION ALL", "UPDATE", "EXEC"
        };

        public SQLSyntaxHighlightingService(Document document)
        {
            this.document = document;
        }

        private List<SyntaxHighlightToken> ParseTokens()
        {
            var tokens = new List<SyntaxHighlightToken>();
            DocumentRange[] documentRanges = null;

            // search for comments
            var regularExpression = new Regex(@"(/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/)|(--.*)");
            documentRanges = document.FindAll(regularExpression);
            foreach (var range in documentRanges)
            {
                if (!IsRangeInTokens(range, tokens))
                {
                    tokens.Add(new SyntaxHighlightToken(range.Start.ToInt(), range.Length, commentSettings));
                }
            }
            // search for quotation marks
            documentRanges = document.FindAll("'", SearchOptions.None);
            for (var i = 0; i < documentRanges.Length / 2; i++)
                tokens.Add(new SyntaxHighlightToken(documentRanges[i * 2].Start.ToInt(),
                    documentRanges[i * 2 + 1].Start.ToInt() - documentRanges[i * 2].Start.ToInt() + 1, stringSettings));
            // search for keywords
            foreach (var keywordRange in keywords)
            {
                documentRanges = document.FindAll(keywordRange, SearchOptions.None | SearchOptions.WholeWord);

                foreach (var range in documentRanges)
                    if (!IsRangeInTokens(range, tokens))
                        tokens.Add(new SyntaxHighlightToken(range.Start.ToInt(), range.Length,
                            keywordSettings));
            }

            // order tokens by their start position
            tokens.Sort(new SyntaxHighlightTokenComparer());
            // fill in gaps in document coverage
            AddPlainTextTokens(tokens);
            return tokens;
        }

        private void AddPlainTextTokens(List<SyntaxHighlightToken> tokens)
        {
            var count = tokens.Count;
            if (count == 0)
            {
                tokens.Add(new SyntaxHighlightToken(0, document.Range.End.ToInt(), defaultSettings));
                return;
            }

            tokens.Insert(0, new SyntaxHighlightToken(0, tokens[0].Start, defaultSettings));
            for (var i = 1; i < count; i++)
                tokens.Insert(i * 2, new SyntaxHighlightToken(tokens[i * 2 - 1].End,
                    tokens[i * 2].Start - tokens[i * 2 - 1].End, defaultSettings));
            tokens.Add(new SyntaxHighlightToken(tokens[count * 2 - 1].End,
                document.Range.End.ToInt() - tokens[count * 2 - 1].End, defaultSettings));
        }

        private bool IsRangeInTokens(DocumentRange range, List<SyntaxHighlightToken> tokens)
        {
            return tokens.Any(t => IsIntersect(range, t));
        }

        private bool IsIntersect(DocumentRange range, SyntaxHighlightToken token)
        {
            var start = range.Start.ToInt();
            if (start >= token.Start && start < token.End)
                return true;
            var end = range.End.ToInt() - 1;
            if (end >= token.Start && end < token.End)
                return true;
            return false;
        }

        #endregion #parsetokens

        #region #ISyntaxHighlightServiceMembers

        public void ForceExecute()
        {
            Execute();
        }

        public void Execute()
        {
            document.ApplySyntaxHighlight(ParseTokens());
        }

        #endregion #ISyntaxHighlightServiceMembers
    }

    #region #SyntaxHighlightTokenComparer

    public class SyntaxHighlightTokenComparer : IComparer<SyntaxHighlightToken>
    {
        public int Compare(SyntaxHighlightToken x, SyntaxHighlightToken y)
        {
            return x.Start - y.Start;
        }
    }

    #endregion #SyntaxHighlightTokenComparer
}