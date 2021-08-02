using KRGSESAPP.Models.LoginSystem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KRGSESAPP.Services
{
    public interface IAuthenticationService
    {
        Task<bool> IsLoggedIn();
        Task LogIn(LogInInfoModel logInInfoModel);
        Task LogOut();
        Task<LogInInfoModel> GetLogInInfo();
    }
}
