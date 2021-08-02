using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KRGSESAPP.Models.SignInSystem
{
    public class CurrentAttendance
    {
        public int MemberID { get; set; }
        public string Catagory { get; set; }
        public DateTime StartTime { get; set; }

        public CurrentAttendance()
        {
            StartTime = DateTime.UtcNow;
        }
    }
}
