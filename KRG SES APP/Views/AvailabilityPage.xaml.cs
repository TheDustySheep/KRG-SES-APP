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

            var grid = new Grid();

            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 40 });

            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 40 });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 40 });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 40 });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 40 });

            AddRow(grid, "Mon", 0);
            AddRow(grid, "Tue", 1);
            AddRow(grid, "Wed", 2);
            AddRow(grid, "Thu", 3);
            AddRow(grid, "Fri", 4);
            AddRow(grid, "Sat", 5);
            AddRow(grid, "Sun", 6);

            GridView.Content = grid;
        }

        private void AddRow(Grid grid, string dayName, int row)
        {
            grid.Children.Add(new Label()  { Text = dayName }, 0, row);
            grid.Children.Add(new Button() { Command = new Command(() => DisplayAlert("TEST", "Message", "Cancel")) }, 1, row);
            grid.Children.Add(new Button() { }, 2, row);
            grid.Children.Add(new Button() { }, 3, row);
            grid.Children.Add(new Button() { }, 4, row);
            grid.Children.Add(new Label()  { Text = $"Comments" }, 5, row);
        }

        private async void BackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}