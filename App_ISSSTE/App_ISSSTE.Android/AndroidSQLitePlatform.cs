
using App_ISSSTE.Interfaces;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(ISQLitePlatform))]

namespace App_ISSSTE.Droid
{
    public class AndroidSQLitePlatform : ISQLitePlatform
    {
        public SQLiteConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "control_issste.db3");
            return new SQLiteConnection(path);
        }
    }
}