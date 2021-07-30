using KRG_SES_APP.Models.SignInSystem;
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
    public partial class SignInPage : ContentPage
    {
        AttendanceCatagory[] catagories =
        {
            new AttendanceCatagory(){ Id = 1, Name = "Jobs"},
            new AttendanceCatagory(){ Id = 2, Name = "Training"},
            new AttendanceCatagory(){ Id = 3, Name = "Out Of Area"},
            new AttendanceCatagory(){ Id = 4, Name = "Public Relations"},
            new AttendanceCatagory(){ Id = 5, Name = "Social"},
            new AttendanceCatagory(){ Id = 6, Name = "Maintance"},
        };

        CurrentAttendance currentAttendance;

        public string activeCatagory => $"Catagory: {(currentAttendance == null ? new AttendanceCatagory() : currentAttendance.catagory).Name}";
        public string timeSpan => $"Time: {GetTimeSpanString()}";

        private string GetTimeSpanString()
        {
            DateTime start = currentAttendance == null ? DateTime.Now : currentAttendance.StartTime;
            TimeSpan span = DateTime.Now - start;

            return $"Hours: {span.TotalHours} Minutes: {span.Minutes} Seconds: {span.Seconds}";
        }

        private bool _loggedIn;
        public bool loggedIn
        {
            get => _loggedIn;
            set
            {
                _loggedIn = value;
                UpdateStacksVisible();
            }
        }

        public SignInPage()
        {
            InitializeComponent();

            loggedIn = false;

            foreach (var item in GetCatagories())
            {
                SignInCatagoryPicker.Items.Add(item.Name);
            }

            BindingContext = this;
        }

        private async void OnSignOut(object sender, EventArgs e)
        {
            loggedIn = false;

            await DisplayAlert("Signed Out", $"Successfully Signed Out", "Continue");

            await Navigation.PopAsync();
        }

        private async void OnSignIn(object sender, EventArgs e)
        {
            if (SignInInputsValid)
            {
                loggedIn = true;

                var catName = SignInCatagoryPicker.Items[SignInCatagoryPicker.SelectedIndex];
                var catagory = GetCatagories().Single(cat => cat.Name == catName);

                currentAttendance = new CurrentAttendance()
                {
                    catagory = catagory,
                    StartTime = DateTime.Now,
                };

                await DisplayAlert("Signed In", $"Successfully Signed In for {catagory.Name}", "Continue");

                await Navigation.PopAsync();
            }
        }

        private bool SignInInputsValid =>
            SignInCatagoryPicker.SelectedIndex >= 0;

        private void UpdateStacksVisible()
        {
            LoggedInStack.IsVisible = loggedIn;
            LoggedOutStack.IsVisible = !loggedIn;
        }

        private IList<AttendanceCatagory> GetCatagories()
        {
            return catagories;
        }
    }
}