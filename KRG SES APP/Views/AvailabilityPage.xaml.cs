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
        public AvailabilityPage()
        {
            InitializeComponent();

            var grid = GridView;

            AddHeader(grid);

            AddRow(grid, "Monday", 1);
            AddRow(grid, "Tueday", 2);
            AddRow(grid, "Wednesday", 3);
            AddRow(grid, "Thursday", 4);
            AddRow(grid, "Friday", 5);
            AddRow(grid, "Saturday", 6);
            AddRow(grid, "Sunday", 7);
        }

        private void AddHeader(Grid grid)
        {
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Weekday"}, 0, 0);
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Day"    }, 1, 0);
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Night"  }, 2, 0);
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Comments" }, 3, 0);
        }

        private void AddRow(Grid grid, string dayName, int row)
        {
            grid.Children.Add(new Label()  { Text = dayName, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }, 0, row);
            grid.Children.Add(GenerateCheckBox(0, row), 1, row);
            grid.Children.Add(GenerateCheckBox(1, row), 2, row);
            grid.Children.Add(new Editor() { Placeholder = "Comments" }, 3, row);
        }

        private View GenerateCheckBox(int column, int row)
        {
            CheckBox checkBox = new CheckBox()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            //checkBox.CheckedChanged += async (object sender, CheckedChangedEventArgs e) => 
            //{
            //    await DisplayAlert("Clicked Checkbox", $"Col: {column}\nRow {row}", "Continue");
            //};
            return checkBox;
        }
    }
}