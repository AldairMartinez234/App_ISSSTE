using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_ISSSTE.Models
{
   public class Users
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Rol { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }


        public Users()
        {

        }
    }
}
