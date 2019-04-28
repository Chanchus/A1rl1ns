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
    public class EscalaController : ApiController
    {
        // GET: api/Escala
        [HttpGet]
        [Route("GetEscala")]
        public IEnumerable<Escala> Get()
        {

            return EscalaRepository.getAllEscalasFromDB();
        }

        // GET: api/Escala/5
        [HttpGet]
        [Route("GetEscala/{fecha}")]
        public Escala Get(int fecha)
        {
            return EscalaRepository.getEscalaFromDB(fecha);
        }

        // POST: api/Escala
        [HttpPost]
        [Route("SaveEscala")]
        public bool Post(Escala escala)
        {
            if (escala != null)
            {
                return EscalaRepository.addEscalaToDB(escala);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/Escala/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("DeleteEscala/{fecha}")]
        public bool Delete(int fecha)
        {
            return EscalaRepository.deleteEscalaFromDB(fecha);
        }
    }
}
