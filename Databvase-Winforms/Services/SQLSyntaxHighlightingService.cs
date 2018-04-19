using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private readonly string[] keywords =
        {
            "INSERT", "SELECT", "CREATE", "TABLE", "USE", "IDENTITY", "ON", "OFF", "NOT", "NULL", "WITH", "SET",
            "FROM", "WHERE", "JOIN", "DBCC"
        };

        public SQLSyntaxHighlightingService(Document document)
        {
            this.document = document;
        }

        private List<SyntaxHighlightToken> ParseTokens()
        {
            var tokens = new List<SyntaxHighlightToken>();
            DocumentRange[] ranges = null;
            // search for quotation marks
            ranges = document.FindAll("'", SearchOptions.None);
            for (var i = 0; i < ranges.Length / 2; i++)
                tokens.Add(new SyntaxHighlightToken(ranges[i * 2].Start.ToInt(),
                    ranges[i * 2 + 1].Start.ToInt() - ranges[i * 2].Start.ToInt() + 1, stringSettings));
            // search for keywords
            for (var i = 0; i < keywords.Length; i++)
            {
                ranges = document.FindAll(keywords[i], SearchOptions.None | SearchOptions.WholeWord);

                for (var j = 0; j < ranges.Length; j++)
                    if (!IsRangeInTokens(ranges[j], tokens))
                        tokens.Add(new SyntaxHighlightToken(ranges[j].Start.ToInt(), ranges[j].Length,
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