using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWSqlQueryTool_Winforms.Messages
{
    public class TabNameMessage
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public const string TabRenameSender = "TabRenameSender";
    }
}
