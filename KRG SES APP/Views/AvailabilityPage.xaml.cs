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

            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            AddHeader(grid);

            AddRow(grid, "Mon", 1);
            AddRow(grid, "Tue", 2);
            AddRow(grid, "Wed", 3);
            AddRow(grid, "Thu", 4);
            AddRow(grid, "Fri", 5);
            AddRow(grid, "Sat", 6);
            AddRow(grid, "Sun", 7);
        }

        private void AddHeader(Grid grid)
        {
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Day"                 }, 0, 0);
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Morning\n6am-12pm"   }, 1, 0);
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Afternoon\n12pm-6pm" }, 2, 0);
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Evening\n6pm-11pm"   }, 3, 0);
            grid.Children.Add(new Label() { HorizontalOptions = LayoutOptions.Center, Text = "Overnight\n11pm-6am" }, 4, 0);
        }

        private void AddRow(Grid grid, string dayName, int row)
        {
            grid.Children.Add(new Label()  { Text = dayName }, 0, row);
            grid.Children.Add(GenerateCheckBox(0, row), 1, row);
            grid.Children.Add(GenerateCheckBox(1, row), 2, row);
            grid.Children.Add(GenerateCheckBox(2, row), 3, row);
            grid.Children.Add(GenerateCheckBox(3, row), 4, row);
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