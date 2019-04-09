using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTTecAirlines.Models
{
    public class Pasajero
    {
        

        public string Nombre { get; set; }

        public string Pasaporte { get; set; }
        
        public int Reservacion { get; set; }

        public Boolean Tiquete { get; set; }

        public int CantidadMaletas { get; set; }

    }
}
