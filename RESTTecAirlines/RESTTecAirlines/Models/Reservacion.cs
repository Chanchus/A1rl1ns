using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTTecAirlines.Models
{
    public class Reservacion
    {
        [Key]
        public int Codigo { get; set; }

        public string Estado { get; set; }

        public int IdPropietario { get; set; }
    }
}
