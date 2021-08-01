using KRG_SES_APP.Models.AvailabilitySystem;
using KRG_SES_APP.Services;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KRG_SES_APP.ViewModels
{
    public class AvailabilityPageViewModel : BaseViewModel
    {
        private static readonly string AvailabilityCollection = "weeklyavailability";

        public ICommand OnSubmitCommand { get; private set; }
        public AvailabilityModel model;

        IPageService pageService;
        AuthenticationService auth;

        public AvailabilityPageViewModel(AvailabilityModel model, AuthenticationService auth, IPageService pageService)
        {
            this.model = model;
            this.auth = auth;
            this.pageService = pageService;

            OnSubmitCommand = new Command(OnSubmit);
        }

        private async void OnSubmit()
        {
            string MemberID = (await auth.GetLogInInfo()).MemberNumber.ToString();

            await CrossCloudFirestore.Current
                     .Instance
                     .Collection(AvailabilityCollection)
                     .Document("Availabilities")
                     .Collection("Current Week")
                     .Document(MemberID)
                     .SetAsync(model);

            await pageService.DisplayAlert("Successfully Submitted", "Submitted sucessfully", "Continue");

            await pageService.PopAsync();
        }
    }
}
