using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KRGSESAPP.Extensions
{
    public static class NavigationExtensions
    {
        public static INavigation Navigation;

        public static void RegisterHandler(INavigation navigation)
        {
            Navigation = navigation;
        }
    }
}
