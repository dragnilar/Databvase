using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using Databvase_Winforms.Views;

namespace Databvase_Winforms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            CheckSettings();
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            Application.Run(new MainView());
        }

        private static void CheckSettings()
        {
            if (File.Exists(App.Config.FullFilePath))
            {
                App.Config.Load();
            }
        }
    }

    public static class App
    {
        public static Settings Config = new Settings();
    }
}
