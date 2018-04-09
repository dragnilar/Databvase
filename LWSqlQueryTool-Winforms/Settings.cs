using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Models;
using Tyrrrz.Settings;

namespace Databvase_Winforms
{
    public class Settings : SettingsManager
    {
        public Settings()
        {
            Configuration.StorageSpace = StorageSpace.Instance;
            Configuration.FileName = "SettingsFile.json";
            Configuration.SubDirectoryPath = "Settings";
        }
        public List<SavedConnectionString> ConnectionStrings = new List<SavedConnectionString>();
        public string DefaultSkinName = "The Bezier";
        public string DefaultSvgPalette = string.Empty;
        public Color SavedSkinColor1 = Color.Empty;
        public Color SavedSkinColor2 = Color.Empty;

    }
}
