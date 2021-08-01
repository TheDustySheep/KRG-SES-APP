using KRG_SES_APP.Services;
using KRG_SES_APP.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KRG_SES_APP.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        #region Bindings
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => SetValue(ref _firstName, value);
        }

        public ICommand AvailabilityClickedCommand { get; private set; }
        public ICommand AccountClickedCommand { get; private set; }
        public ICommand MessagesClickedCommand { get; private set; }
        public ICommand SettingsClickedCommand { get; private set; }
        public ICommand SignInClickedCommand { get; private set; }
        public ICommand LinksClickedCommand { get; private set; }
        public ICommand CreditsClickedCommand { get; private set; }
        public ICommand ReportBugsClickedCommand { get; private set; }
        public ICommand LogOutClickedCommand { get; private set; }
        #endregion

        AuthenticationService authenticationService;
        IPageService pageService;

        public HomePageViewModel(AuthenticationService authenticationService, IPageService pageService)
        {
            this.pageService = pageService;
            this.authenticationService = authenticationService;

            AvailabilityClickedCommand  = new Command(OnAvailability);
            AccountClickedCommand       = new Command(OnAccount);
            MessagesClickedCommand      = new Command(OnMessages);
            SettingsClickedCommand      = new Command(OnSettingsButtonClicked);
            SignInClickedCommand        = new Command(OnSignInButtonClicked);
            LinksClickedCommand         = new Command(OnLinksButtonClicked);
            CreditsClickedCommand       = new Command(OnCreditsButtonClicked);
            ReportBugsClickedCommand    = new Command(OnReportBugsButtonClicked);
            LogOutClickedCommand        = new Command(OnLogOut);
        }

        public async Task OnAppearing()
        {
            if (!await authenticationService.IsLoggedIn())
            {
                await pageService.PushModalAsync(new LoginPage(authenticationService));
            }

            FirstName = (await authenticationService.GetLogInInfo()).MemberNumber.ToString();
        }

        private async void OnAvailability()
        {
            await pageService.PushAsync(new AvailabilityPage(authenticationService, pageService));
        }

        private async void OnAccount()
        {
            await pageService.PushAsync(new AccountPage());
        }

        private async void OnMessages()
        {
            await pageService.PushAsync(new MessagesPage());
        }

        private async void OnSettingsButtonClicked()
        {
            await pageService.PushAsync(new SettingsPage());
        }

        private async void OnSignInButtonClicked()
        {
            await pageService.PushAsync(new SignInPage(authenticationService));
        }

        private async void OnLinksButtonClicked()
        {
            await pageService.PushAsync(new LinksPage());
        }

        private async void OnCreditsButtonClicked()
        {
            await pageService.PushAsync(new CreditsPage());
        }

        private async void OnReportBugsButtonClicked()
        {
            await pageService.PushAsync(new ReportBugsPage(pageService));
        }

        private async void OnLogOut()
        {
            await authenticationService.LogOut();

            await pageService.PushModalAsync(new LoginPage(authenticationService));
        }
    }
}
