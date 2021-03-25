using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App_ISSSTE.Models
{
    public class Pacientes
    {
       
        [PrimaryKey]
        public string id { get; set; }
        [MaxLength(255)]
        public string nombre { get; set; }
        [MaxLength(255)]
        public string edad { get; set; }
        [MaxLength(255)]
        public string RFC { get; set; }
        [MaxLength(255)]
        public string sexo { get; set; }
        [MaxLength(255)]
        public string tipo { get; set; }
        [MaxLength(255)]
        public string noissste { get; set; }
        [MaxLength(255)]
        public string celular { get; set; }
        [MaxLength(255)]
        public string telefono { get; set; }
        [MaxLength(255)]
        public string calle { get; set; }
        [MaxLength(255)]
        public string entidad { get; set; }
        [MaxLength(255)]
        public string cp { get; set; }
        [MaxLength(255)]
        public string referencias { get; set; }
        [MaxLength(255)]
        public string paciente_id { get; set; }
        [MaxLength(255)]
        public string nombres { get; set; }
        [MaxLength(255)]
        public string sexos { get; set; }
        [MaxLength(255)]
        public string telefonos { get; set; }
        [MaxLength(255)]
        public string celulares { get; set; }
        [MaxLength(255)]
        public string direccion { get; set; }
        [MaxLength(255)]
        public string entidades { get; set; }
        [MaxLength(255)]
        public string codigopostal { get; set; }
        [MaxLength(255)]
        public string referencia { get; set; }
        public string IsVisibl { get; set; }

        public Pacientes()
        {

        }
    }
}
