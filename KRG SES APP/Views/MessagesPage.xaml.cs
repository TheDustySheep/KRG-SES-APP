using KRGSESAPP.Models.MessagingSystem;
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
    public partial class MessagesPage : ContentPage
    {
        MessageCatagory[] messageCatagories =
        {
            new MessageCatagory(){Name = "Urgent",       IconURL = "https://image.flaticon.com/icons/png/512/179/179386.png"},
            new MessageCatagory(){Name = "Regular",      IconURL = "https://static.thenounproject.com/png/52646-200.png"},
            new MessageCatagory(){Name = "Announcement", IconURL = "https://png.pngtree.com/png-vector/20190217/ourmid/pngtree-vector-announcement-icon-png-image_555639.jpg"},
            new MessageCatagory(){Name = "Social",       IconURL = "https://www.clipartmax.com/png/small/347-3470553_people-multiple-users.png"},
        };

        public MessagesPage()
        {
            InitializeComponent();

            var messages = new List<Message>
            {
                new Message(messageCatagories[0]){Header = "Tree Down",    Body = "Crew Needed"},
                new Message(messageCatagories[1]){Header = "Leaking Roof", Body = "Crew Needed"},
                new Message(messageCatagories[2]){Header = "Announcement", Body = "This is an annoucement"},
                new Message(messageCatagories[3]){Header = "Unit BBQ",     Body = "RSVP get in quick"},
                new Message(messageCatagories[0]){Header = "Tree Down",    Body = "Crew Needed"},
                new Message(messageCatagories[1]){Header = "Leaking Roof", Body = "Crew Needed"},
                new Message(messageCatagories[2]){Header = "Announcement", Body = "This is an annoucement"},
                new Message(messageCatagories[3]){Header = "Unit BBQ",     Body = "RSVP get in quick"},
            };

            listView.ItemsSource = messages;
        }
    }
}