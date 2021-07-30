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
        public string WelcomeText => $"Welcome {(Application.Current as App).UserProfile.FirstName}!";

        public HomePage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        private async void OnAvailabilityButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AvailabilityPage()));
        }

        private async void OnAccountButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AccountPage()));
        }

        private async void OnMessagesButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new MessagesPage()));
        }

        private async void OnSettingsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new SettingsPage()));
        }
        
        private async void OnSignInButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new SignInPage()));
        }

        private async void OnLinksButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new SignInPage()));
        }

        private async void OnCreditsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new Credits()));
        }

        private async void OnReportBugsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new SignInPage()));
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}