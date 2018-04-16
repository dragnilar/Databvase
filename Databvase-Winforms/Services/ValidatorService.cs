using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM.Services;

namespace Databvase_Winforms.Services
{
    /// <summary>
    /// A support service that can be used for validation. Requires a service container object.
    /// </summary>
    public class ValidatorService : ISupportServices
    {
        public IServiceContainer ServiceContainer { get; }

        public ValidatorService(IServiceContainer serviceContainer)
        {
            ServiceContainer = serviceContainer;
        }

        private IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();

        public bool CheckErrors(List<string> errorMessageList)
        {
            if (!errorMessageList.Any())
            {
                return true;
            }

            var errorBuilder =
                new StringBuilder("There are errors, please review them below: \n");
            foreach (var error in errorMessageList) errorBuilder.AppendLine(error);
            MessageBoxService.ShowMessage(errorBuilder.ToString(), "Error(s) Creating Connection String",
                MessageButton.OK, MessageIcon.Error);

            return false;
        }


    }
}
