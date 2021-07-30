using System;
using System.Collections.Generic;
using System.Text;

namespace KRG_SES_APP.Models.SignInSystem
{
    public class HistoricAttendance
    {
        public DateTime StartTime;
        public DateTime EndTime;
        public TimeSpan TimeSpan => EndTime - StartTime;
    }
}
