using KRGSESAPP.Services;
using KRGSESAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KRGSESAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage(IAuthenticationService auth, IPageService pageService)
        {
            BindingContext = new HomePageViewModel(auth, pageService);

            InitializeComponent();

            NotificationViewModel[] notifications =
            {
                new NotificationViewModel() 
                { 
                    OnItemSelect = new Command(async () => await pageService.PushAsync(new SignInPage(auth))), 
                    Title = "Currently Signed In", 
                    Body = "1 hour 32 minutes" 
                },
                new NotificationViewModel() 
                {
                    OnItemSelect = new Command(async () => await pageService.PushAsync(new AvailabilityPage(auth, pageService))),
                    Title = "Weekly Availability", 
                    Body = "Remember to submit your weekly availability" 
                },
                new NotificationViewModel() 
                {
                    OnItemSelect = new Command(async () => await pageService.PushAsync(new CreditsPage())),
                    Title = "Test Notification", 
                    Body  = "Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification Test Notification"
                },
            };

            listViewNotifications.ItemsSource = notifications;
        }

        private void listViewNotifications_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            (e.Item as NotificationViewModel).OnItemSelect?.Execute(null);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await (BindingContext as HomePageViewModel).OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}