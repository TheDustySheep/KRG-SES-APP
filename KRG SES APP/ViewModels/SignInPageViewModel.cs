using KRG_SES_APP.Models.SignInSystem;
using KRG_SES_APP.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace KRG_SES_APP.ViewModels
{
    public class SignInPageViewModel : BaseViewModel
    {
        #region Binding Data
        private string _selectedCatagory;
        public string SelectedCatagory
        {
            get => _selectedCatagory;
            set => SetValue(ref _selectedCatagory, value);
        }

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set => SetValue(ref _isLoggedIn, value);
        }

        private bool _isLoggedOut;
        public bool IsLoggedOut
        {
            get => _isLoggedOut;
            set => SetValue(ref _isLoggedOut, value);
        }

        private bool _signOnEnable;
        public bool SignOnEnable
        {
            get => _signOnEnable;
            set => SetValue(ref _signOnEnable, value);
        }

        private bool _signOutEnable;
        public bool SignOutEnable
        {
            get => _signOutEnable;
            set => SetValue(ref _signOutEnable, value);
        }

        private string _signedInTimeString;
        public string SignedInTimeString
        {
            get => _signedInTimeString;
            set => SetValue(ref _signedInTimeString, value);
        }

        private string _signedInTimeSpanString;
        public string SignedInTimeSpanString
        {
            get => _signedInTimeSpanString;
            set => SetValue(ref _signedInTimeSpanString, value);
        }

        private string _signedInCatagoryString;
        public string SignedInCatagoryString
        {
            get => _signedInCatagoryString;
            set => SetValue(ref _signedInCatagoryString, value);
        }
        #endregion

        public ICommand OnSignOutCommand { get; private set; }
        public ICommand OnSignInCommand { get; private set; }

        IPageService pageService;
        SignOnService signOnService;
        DateTime lastLoggedTime;

        public SignInPageViewModel(SignOnService signOnService, IPageService pageService)
        {
            this.pageService = pageService;
            this.signOnService = signOnService;

            signOnService.OnCurrentAttendanceChange += OnAttendanceUpdate;

            OnSignInCommand = new Command(SignIn);
            OnSignOutCommand = new Command(SignOut);

            IsLoggedOut = false;
            IsLoggedIn = false;

            Timer timer = new Timer(1000);
            timer.Elapsed += UpdateTimeSpan;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public async Task Initilize()
        {
            await signOnService.Initilize();
        }

        public async void SignIn()
        {
            if (string.IsNullOrEmpty(_selectedCatagory))
            {
                await pageService.DisplayAlert("No Catagory Selected", "Please select a catagory before submitting", "Close");
                return;
            }

            await signOnService.SignIn(_selectedCatagory);

            await pageService.DisplayAlert("Signed In", $"Successfully signed in for {_selectedCatagory}", "Close");

            await pageService.PopAsync();
        }

        public async void SignOut()
        {
            await signOnService.SignOut();

            await pageService.DisplayAlert("Signed Out Successfully", $"Successfully Signed Out", "Close");

            await pageService.PopAsync();
        }

        private void OnAttendanceUpdate(CurrentAttendance attendance)
        {
            IsLoggedIn = attendance != null;
            IsLoggedOut = !IsLoggedIn;

            if (IsLoggedOut)
                return;

            lastLoggedTime = attendance.StartTime;
            SignedInTimeString = string.Format("{0:hh:mm:ss tt}", lastLoggedTime.ToLocalTime());

            UpdateTimeSpan();

            SignedInCatagoryString = attendance.Catagory;
        }

        private void UpdateTimeSpan(object sender = null, ElapsedEventArgs args = null)
        {
            TimeSpan signedInTimeSpan = DateTime.UtcNow.Subtract(lastLoggedTime);
            SignedInTimeSpanString = $"{Math.Floor(signedInTimeSpan.TotalHours)}h {signedInTimeSpan.Minutes}m {signedInTimeSpan.Seconds}s";
        }
    }
}
