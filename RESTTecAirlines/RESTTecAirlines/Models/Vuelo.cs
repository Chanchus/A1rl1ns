using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTTecAirlines.Models
{
    public class Vuelo
    {
        public int CantMaletas { get; set; }

        public string Ruta { get; set; }
        public DateTime Fecha { get; set; }
        public string Destino { get; set; }

        public int PesoTotal { get; set; }

    }
}
