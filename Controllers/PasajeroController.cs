using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEST.Models;
using TEST.Repositories;

namespace TEST.Controllers
{
    public class PasajeroController : ApiController
    {
        // GET: api/Pasajero
        [HttpGet]
        [Route("GetPasajero")]
        public IEnumerable<Pasajero> Get()
        {

            return PasajeroRepository.getAllPasajerosFromDB();
        }

        // GET: api/Pasajero/5
        [HttpGet]
        [Route("GetPasajero/{pasaporte}")]
        public Pasajero Get(int pasaporte)
        {
            return PasajeroRepository.getPasajeroFromDB(pasaporte);
        }

        // POST: api/Pasajero
        [HttpPost]
        [Route("SavePasajero")]
        public bool Post(Pasajero pasajero)
        {
            if (pasajero != null)
            {
                return PasajeroRepository.addPasajeroToDB(pasajero);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/Pasajero/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("DeletePasajero/{pasaporte}")]
        public bool Delete(int pasaporte)
        {
            return PasajeroRepository.deletePasajeroFromDB(pasaporte);
        }
    }
}
