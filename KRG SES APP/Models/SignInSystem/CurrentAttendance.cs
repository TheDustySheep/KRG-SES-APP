using System;
using System.Collections.Generic;
using System.Text;

namespace KRG_SES_APP.Models.SignInSystem
{
    public class CurrentAttendance
    {
        public DateTime StartTime;
        public AttendanceCatagory catagory;
        public TimeSpan CurrentTimeSpan => DateTime.Now - StartTime;
        public int Minutes => CurrentTimeSpan.Minutes;
        public double Hours => CurrentTimeSpan.TotalHours;
    }
}
