using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Customization;
using DevExpress.LookAndFeel;
using DevExpress.Mvvm;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ColorWheel;
using DevExpress.XtraRichEdit.API.Native;
using LWSqlQueryTool_Winforms.Dialogs;
using LWSqlQueryTool_Winforms.Messages;
using LWSqlQueryTool_Winforms.Modules;
using LWSqlQueryTool_Winforms.Services;
using LWSqlQueryTool_Winforms.View_Models;
using PopupMenuShowingEventArgs = DevExpress.XtraBars.Docking2010.Views.PopupMenuShowingEventArgs;

namespace LWSqlQueryTool_Winforms.Views
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int _numberOfQueries;

        public MainView()
        {
            InitializeComponent();
            if (!mvvmContextMain.IsDesignMode)
                InitializeBindings();
            SkinService.LoadSkinSettings();
            HookupEvents();
        }

        private void HookupEvents()
        {
            UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            barButtonItemColorMixer.ItemClick += barButtonItemColorMixer_ItemClick;
            barButtonItemColorPalette.ItemClick += barButtonItemColorPalette_ItemClick;
            barButtonItemNewQuery.ItemClick += BarButtonItemNewQueryOnItemClick;
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
            SkinService.SaveSkinSettings();
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

            if (!string.IsNullOrEmpty(ConnectionStringService.CurrentConnectionString))
            {
                objectExplorerContainer.Controls.Add(new ObjectExplorer { Dock = DockStyle.Fill });
            }
        }

        private void UpdateConnectionStatusOnUi()
        {
            if (ConnectionStringService.CurrentConnectionString != null)
            {
                barButtonItemDisconnect.Visibility = BarItemVisibility.Always;
                barButtonItemNewQuery.Visibility = BarItemVisibility.Always;
                barButtonItemConnect.Visibility = BarItemVisibility.Never;
            }
            else
            {
                if (tabbedViewMain.ActiveDocument != null)
                {
                    tabbedViewMain.ActiveDocument.Dispose();

                }

                tabbedViewMain.Documents.Clear();
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
            ConnectionStringService.CurrentConnectionString = null;
            objectExplorerContainer.Controls.Clear();
            UpdateConnectionStatusOnUi();
        }

        #region Tabbed Main View

        private void BarButtonItemNewQueryOnItemClick(object sender, ItemClickEventArgs e)
        {
            AddNewTab();
        }

        private void AddNewTab()
        {
            _numberOfQueries++;
            var caption = "Query " + _numberOfQueries;
            var name = "QueryTab" + _numberOfQueries;
            tabbedViewMain.AddDocument(caption, name);
            tabbedViewMain.Controller.Activate(tabbedViewMain.Documents.LastOrDefault());
        }

        private void TabbedViewMainOnPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var menu = e.Menu;
            if (e.HitInfo.Document != null)
            {
                menu.Items.Add(new DXMenuItem("Rename Tab", new EventHandler(RenameTab)));
            }
        }

        private void RenameTab(object sender, EventArgs e)
        {
            var renameTabDialog = new RenameTabDialog {StartPosition = FormStartPosition.CenterParent};
            var dialogResult = renameTabDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                tabbedViewMain.ActiveDocument.Caption = renameTabDialog.NewTabName;
            }
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




        private void MergeMainRibbon(QueryControl queryControl)
        {
            ribbonControlMain.MergeRibbon(queryControl.Ribbon);
        }


        #region Skin Goodness
        private void Default_StyleChanged(object sender, EventArgs e)
        {
            barButtonItemColorPalette.Visibility = LookAndFeel.ActiveSkinName == SkinStyle.Bezier ? BarItemVisibility.Always : BarItemVisibility.Never;
        }

        private void barButtonItemColorMixer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItemColorPalette_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var svgSkinSelector = new SvgSkinPaletteSelector(this))
            {
                svgSkinSelector.ShowDialog();
            }
        }
        #endregion  


        void InitializeBindings()
        {
            var fluent = mvvmContextMain.OfType<MainViewModel>();
        }
    }
}
