using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KRG_SES_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnAvailabilityButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AvailabilityPage()));
        }

        private async void OnAccountButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AccountPage()));
        }

        private async void OnSettingsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new SettingsPage()));
        }
        
        private async void OnSignInButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new SignInPage()));
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}