using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Databvase_Winforms.Services;
using Databvase_Winforms.Views;
using DevExpress.Skins;
using DevExpress.UserSkins;
using ScintillaNET;

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
            Scintilla.SetDestroyHandleBehavior(true);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            CheckSettings();
            ToggleDirectX();
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            App.Skins.LoadSkinSettings();
            Application.Run(new MainView());
        }

        private static void CheckSettings()
        {
            if (File.Exists(App.Config.FullFilePath)) App.Config.Load();
        }

        private static void ToggleDirectX()
        {
            if (App.Config.UseDirectX)
            {
                DevExpress.XtraEditors.WindowsFormsSettings.ForceDirectXPaint();
            }
        }

        //TODO - See if this is actually feasible. This seems to cause display problems where the app doesn't use the default font.
        //TODO - Remove this.
        private static void ChangeFonts()
        {
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Comic Sans MS", 10);
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultMenuFont = new Font("Comic Sans MS", 10);
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultPrintFont = new Font("Comic Sans MS", 10);
        }
    }

    public static class App
    {
        public static readonly Settings Config = new Settings();
        public static readonly ConnectionService Connection = new ConnectionService();
        public static readonly SkinService Skins = new SkinService();
    }
}