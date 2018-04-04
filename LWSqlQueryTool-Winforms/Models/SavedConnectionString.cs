using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWSqlQueryTool_Winforms.Models
{
    /// <summary>
    /// This is a class that is used to store connection strings to the application settings
    /// </summary>
    public class SavedConnectionString
    {
        public string NickName { get; set; }
        public string ConnectionString { get; set; }

        public override string ToString()
        {
            return NickName;
        }
    }
}
