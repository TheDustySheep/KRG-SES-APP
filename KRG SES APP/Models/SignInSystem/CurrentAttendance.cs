using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KRG_SES_APP.Models.SignInSystem
{
    public class CurrentAttendance
    {
        [Id]
        public int MemberID { get; set; }
        public string Catagory { get; set; }
        public DateTime StartTime { get; set; }

        public CurrentAttendance()
        {
            StartTime = DateTime.Now;
        }
    }
}
