using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Services;

namespace Databvase_Winforms.Services
{
    /// <summary>
    ///     Original Source:
    ///     https://www.devexpress.com/Support/Center/Example/Details/E4139/how-to-implement-t-sql-language-syntax-highlighting-by-creating-syntax-highlight-tokens
    ///     Corrections courtesy of Ingvar from DevExpress here:
    ///     https://www.devexpress.com/Support/Center/Question/Details/T535524/syntax-highlighting-crashes-on-some-phrases-using-ticket-id-e4139-sample-code
    /// </summary>
    internal class SQLSyntaxHighlightingService : ISyntaxHighlightService
    {
        #region #parsetokens

        private readonly Document document;

        private readonly SyntaxHighlightProperties defaultSettings =
            new SyntaxHighlightProperties { ForeColor = App.Config.TextEditorDefaultColor };

        private readonly SyntaxHighlightProperties keywordSettings =
            new SyntaxHighlightProperties { ForeColor = App.Config.TextEditorKeywordColor };

        private readonly SyntaxHighlightProperties stringSettings =
            new SyntaxHighlightProperties { ForeColor = App.Config.TextEditorStringColor };

        private readonly SyntaxHighlightProperties beginEndSettings =
            new SyntaxHighlightProperties { ForeColor = Color.DarkViolet };

        private readonly SyntaxHighlightProperties datetypeSettings =
            new SyntaxHighlightProperties { ForeColor = Color.Brown };

        private readonly SyntaxHighlightProperties functionSettings =
            new SyntaxHighlightProperties { ForeColor = Color.DarkViolet };

        private readonly SyntaxHighlightProperties variableSettings =
            new SyntaxHighlightProperties { ForeColor = Color.DarkGreen };

        private readonly SyntaxHighlightProperties commentSettings =
            new SyntaxHighlightProperties { ForeColor = App.Config.TextEditorCommentsColor };

        private readonly SyntaxHighlightProperties numericSettings =
            new SyntaxHighlightProperties { ForeColor = Color.Brown };

        private readonly string[] keywords =
        {
            "INSERT", "INTO", "DECLARE", "DISTINCT", "SELECT", "CREATE", "TABLE", "USE", "IDENTITY", "ON", "OFF", "NOT",
            "NULL",
            "WITH", "SET", "FROM", "WHERE", "CASE", "WHEN", "AS", "PROC", "PROCEDURE", "AND", "OR", "LIKE", "UPDATE",
            "DELETE",
            "DROP", "WHILE", "EXEC", "EXECUTE", "IF", "ELSE"
        };

        private readonly string[] beginEnd = { "BEGIN", "END", "TRAN", "TRANSACTION", "ROLLBACK", "COMMIT", "SAVE" };

        private readonly string[] datetype =
        {
            "INT", "INTEGER", "TEXT", "IMAGE", "DECIMAL", "BIT", "INT", "NUMERIC", "TINYINT", "CHAR", "VARCHAR",
            "UNSIGNED"
        };

        private readonly string[] function =
        {
            "GETDATE", "DATEPART", "DATEADD", "DATEDIFF", "ISNULL", "SUM", "COUNT", "MIN", "MAX", "LIST", "SUBSTRING",
            "CHAR_LENGTH", "RTRIM", "LTRIM", "SUBSTRING", "CONVERT", "AVG"
        };

        public SQLSyntaxHighlightingService(Document document)
        {
            this.document = document;
        }

