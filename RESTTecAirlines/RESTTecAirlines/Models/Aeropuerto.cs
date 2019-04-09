using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTTecAirlines.Models
{
    public class Aeropuerto
    {

        [Key]
        public string Nombre { get; set; }

        public int CantidadAviones { get; set; }

        public string AsistenteVuelo { get; set; }

    }
}
