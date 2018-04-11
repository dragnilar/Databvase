using System.Collections.Generic;
using System.Drawing;
using Databvase_Winforms.Models;
using Tyrrrz.Settings;

namespace Databvase_Winforms
{
    public class Settings : SettingsManager
    {
        public List<SavedConnection> ConnectionStrings = new List<SavedConnection>();
        public string DefaultSkinName = "The Bezier";
        public string DefaultSvgPalette = string.Empty;
        public Color SavedSkinColor1 = Color.Empty;
        public Color SavedSkinColor2 = Color.Empty;
        public bool UseDirectX = false;

        public Settings()
        {
            Configuration.StorageSpace = StorageSpace.Instance;
            Configuration.FileName = "SettingsFile.json";
            Configuration.SubDirectoryPath = "Settings";
        }
    }
}