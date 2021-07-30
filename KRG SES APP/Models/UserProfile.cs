using System;
using System.Collections.Generic;
using System.Text;

namespace KRG_SES_APP.Models
{
    public class UserProfile
    {
        public string MemberID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Qualifications
        public bool Qual_General_JR { get; set; }
        public bool Qual_General_SWDO { get; set; }

        public bool Qual_Chainsaw_CC { get; set;}
        public bool Qual_Chainsaw_FELL { get; set;}

        public bool Qual_Drive_C { get; set;}
        public bool Qual_Drive_LR { get; set;}
        public bool Qual_Drive_KRG31 { get; set;}
        public bool Qual_Drive_DOV { get; set;}

        public bool Qual_Flood_A { get; set;}
        public bool Qual_Flood_1 { get; set;}
        public bool Qual_Flood_2 { get; set;}
        public bool Qual_Flood_3 { get; set;}

        public bool Qual_Rescue_PIARO { get; set;}
        public bool Qual_Rescue_VR { get; set;}
    }
}
