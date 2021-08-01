using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KRG_SES_APP.Models.LoginSystem
{
    public class LogInInfoModel
    {
        [PrimaryKey]
        public int ID { get; set; }
        public int MemberNumber { get; set; }
    }
}
