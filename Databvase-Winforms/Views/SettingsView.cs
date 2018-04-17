using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }

        void InitializeBindings()
        {
            var fluent = mvvmContextSettingsView.OfType<SettingsViewModel>();
            

            fluent.BindCommand(simpleButtonCancelSaveSettings, x=>x.Cancel());
            fluent.BindCommand(simpleButtonSaveSettings, x=>x.Save());

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