using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTTecAirlines.Models
{
    public class Tiquete
    {
        [Key]
        public int Id { get; set; }

        public int Asiento { get; set; }


    }
}
