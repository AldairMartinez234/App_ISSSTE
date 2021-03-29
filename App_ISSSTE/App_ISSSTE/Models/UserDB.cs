using App_ISSSTE.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_ISSSTE.Models
{
   
    public class UserDB
    {
        readonly SQLiteAsyncConnection _SQLiteConnection;


        public UserDB(string dbPath)
        {
            _SQLiteConnection = new SQLiteAsyncConnection(dbPath);
            _SQLiteConnection.CreateTableAsync<Users>();
        }
        public Task<List<Users>> GetUsers()
        {
            return _SQLiteConnection.Table<Users>().ToListAsync();
        }
        public Task<Users> GetSpecificUser(int id)
        {
            return _SQLiteConnection.Table<Users>().FirstOrDefaultAsync(t => t.Id == id);
        }
        public void DeleteUser(int id)
        {
            _SQLiteConnection.DeleteAsync<Users>(id);
        }
        public string AddUser(Users user)
        {
            var d1 = _SQLiteConnection.QueryAsync<Users>("SELECT * FROM Users WHERE Email = ? ", user.Email);
            if (d1 == null)
            {
                _SQLiteConnection.InsertAsync(user);
                return "Añadido exitosamente";
            }
            else
            {
                return "Ya existe el mismo correo";
            }
        }

        public bool LoginValidate(string userName1, string pwd1)
        {
            var data = _SQLiteConnection.Table<Users>();
            var d1 = data.Where(x => x.Email == userName1 && x.Password == pwd1).FirstOrDefaultAsync();

            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
