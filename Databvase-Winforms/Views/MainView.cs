using System;
using System.Windows.Forms;
using Databvase_Winforms.Dialogs;
using Databvase_Winforms.Messages;
using Databvase_Winforms.Modules;
using Databvase_Winforms.Services;
using Databvase_Winforms.Services.Window_Dialog_Services;
using Databvase_Winforms.View_Models;
using DevExpress.LookAndFeel;
using DevExpress.Mvvm;
using DevExpress.Utils.Menu;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Ribbon;

namespace Databvase_Winforms.Views
{
    public partial class MainView : RibbonForm
    {
        public MainView()
        {
            InitializeComponent();
            RegisterServices();
            RegisterMessages();
            if (!mvvmContextMain.IsDesignMode)
                InitializeBindings();
            AddObjectExplorerToUi();
            HookupEvents();
        }


        private void AddObjectExplorerToUi()
        {
            objectExplorerContainer.Controls.Add(new ObjectExplorer {Dock = DockStyle.Fill});
        }

        private void HookupEvents()
        {
            UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            barButtonItemObjectExplorer.ItemClick += BarButtonItemObjectExplorerOnItemClick;
            tabbedViewMain.PopupMenuShowing += TabbedViewMainOnPopupMenuShowing;
            tabbedViewMain.DocumentActivated += TabbedViewMainOnDocumentActivated;
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<TabNameMessage>(this, typeof(TabNameMessage).Name, OnTabNameMessage);
        }

        private void RegisterServices()
        {
            MVVMContext.RegisterXtraDialogService();
            mvvmContextMain.RegisterService(new SettingsWindowService());
            mvvmContextMain.RegisterService(new TextEditorFontChangeService());
            mvvmContextMain.RegisterService(new ConnectionWindowService());
            mvvmContextMain.RegisterService(new QueryBuilderService());
            mvvmContextMain.RegisterService(new BackupViewService());
            mvvmContextMain.RegisterService(App.Skins);
            mvvmContextMain.RegisterService(SplashScreenService.Create(splashScreenManagerMainWait));

        }

        private void Default_StyleChanged(object sender, EventArgs e)
        {
            barButtonItemColorPalette.Visibility = LookAndFeel.ActiveSkinName == SkinStyle.Bezier
                ? BarItemVisibility.Always
                : BarItemVisibility.Never;
            App.Skins.SaveSkinSettings();
        }


        private void BarButtonItemObjectExplorerOnItemClick(object sender, ItemClickEventArgs itemClickEventArgs)
        {
            objectExplorerContainer.Panel.Show();
        }

        #region Tabbed Main View

        private void TabbedViewMainOnPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var menu = e.Menu;
            if (e.HitInfo.Document != null) menu.Items.Add(new DXMenuItem("Rename Tab", ShowRenameTabDialog));
        }

        private void ShowRenameTabDialog(object sender, EventArgs e)
        {
            using (var dialog = new RenameTabDialog { StartPosition = FormStartPosition.CenterParent })
            {
                dialog.ShowDialog();
            }
        }

        private void OnTabNameMessage(TabNameMessage message)
        {
            if (message != null)
            {
                tabbedViewMain.ActiveDocument.Caption = message.Name;
            }
        }

        private void TabbedViewMainOnDocumentActivated(object sender, DocumentEventArgs e)
        {
            
            MergeMainRibbon(e.Document.Control as QueryControl);
        }

        private void MergeMainRibbon(QueryControl queryControl)
        {
            if (queryControl != null) ribbonControlMain.MergeRibbon(queryControl.Ribbon);
        }

        #endregion


        #region MVVM Bindings

        private void InitializeBindings() 
        {
            var fluent = mvvmContextMain.OfType<MainViewModel>();
            BindEventToCommands(fluent);
            SetDataBindings(fluent);
            BindCommands(fluent);
            SetupTriggers(fluent);
        }

        private void BindEventToCommands(MVVMContextFluentAPI<MainViewModel> fluent)
        {
            fluent.EventToCommand<ItemClickEventArgs>(barButtonItemNewQuery, "ItemClick", x => x.AddBlankTab());
            fluent.EventToCommand<ItemClickEventArgs>(barButtonItemShowSettings, "ItemClick", x => x.ShowSettings());
            fluent.EventToCommand<EventArgs>(this, "Shown", x => x.CheckToShowConnectionsAtStartup());
        }

        private void SetDataBindings(MVVMContextFluentAPI<MainViewModel> fluent)
        {
            fluent.SetBinding(barEditItemTextEditorBG, x => x.EditValue, vm => vm.TextEditorBackgroundColor);
            fluent.SetBinding(barEditItemTextEditorLineNumberColor, x => x.EditValue, vm => vm.TextEditorLineNumberColor);
        }

        private void BindCommands(MVVMContextFluentAPI<MainViewModel> fluent)
        {
            fluent.BindCommand(barButtonItemTextEditorFontSettings, vm => vm.ShowTextEditorFontDialog());
            fluent.BindCommand(barButtonItemColorPalette, vm => vm.ShowBezierPaletteSwitcher());
            fluent.BindCommand(barButtonItemColorMixer, vm => vm.ShowColorMixer());
            fluent.BindCommand(barButtonItemConnect, vm => vm.Connect());
            fluent.BindCommand(barButtonItemDisconnect, vm => vm.Disconnect());
            fluent.BindCommand(barButtonItemQueryBuilder, vm => vm.ShowQueryBuilder());
            fluent.BindCommand(barButtonItemBackupWizard, vm => vm.ShowBackupWizard());

        }


        private void SetupTriggers(MVVMContextFluentAPI<MainViewModel> fluent)
        {
            fluent.SetTrigger(x => x.InstancesConnected, connectionsActive =>
            {
                if (connectionsActive)
                {
                    barButtonItemDisconnect.Visibility = BarItemVisibility.Always;
                    barButtonItemNewQuery.Visibility = BarItemVisibility.Always;
                    barButtonItemQueryBuilder.Visibility = BarItemVisibility.Always;
                    barButtonItemBackupWizard.Visibility = BarItemVisibility.Always;
                }
                else
                {
                    barButtonItemDisconnect.Visibility = BarItemVisibility.Never;
                    barButtonItemNewQuery.Visibility = BarItemVisibility.Never;
                    barButtonItemQueryBuilder.Visibility = BarItemVisibility.Never;
                    barButtonItemBackupWizard.Visibility = BarItemVisibility.Never;
                }
            });
        }

        #endregion
    }
}