using KRG_SES_APP.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KRG_SES_APP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AvailabilityPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
