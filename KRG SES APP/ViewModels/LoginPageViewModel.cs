using KRGSESAPP.Models.LoginSystem;
using KRGSESAPP.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KRGSESAPP.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand SubmitCommand { get; private set; }

        IAuthenticationService authenticationService;
        private IPageService pageService;
        private string _memberNumber;
        public string MemberNumber
        {
            get => _memberNumber;
            set => SetValue(ref _memberNumber, value);
        }

        public LoginPageViewModel(IAuthenticationService authenticationService, IPageService pageService)
        {
            this.authenticationService = authenticationService;
            this.pageService = pageService;

            SubmitCommand = new Command(Submit);
        }

        public async void Submit()
        {
            int MemberID;

            //Parse number
            try
            {
                MemberID = int.Parse(_memberNumber);
            }
            catch (Exception)
            {
                await pageService.DisplayAlert("Invalid Member Number", "Your member number must be a number", "Close");
                return;
            }

            //Check valid
            if (MemberID >= 40100000 || MemberID < 40000000)
            {
                await pageService.DisplayAlert("Invalid Member Number", "Your member number must be betwen 40000000 and 40099999", "Close");
                return;
            }

            await authenticationService.LogIn(new LogInInfoModel() { MemberNumber = MemberID });

            await pageService.PopModalAsync();
        }
    }
}
