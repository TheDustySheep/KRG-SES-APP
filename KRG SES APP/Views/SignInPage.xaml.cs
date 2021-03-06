using KRGSESAPP.Models.SignInSystem;
using KRGSESAPP.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KRGSESAPP.Extensions;
using System.Timers;
using KRGSESAPP.ViewModels;

namespace KRGSESAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        private readonly Catagory[] Catagories =
        {
            new Catagory() { Name = "Jobs" },
            new Catagory() { Name = "Training" },
            new Catagory() { Name = "Maintenance" },
            new Catagory() { Name = "Out Of Area" },
            new Catagory() { Name = "Administration" },
            new Catagory() { Name = "Social" },
        };

        public SignInPage(IAuthenticationService auth)
        {
            BindingContext = new SignInPageViewModel(new SignOnService(auth), new PageService());

            InitializeComponent();

            foreach (var cat in GetSignInCatagories())
            {
                SignInCatagoryPicker.Items.Add(cat.Name);
            }
        }

        protected override async void OnAppearing()
        {
            await (BindingContext as SignInPageViewModel).Initilize();
            base.OnAppearing();
        }

        private IList<Catagory> GetSignInCatagories() => Catagories;
    }
}