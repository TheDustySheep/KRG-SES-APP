using KRGSESAPP.Models;
using KRGSESAPP.Views;
using PCLStorage;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KRGSESAPP.Models.SignInSystem;
using KRGSESAPP.Services;
using KRGSESAPP.Models.AccountSystem;
using KRGSESAPP.ViewModels;

namespace KRGSESAPP
{
    public partial class App : Application
    {
        private const string UserProfileKey = "UserProfile";
        private const string UserSettingsKey = "UserSettings";
        private const string CurrentAttendanceKey = "CurrentAttendance";

        private const string UserDataFolder = "UserData";

        public App()
        {
            InitializeComponent();

            IAuthenticationService auth = new AuthenticationService();
            IPageService pageService = new PageService();

            MainPage = new NavigationPage(new HomePage(auth, pageService));

            //MainPage = new NavigationPage(new HomePage(auth, pageService));
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        public UserProfile UserProfile
        {
            get
            {
                if (Properties.ContainsKey(UserProfileKey))
                    return (UserProfile)Properties[UserProfileKey];

                return new UserProfile();
            }
            set
            {
                Properties[UserProfileKey] = value;
            }
        }

        public UserSettings UserSettings
        {
            get
            {
                if (Properties.ContainsKey(UserSettingsKey))
                    return (UserSettings)Properties[UserSettingsKey];

                return new UserSettings();
            }
            set
            {
                Properties[UserSettingsKey] = value;
            }
        }

        public CurrentAttendance CurrentAttendance
        {
            get
            {
                if (Properties.ContainsKey(CurrentAttendanceKey))
                    return (CurrentAttendance)Properties[CurrentAttendanceKey];

                return new CurrentAttendance();
            }
            set
            {
                Properties[CurrentAttendanceKey] = value;
            }
        }

        public async Task WriteUserData(string fileName, string data)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync(UserDataFolder,
                CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync($"{fileName}.txt",
                CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(data);
        }
    }
}
