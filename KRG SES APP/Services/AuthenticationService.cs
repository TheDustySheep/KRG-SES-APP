using KRGSESAPP.Models.LoginSystem;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KRGSESAPP.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        SQLiteAsyncConnection connection;

        public AuthenticationService()
        {
            connection = DependencyService.Get<ISQLLiteDb>().GetConnection();
        }

        public async Task<bool> IsLoggedIn()
        {
            await connection.CreateTableAsync<LogInInfoModel>();

            var table = connection.Table<LogInInfoModel>();
            var query = table.Where(x => x.ID == 0);
            var result = await query.ToListAsync();

            return result.Count > 0;
        }

        public async Task LogIn(LogInInfoModel logInInfoModel)
        {
            await connection.CreateTableAsync<LogInInfoModel>();

            await connection.InsertOrReplaceAsync(logInInfoModel);
        }

        public async Task LogOut()
        {
            if (await IsLoggedIn())
                await connection.DeleteAsync(new LogInInfoModel());
        }

        public async Task<LogInInfoModel> GetLogInInfo()
        {
            await connection.CreateTableAsync<LogInInfoModel>();

            var table = connection.Table<LogInInfoModel>();
            var query = table.Where(x => x.ID == 0);
            var result = await query.ToListAsync();

            if (result.Count > 0)
                return result[0];
            else
                return new LogInInfoModel();
        }
    }
}
