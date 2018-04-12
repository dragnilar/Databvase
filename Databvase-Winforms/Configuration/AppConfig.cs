using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FX.Configuration;

namespace LWSqlQueryTool_Winforms.Configuration
{
    public class AppConfig : JsonConfiguration
    {
        public AppConfig()
        {

        }

        public string Test { get; set; }


    }
}
