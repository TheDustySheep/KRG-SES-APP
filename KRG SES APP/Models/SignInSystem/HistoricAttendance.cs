using System;
using System.Collections.Generic;
using System.Text;

namespace KRGSESAPP.Models.SignInSystem
{
    public class HistoricAttendance
    {
        public int MemberID { get; set; }
        public string Catagory { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public HistoricAttendance() { }
        public HistoricAttendance(CurrentAttendance currentAttendance)
        {
            MemberID  = currentAttendance.MemberID;
            Catagory  = currentAttendance.Catagory;
            StartTime = currentAttendance.StartTime;
            EndTime   = DateTime.UtcNow;
        }
    }
}
