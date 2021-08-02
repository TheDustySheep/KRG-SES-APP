using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KRGSESAPP.ViewModels
{
    public class PageService : IPageService
    {
        Page MainPage => Application.Current.MainPage;

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task PushAsync(Page page) => await MainPage.Navigation.PushAsync(new NavigationPage(page));

        public async Task PushModalAsync(Page page) => await MainPage.Navigation.PushModalAsync(new NavigationPage(page));

        public async Task PopAsync() => await MainPage.Navigation.PopAsync();

        public async Task PopModalAsync() => await MainPage.Navigation.PopModalAsync();

        public async Task PopToRootAsync() => await MainPage.Navigation.PopToRootAsync();
    }
}
