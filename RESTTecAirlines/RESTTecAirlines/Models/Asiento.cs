using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RESTTecAirlines.Models
{
    public class Asiento
    {

        public string Categoria { get; set; }

        [Key]
        public int Numero { get; set; }


    }
}
