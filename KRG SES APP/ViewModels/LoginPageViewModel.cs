using KRG_SES_APP.Models.LoginSystem;
using KRG_SES_APP.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KRG_SES_APP.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand SubmitCommand { get; private set; }

        AuthenticationService authenticationService;
        private IPageService pageService;
        private string _memberNumber;
        public string MemberNumber
        {
            get => _memberNumber;
            set => SetValue(ref _memberNumber, value);
        }

        public LoginPageViewModel(AuthenticationService authenticationService, IPageService pageService)
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
