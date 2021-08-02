using KRGSESAPP.Extensions;
using KRGSESAPP.Models.BugReportingSystem;
using KRGSESAPP.Services;
using KRGSESAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KRGSESAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportBugsPage : ContentPage
    {
        IPageService pageService;

        public ReportBugsPage(IPageService pageService)
        {
            InitializeComponent();
        }

        private async void OnSubmit(object sender, EventArgs e)
        {
            var report = new BugReportModel()
            {
                Header = EditorHeader.Text,
                Body = EditorBody.Text,
                Priority = PickerCatagory.SelectedItem.ToString()
            };

            await FirestoreTools.AddDocument("bugreports", report);

            await DisplayAlert(
                "Bug Report Sent Sucessfully", 
                "Thank you for helping to find bugs :)\nYour effort is really appreciated!", 
                "Continue");

            await pageService.PopAsync();
        }
    }
}