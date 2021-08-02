using KRGSESAPP.Extensions;
using KRGSESAPP.Models.LoginSystem;
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
    public partial class OldHomePage : ContentPage
    {
        public OldHomePage(AuthenticationService authenticationService, IPageService pageService)
        {
            BindingContext = new OldHomePageViewModel(authenticationService, pageService);

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await (BindingContext as OldHomePageViewModel).OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}