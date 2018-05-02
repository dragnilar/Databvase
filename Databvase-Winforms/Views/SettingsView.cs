using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databvase_Winforms.Services;
using Databvase_Winforms.Services.Window_Dialog_Services;
using Databvase_Winforms.View_Models;
using DevExpress.XtraEditors;

namespace Databvase_Winforms.Views
{
    public partial class SettingsView : DevExpress.XtraEditors.XtraForm
    {
        public SettingsView()
        {
            InitializeComponent();
            if (!mvvmContextSettingsView.IsDesignMode)
                InitializeBindings();
            HookUpEvents();
            RegisterServices();
        }

        private void HookUpEvents()
        {
            fontEditDefaultFont.QueryPopUp += (sender, args) => args.Cancel = true; //Disables showing the popup window because we don't need to see it.
        }

        private void RegisterServices()
        {
            mvvmContextSettingsView.RegisterService(new FontDialogService());
        }

        void InitializeBindings()
        {
            var fluent = mvvmContextSettingsView.OfType<SettingsViewModel>();
            

            fluent.BindCommand(simpleButtonCancelSaveSettings, x=>x.Cancel());
            fluent.BindCommand(simpleButtonSaveSettings, x=>x.Save());
            fluent.EventToCommand<EventArgs>(fontEditDefaultFont, "Click", model => model.ShowFontDialog());

            fluent.SetBinding(colorPickEditDefaultTextColor, x => x.Color, vm => vm.DefaultTextColor);
            fluent.SetBinding(colorPickEditDefaultCommentColor, x => x.Color, vm => vm.DefaultCommentColor);
            fluent.SetBinding(colorPickEditDefaultKeywordColor, x => x.Color, vm => vm.DefaultKeywordColor);
            fluent.SetBinding(colorPickEditDefaultStringColor, x => x.Color, vm => vm.DefaultStringColor);
            fluent.SetBinding(fontEditDefaultFont, x => x.EditValue, x => x.DefaultFontName);
            fluent.SetBinding(checkEditShowRowNumberColumn, x => x.Checked, vm => vm.ShowRowNumberColumn);
            fluent.SetBinding(spinEditNumberOfRowsForTopScript, x => x.EditValue,
                vm => vm.NumberOfRowsForSelectTopScript);
            fluent.SetBinding(colorPickEditNullColor, x => x.Color, vm => vm.NullColor);
            fluent.SetBinding(textEditNullText, x => x.EditValue, vm => vm.NullText);
            fluent.SetTrigger(model => model.State, state =>
            {
                if (state == SettingsViewModel.WindowState.Close)
                {
                    Close();
                }
            });
        }
    }
}