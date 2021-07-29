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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("SignOutReminderEnable"))
                signOutReminder.On = (bool)Application.Current.Properties["SignOutReminderEnable"];
        }

        private void OnSettingChange(object sender, ToggledEventArgs e)
        {
            Application.Current.Properties["SignOutReminderEnable"] = signOutReminder.On;

            Application.Current.SavePropertiesAsync();
        }
    }
}