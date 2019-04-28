using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEST.Models;
using TEST.Processors;
using TEST.Repositories;

namespace TEST.Controllers
{
    public class AeropuertoController : ApiController
    {
        // GET: api/Aeropuerto
        [HttpGet]
        [Route("GetAeropuerto")]
        public IEnumerable<Aeropuerto> Get()
        {

            return AeropuertoRepository.getAllAeropuertosFromDB();
        }

        // GET: api/Aeropuerto/5
        [HttpGet]
        [Route("GetAeropuerto/{nombre}")]
        public Aeropuerto Get(string nombre)
        {
            return AeropuertoRepository.getAeropuertoFromDB(nombre);
        }

        // POST: api/Aeropuerto
        [HttpPost]
        [Route("SaveAeropuerto")]
        public bool Post(Aeropuerto aeropuerto)
        {
            if (aeropuerto != null)
            {
                return AeropuertoRepository.addAeropuertoToDB(aeropuerto);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/Aeropuerto/5
        public void Put(int id, [FromBody]string value)
        {
        }


        [HttpDelete]
        [Route("DeleteAeropuerto/{nombre}")]
        public bool Delete(string nombre)
        {
            return AeropuertoRepository.deleteAeropuertoFromDB(nombre);
        }
    }
}
