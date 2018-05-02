using System.Windows.Forms;
using Databvase_Winforms.Views;
using DevExpress.Customization;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors.ColorWheel;

namespace Databvase_Winforms.Services
{
    public interface ISkinService
    {
        void ChangeBezierPalette();
        void ChangeColorSwatch();
    }
    /// <summary>
    /// This is a custom service that can be used to change skin settings in a DevExpress app
    /// </summary>
    public class SkinService : ISkinService
    {
        /// <summary>
        /// Displays the Bezier color palette switcher overlay, which allows the user to change the current Bezier palette.
        /// </summary>
        public void ChangeBezierPalette()
        {
            var mainWindow = new Form();
            foreach (Form window in Application.OpenForms)
                if (window is MainView)
                    mainWindow = window;

            if (!(mainWindow is MainView)) return;
            using (var palletteSelector = new SvgSkinPaletteSelector(mainWindow))
            {
                palletteSelector.ShowDialog();
            }
        }

        /// <summary>
        /// Displays the DevExpress color mixer, which allows the user to change the color masks for the current skin.
        /// </summary>
        public void ChangeColorSwatch()
        {
            using (var colorWheel = new ColorWheelForm())
            {
                colorWheel.StartPosition = FormStartPosition.CenterParent;
                colorWheel.BeginUpdate();
                colorWheel.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
                colorWheel.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
                colorWheel.EndUpdate();
                colorWheel.ShowDialog();
            }
        }

        /// <summary>
        /// Saves current skin settings for the app to the application settings file.
        /// </summary>
        public void SaveSkinSettings()
        {
            App.Config.DefaultSkinName = UserLookAndFeel.Default.SkinName;
            if (UserLookAndFeel.Default.SkinName == "The Bezier")
            {
                App.Config.DefaultSvgPalette = UserLookAndFeel.Default.ActiveSvgPaletteName;
                App.Config.Save();
            }

            App.Config.DefaultSvgPalette = UserLookAndFeel.Default.ActiveSvgPaletteName;
            App.Config.SavedSkinColor1 = UserLookAndFeel.Default.SkinMaskColor;
            App.Config.SavedSkinColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            App.Config.Save();
        }

        /// <summary>
        /// Loads the skin settings from the application settings and applies them to the app.
        /// </summary>
        public void LoadSkinSettings()
        {
            if (App.Config.DefaultSkinName == "The Bezier")
                UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Bezier, App.Config.DefaultSvgPalette);
            else
                UserLookAndFeel.Default.SkinName = App.Config.DefaultSkinName;

            UserLookAndFeel.Default.SkinMaskColor = App.Config.SavedSkinColor1;
            UserLookAndFeel.Default.SkinMaskColor2 = App.Config.SavedSkinColor2;
        }
    }
}