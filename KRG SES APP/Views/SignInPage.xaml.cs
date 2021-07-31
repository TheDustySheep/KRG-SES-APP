using KRG_SES_APP.Models.SignInSystem;
using KRG_SES_APP.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KRG_SES_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        private async void OnSignOut(object sender, EventArgs e)
        {
            await DisplayAlert("Signed Out", $"Successfully Signed Out", "Continue");

            await Navigation.PopAsync();
        }

        private async void OnSignIn(object sender, EventArgs e)
        {
            var attendance = new CurrentAttendance() { Catagory = "Jobs", MemberID = 40040170 };

            await FirestoreTools.AddDocument(attendance);

            await DisplayAlert("Signed In", $"Successfully Signed In", "Continue");
        }

        private void OnRefresh(object sender, EventArgs e)
        {
        }
    }
}