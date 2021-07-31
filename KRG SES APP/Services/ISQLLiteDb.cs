using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace KRG_SES_APP.Services
{
    public interface ISQLLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
