using System;
using System.Linq;
using System.Windows.Forms;
using Databvase_Winforms.Dialogs;
using Databvase_Winforms.Modules;
using Databvase_Winforms.Services;
using Databvase_Winforms.View_Models;
using DevExpress.Customization;
using DevExpress.LookAndFeel;
using DevExpress.Mvvm;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.ColorWheel;

namespace Databvase_Winforms.Views
{
    public partial class MainView : RibbonForm
    {
        private int _numberOfQueries;

        public MainView()
        {
            InitializeComponent();
            if (!mvvmContextMain.IsDesignMode)
                InitializeBindings();
            App.Skins.LoadSkinSettings();
            HookupEvents();
        }

        private void HookupEvents()
        {
            UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            barButtonItemColorMixer.ItemClick += barButtonItemColorMixer_ItemClick;
            barButtonItemColorPalette.ItemClick += barButtonItemColorPalette_ItemClick;
            barButtonItemConnect.ItemClick += BarButtonItemConnectOnItemClick;
            barButtonItemObjectExplorer.ItemClick += BarButtonItemObjectExplorerOnItemClick;
            barButtonItemDisconnect.ItemClick += BarButtonItemDisconnectOnItemClick;


            tabbedViewMain.QueryControl += TabbedViewMainOnQueryControl;
            tabbedViewMain.PopupMenuShowing += TabbedViewMainOnPopupMenuShowing;
            tabbedViewMain.DocumentActivated += TabbedViewMainOnDocumentActivated;

            defaultLookAndFeelMain.LookAndFeel.StyleChanged += LookAndFeelOnStyleChanged;
        }

        private void LookAndFeelOnStyleChanged(object sender, EventArgs eventArgs)
        {
            App.Skins.SaveSkinSettings();
        }


        private void BarButtonItemObjectExplorerOnItemClick(object sender, ItemClickEventArgs itemClickEventArgs)
        {
            objectExplorerContainer.Panel.Show();
        }


        private void BarButtonItemConnectOnItemClick(object sender, ItemClickEventArgs itemClickEventArgs)
        {
            Gonnection();
        }

        private void Gonnection()
        {
            //TODO - hacked shit here fix it jackass
            var window = new ConnectionStringView {StartPosition = FormStartPosition.CenterScreen};
            window.ShowDialog();
            window.Dispose();
            UpdateConnectionStatusOnUi();

            if (App.Connection.CurrentConnection != null)
                objectExplorerContainer.Controls.Add(new ObjectExplorer {Dock = DockStyle.Fill});
        }

        private void UpdateConnectionStatusOnUi()
        {
            if (App.Connection.CurrentConnection != null)
            {
                barButtonItemDisconnect.Visibility = BarItemVisibility.Always;
                barButtonItemNewQuery.Visibility = BarItemVisibility.Always;
                barButtonItemConnect.Visibility = BarItemVisibility.Never;
            }
            else
            {
                tabbedViewMain.Controller.CloseAll();
                barButtonItemDisconnect.Visibility = BarItemVisibility.Never;
                barButtonItemNewQuery.Visibility = BarItemVisibility.Never;
                barButtonItemConnect.Visibility = BarItemVisibility.Always;
            }
        }

        private void BarButtonItemDisconnectOnItemClick(object sender, ItemClickEventArgs itemClickEventArgs)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            App.Connection.CurrentConnection = null;
            objectExplorerContainer.Controls.Clear();
            UpdateConnectionStatusOnUi();
        }


        private void MergeMainRibbon(QueryControl queryControl)
        {
            if (queryControl != null) ribbonControlMain.MergeRibbon(queryControl.Ribbon);
        }

        #region Tabbed Main View

        private void TabbedViewMainOnPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var menu = e.Menu;
            if (e.HitInfo.Document != null) menu.Items.Add(new DXMenuItem("Rename Tab", RenameTab));
        }

        private void RenameTab(object sender, EventArgs e)
        {
            var renameTabDialog = new RenameTabDialog {StartPosition = FormStartPosition.CenterParent};
            var dialogResult = renameTabDialog.ShowDialog();
            if (dialogResult == DialogResult.OK) tabbedViewMain.ActiveDocument.Caption = renameTabDialog.NewTabName;
            renameTabDialog.Dispose();
        }

        private void TabbedViewMainOnQueryControl(object sender, QueryControlEventArgs e)
        {
            e.Control = new QueryControl();
        }

        private void TabbedViewMainOnDocumentActivated(object sender, DocumentEventArgs e)
        {
            
            MergeMainRibbon(e.Document.Control as QueryControl);
        }

        #endregion


        #region Skin Goodness

        private void Default_StyleChanged(object sender, EventArgs e)
        {
            barButtonItemColorPalette.Visibility = LookAndFeel.ActiveSkinName == SkinStyle.Bezier
                ? BarItemVisibility.Always
                : BarItemVisibility.Never;
        }

        private void barButtonItemColorMixer_ItemClick(object sender, ItemClickEventArgs e)
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

        private void barButtonItemColorPalette_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var svgSkinSelector = new SvgSkinPaletteSelector(this))
            {
                svgSkinSelector.ShowDialog();
            }
        }

        #endregion


        private void InitializeBindings()
        {
            var fluent = mvvmContextMain.OfType<MainViewModel>();
            fluent.EventToCommand<ItemClickEventArgs>(barButtonItemNewQuery, "ItemClick", x => x.AddNewTab());
        }
    }
}