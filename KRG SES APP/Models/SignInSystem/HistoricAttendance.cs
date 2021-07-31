using System;
using System.Collections.Generic;
using System.Text;

namespace KRG_SES_APP.Models.SignInSystem
{
    public class HistoricAttendance
    {
        public int MemberID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TimeSpan => EndTime - StartTime;
        public string Catagory { get; set; }
    }
}
