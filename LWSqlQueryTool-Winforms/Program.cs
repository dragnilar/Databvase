using System;
using System.IO;
using System.Windows.Forms;
using Databvase_Winforms.Views;
using DevExpress.Skins;
using DevExpress.UserSkins;

namespace Databvase_Winforms
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
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
            if (File.Exists(App.Config.FullFilePath)) App.Config.Load();
        }
    }

    public static class App
    {
        public static Settings Config = new Settings();
    }
}