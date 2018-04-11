using System.Windows.Forms;
using Databvase_Winforms.Views;
using DevExpress.Customization;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors.ColorWheel;

namespace Databvase_Winforms.Services
{
    public class SkinService
    {
        public void ChangeBezierPalette()
        {
            var mainWindow = new Form();
            foreach (Form window in Application.OpenForms)
                if (window is MainView)
                    mainWindow = window;

            if (mainWindow is MainView)
                using (var palletteSelector = new SvgSkinPaletteSelector(mainWindow))
                {
                    palletteSelector.ShowDialog();
                }
        }

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