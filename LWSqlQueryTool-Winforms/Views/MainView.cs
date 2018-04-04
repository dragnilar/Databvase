﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.Customization;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ColorWheel;
using DevExpress.XtraRichEdit.API.Native;
using LWSqlQueryTool_Winforms.Modules;
using LWSqlQueryTool_Winforms.Services;
using LWSqlQueryTool_Winforms.View_Models;
using PopupMenuShowingEventArgs = DevExpress.XtraBars.Docking2010.Views.PopupMenuShowingEventArgs;

namespace LWSqlQueryTool_Winforms.Views
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private bool ConnectionActive = false;

        public MainView()
        {
            InitializeComponent();
            if (!mvvmContextMain.IsDesignMode)
                InitializeBindings();

            HookupEvents();
        }

        private void HookupEvents()
        {
            UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            barButtonItemColorMixer.ItemClick += barButtonItemColorMixer_ItemClick;
            barButtonItemColorPalette.ItemClick += barButtonItemColorPalette_ItemClick;
            barButtonItemNewQuery.ItemClick += BarButtonItemNewQueryOnItemClick;
            barButtonItemSaveQuery.ItemClick += BarButtonItemSaveQueryOnItemClick;
            barButtonItemConnect.ItemClick += BarButtonItemConnectOnItemClick;
            barButtonItemObjectExplorer.ItemClick += BarButtonItemObjectExplorerOnItemClick;
            barButtonItemRunQuery.ItemClick += BarButtonItemRunQueryOnItemClick;
            tabbedViewMain.QueryControl += TabbedViewMainOnQueryControl;
            tabbedViewMain.PopupMenuShowing += TabbedViewMainOnPopupMenuShowing;

        }

        private void BarButtonItemRunQueryOnItemClick(object sender, ItemClickEventArgs itemClickEventArgs)
        {
            //TODO send message to active guy to run query...?
        }

        private void BarButtonItemObjectExplorerOnItemClick(object sender, ItemClickEventArgs itemClickEventArgs)
        {
            objectExplorerContainer.Panel.Show();
        }

        private void BarButtonItemConnectOnItemClick(object sender, ItemClickEventArgs itemClickEventArgs)
        {
            //TODO - hacked shit here fix it jackass
            var window = new ConnectionStringView();
            window.StartPosition = FormStartPosition.CenterScreen;
            window.ShowDialog();
            window.Dispose();

            if (!string.IsNullOrEmpty(ConnectionStringService.CurrentConnectionString))
            {
                XtraMessageBox.Show("Connection Set");
                ribbonPageGroupQuery.Visible = true;
                objectExplorerContainer.Controls.Add(new ObjectExplorer { Dock = DockStyle.Fill });
            }
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
            //TODO add ability to rename here
            tabbedViewMain.ActiveDocument.Caption = "I am Renamed";
        }


        private void BarButtonItemSaveQueryOnItemClick(object sender, ItemClickEventArgs e)
        {
            var control = tabbedViewMain.ActiveDocument?.Control as QueryControl;

            control?.SaveQuery();
        }

        private void TabbedViewMainOnQueryControl(object sender, QueryControlEventArgs e)
        {
            e.Control = new QueryControl();
        }

        private void BarButtonItemNewQueryOnItemClick(object sender, ItemClickEventArgs e)
        {
            tabbedViewMain.AddDocument("Test Caption", "Test Name");
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
