using KRG_SES_APP.Extensions;
using KRG_SES_APP.Models.AvailabilitySystem;
using KRG_SES_APP.Services;
using KRG_SES_APP.ViewModels;
using Plugin.CloudFirestore;
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
    public partial class AvailabilityPage : ContentPage
    {
        AvailabilityModel model;

        public AvailabilityPage(AuthenticationService auth, IPageService pageService)
        {
            model = new AvailabilityModel();

            BindingContext = new AvailabilityPageViewModel(model, auth, pageService);

            InitializeComponent();

            var grid = GridView;

            AddHeader(grid);

            AddRow(grid, 1, (x) => model.Mon_Day = x, (x) => model.Mon_Night = x, (x) => model.Mon_Comments = x, "Monday");
            AddRow(grid, 2, (x) => model.Tue_Day = x, (x) => model.Tue_Night = x, (x) => model.Tue_Comments = x, "Tueday");
            AddRow(grid, 3, (x) => model.Wed_Day = x, (x) => model.Wed_Night = x, (x) => model.Wed_Comments = x, "Wednesday");
            AddRow(grid, 4, (x) => model.Thu_Day = x, (x) => model.Thu_Night = x, (x) => model.Thu_Comments = x, "Thursday");
            AddRow(grid, 5, (x) => model.Fri_Day = x, (x) => model.Fri_Night = x, (x) => model.Fri_Comments = x, "Friday");
            AddRow(grid, 6, (x) => model.Sat_Day = x, (x) => model.Sat_Night = x, (x) => model.Sat_Comments = x, "Saturday");
            AddRow(grid, 7, (x) => model.Sun_Day = x, (x) => model.Sun_Night = x, (x) => model.Sun_Comments = x, "Sunday");

            GeneralComments.MaxLength = 1000;
            GeneralComments.TextChanged += (object sender, TextChangedEventArgs e) => model.General_Comments = e.NewTextValue;
        }

        private void AddHeader(Grid grid)
        {
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Weekday"}, 0, 0);
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Day"    }, 1, 0);
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Night"  }, 2, 0);
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Comments" }, 3, 0);
        }

        private void AddRow(Grid grid, int row, Action<bool> dayCheck, Action<bool> nightCheck, Action<string> commentCheck, string dayName)
        {
            grid.Children.Add(new Label()  { Text = dayName, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }, 0, row);
            grid.Children.Add(GenerateCheckBox(dayCheck), 1, row);
            grid.Children.Add(GenerateCheckBox(nightCheck), 2, row);
            grid.Children.Add(new Editor() { Placeholder = "Comments", MaxLength = 255 }, 3, row);
        }

        private View GenerateCheckBox(Action<bool> onChange)
        {
            CheckBox checkBox = new CheckBox()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            checkBox.CheckedChanged += (object sender, CheckedChangedEventArgs e) => onChange(e.Value);

            return checkBox;
        }
    }
}