        private List<SyntaxHighlightToken> ParseTokens()
        {
            var tokens = new List<SyntaxHighlightToken>();
            DocumentRange[] ranges = null;
            //TODO - Unfortunately Regex is not sufficient for parsing SQL comments.
            //TODO - Will need to look into using an actual SQL Parser to handle comments more like SSMS.
            var expr = new Regex(@"(/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/)|(--.*)");
            ranges = document.FindAll(expr);
            foreach (var t in ranges)
                if (!IsRangeInTokens(t, tokens))
                    tokens.Add(new SyntaxHighlightToken(t.Start.ToInt(), t.Length, commentSettings));

            // search for quotation marks
            ranges = document.FindAll("'", SearchOptions.None);
            var rangeIndex = 0;

            while (rangeIndex < ranges.Length - 1)
            {
                var range = document.CreateRange(ranges[rangeIndex].Start.ToInt(),
                    ranges[rangeIndex + 1].End.ToInt() - ranges[rangeIndex].Start.ToInt());
                if (IsRangeInTokens(range, tokens))
                {
                    rangeIndex++;
                }
                else
                {
                    tokens.Add(new SyntaxHighlightToken(range.Start.ToInt(), range.Length, stringSettings));
                    rangeIndex += 2;
                }
            }
            //search for strings
            ranges = document.FindAll("\"", SearchOptions.None);
            for (var i = 0; i < ranges.Length / 2; i++)
            {
                var range = document.CreateRange(ranges[i * 2].Start.ToInt(),
                    ranges[i * 2 + 1].Start.ToInt() - ranges[i * 2].Start.ToInt() + 1);
                if (!IsRangeInTokens(range, tokens))
                    tokens.Add(new SyntaxHighlightToken(range.Start.ToInt(), range.Length, stringSettings));
            }

            // search for keywords
            foreach (var t in keywords)
            {
                ranges = document.FindAll(t, SearchOptions.None | SearchOptions.WholeWord);

                for (var j = 0; j < ranges.Length; j++)
                    if (!IsRangeInTokens(ranges[j], tokens))
                        tokens.Add(new SyntaxHighlightToken(ranges[j].Start.ToInt(), ranges[j].Length,
                            keywordSettings));
            }
            //search for beginEnd
            foreach (var t in beginEnd)
            {
                ranges = document.FindAll(t, SearchOptions.None | SearchOptions.WholeWord);

                for (var j = 0; j < ranges.Length; j++)
                    if (!IsRangeInTokens(ranges[j], tokens))
                        tokens.Add(
                            new SyntaxHighlightToken(ranges[j].Start.ToInt(), ranges[j].Length, beginEndSettings));
            }
            //search for date types
            foreach (var t in datetype)
            {
                ranges = document.FindAll(t, SearchOptions.None | SearchOptions.WholeWord);

                for (var j = 0; j < ranges.Length; j++)
                    if (!IsRangeInTokens(ranges[j], tokens))
                        tokens.Add(
                            new SyntaxHighlightToken(ranges[j].Start.ToInt(), ranges[j].Length, datetypeSettings));
            }
            //search for functions
            foreach (var t in function)
            {
                ranges = document.FindAll(t, SearchOptions.None | SearchOptions.WholeWord);

                foreach (var t1 in ranges)
                    if (!IsRangeInTokens(t1, tokens))
                        tokens.Add(
                            new SyntaxHighlightToken(t1.Start.ToInt(), t1.Length, functionSettings));
            }
            //search for variables
            expr = new Regex(@"(@\w*)");
            ranges = document.FindAll(expr);
            for (var i = 0; i < ranges.Length; i++)
                if (!IsRangeInTokens(ranges[i], tokens))
                    tokens.Add(new SyntaxHighlightToken(ranges[i].Start.ToInt(), ranges[i].Length, variableSettings));

            //search for numerics
            expr = new Regex(@"( [0-9].[0-9]\w*)|( [0-9]\w*)");
            ranges = document.FindAll(expr);
            foreach (var t in ranges)
                if (!IsRangeInTokens(t, tokens))
                    tokens.Add(new SyntaxHighlightToken(t.Start.ToInt(), t.Length, numericSettings));

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

            if (tokens[0].Start > 0)
                tokens.Insert(0, new SyntaxHighlightToken(0, tokens[0].Start, defaultSettings));

            for (var i = count - 1; i > 0; i--)
            {
                var token = tokens[i];
                var prevToken = tokens[i - 1];
                if (token.Start - prevToken.End >= 0)
                    tokens.Insert(i,
                        new SyntaxHighlightToken(prevToken.End, token.Start - prevToken.End, defaultSettings));
            }

            tokens.Add(new SyntaxHighlightToken(tokens[tokens.Count - 1].End,
                document.Range.End.ToInt() - tokens[tokens.Count - 1].End, defaultSettings));
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
            if (start < token.Start && end >= token.End)
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
            var tokens = ParseTokens();
            document.ApplySyntaxHighlight(tokens);
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