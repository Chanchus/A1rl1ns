using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTTecAirlines.Models
{
    public class Cliente
    {


        [StringLength(30)]
        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        [Key]
        public int Carne { get; set; }


    }
}
