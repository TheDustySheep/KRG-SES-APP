using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KRGSESAPP.Models.LoginSystem
{
    public class LogInInfoModel
    {
        [PrimaryKey]
        public int ID { get; set; }
        public int MemberNumber { get; set; }
        public string FirstName { get; set; } = "Sean";
        public string LastName { get; set; } = "Edwards";
    }
}
