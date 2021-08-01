using KRG_SES_APP.Extensions;
using KRG_SES_APP.Models.LoginSystem;
using KRG_SES_APP.Services;
using KRG_SES_APP.ViewModels;
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
        public HomePage(AuthenticationService authenticationService, IPageService pageService)
        {
            BindingContext = new HomePageViewModel(authenticationService, pageService);

            InitializeComponent();
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