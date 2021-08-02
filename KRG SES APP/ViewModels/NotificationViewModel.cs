using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KRGSESAPP.ViewModels
{
    public class NotificationViewModel : BaseViewModel
    {
        #region Bindings
        public ICommand OnItemSelect;

        private string _title;
        public string Title
        {
            get => _title;
            set => SetValue(ref _title, value);
        }

        private string _body;
        public string Body
        {
            get => _body;
            set => SetValue(ref _body, value);
        }
        #endregion
    }
}
