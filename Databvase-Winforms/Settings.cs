using System.Collections.Generic;
using System.Drawing;
using Databvase_Winforms.Models;
using Tyrrrz.Settings;

namespace Databvase_Winforms
{
    public class Settings : SettingsManager
    {
        public List<SavedConnection> SavedConnections = new List<SavedConnection>();
        public SavedConnection LastUsedSavedConnection = new SavedConnection();
        public string DefaultSkinName = "The Bezier";
        public string DefaultSvgPalette = string.Empty;
        public Color SavedSkinColor1 = Color.Empty;
        public Color SavedSkinColor2 = Color.Empty;
        public bool UseDirectX = false;
        public bool ShowRowNumberColumn = false;
        public int NumberOfRowsForTopSelectScript = 1000;
        public Font DefaultTextEditorFont = new Font("Tahoma", 8.25f);
        public Color NullGridCellColor = Color.Red;
        public string NullGridText = "[NULL]";
        public Color TextEditorBackgroundColor = Color.White;
        public Color TextEditorLineNumberColor = Color.DeepSkyBlue;
        public Color TextEditorDefaultColor = Color.Black;
        public Color TextEditorKeywordColor = Color.Blue;
        public Color TextEditorStringColor = Color.Red;
        public Color TextEditorCommentsColor = Color.Green;
        public bool ShowConnectionWindowOnStartup = true;


        public Settings()
        {
            Configuration.StorageSpace = StorageSpace.Instance;
            Configuration.FileName = "SettingsFile.json";
            Configuration.SubDirectoryPath = "Settings";
        }
    }
}