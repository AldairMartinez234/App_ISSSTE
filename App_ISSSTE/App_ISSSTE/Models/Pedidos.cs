using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_ISSSTE.Models
{
    class Pedidos
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        [MaxLength(255)]
        public string entregados { get; set; }
        [MaxLength(255)]
        public string pacientes_id { get; set; }
        [MaxLength(255)]
        public string codigo_entrega { get; set; }

    }
}
