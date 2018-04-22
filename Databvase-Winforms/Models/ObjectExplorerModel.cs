using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Databvase_Winforms.Annotations;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Models
{
    public class ObjectExplorerModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }
        public string ParentName { get; set; }
        public object Data { get; set; }
        public string InstanceName { get; set; }
        public int ImageIndex { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
