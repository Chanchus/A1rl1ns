using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTTecAirlines.Models
{
    public class Maleta
    {
        [Key]
        public string Codigo { get; set; }
        public int Peso { get; set; }
        public int IdPropietario { get; set; }
        public string InfoU { get; set; }

    }
}
