using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_ISSSTE.Models
{
   public class Municipio
    {

        [PrimaryKey]
        public int Id { get; set; }
        [MaxLength(255)]
        public string nombre { get; set; }
       
        public Municipio()
        {

        }
    }
}
