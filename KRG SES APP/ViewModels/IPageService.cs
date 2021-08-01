using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KRG_SES_APP.ViewModels
{
    public interface IPageService
    {
        Task DisplayAlert(string title, string message, string cancel);
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);

        Task PushAsync(Page page);
        Task PushModalAsync(Page page);
        Task PopAsync();
        Task PopModalAsync();
        Task PopToRootAsync();
    }
}
