
using KRG_SES_APP.Models;
using KRG_SES_APP.Models.AccountSystem;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KRG_SES_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        UserProfile userProfile;

        public AccountPage()
        {
            InitializeComponent();

            userProfile = (Application.Current as App).UserProfile;

            BindingContext = userProfile;
        }

        protected override void OnDisappearing()
        {
            (Application.Current as App).UserProfile = userProfile;
            base.OnDisappearing();
        }
    }
}