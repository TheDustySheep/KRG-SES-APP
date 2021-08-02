using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace KRGSESAPP.Services
{
    public interface ISQLLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
