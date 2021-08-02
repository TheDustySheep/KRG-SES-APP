using System;
using System.Collections.Generic;
using System.Text;

namespace KRGSESAPP.Models.AvailabilitySystem
{
    public class AvailabilityModel
    {
        public bool Mon_Day { get; set; }
        public bool Tue_Day { get; set; }
        public bool Wed_Day { get; set; }
        public bool Thu_Day { get; set; }
        public bool Fri_Day { get; set; }
        public bool Sat_Day { get; set; }
        public bool Sun_Day { get; set; }

        public bool Mon_Night { get; set; }
        public bool Tue_Night { get; set; }
        public bool Wed_Night { get; set; }
        public bool Thu_Night { get; set; }
        public bool Fri_Night { get; set; }
        public bool Sat_Night { get; set; }
        public bool Sun_Night { get; set; }

        public string Mon_Comments { get; set; }
        public string Tue_Comments { get; set; }
        public string Wed_Comments { get; set; }
        public string Thu_Comments { get; set; }
        public string Fri_Comments { get; set; }
        public string Sat_Comments { get; set; }
        public string Sun_Comments { get; set; }

        public string General_Comments { get; set; }
    }
}
