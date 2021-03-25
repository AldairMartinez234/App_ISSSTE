
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_ISSSTE.Interfaces
{
    public interface ISQLitePlatform
    {
        SQLiteConnection GetConnection();
    }
}

