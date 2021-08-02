
using KRGSESAPP.Models;
using KRGSESAPP.Models.AccountSystem;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KRGSESAPP.Views
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