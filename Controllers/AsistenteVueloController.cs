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
    public class AsistenteVueloController : ApiController
    {
        // GET: api/AsistenteVuelo
        [HttpGet]
        [Route("GetAsistenteVuelo")]
        public IEnumerable<AsistenteVuelo> Get()
        {

            return AsistenteVueloRepository.getAllAsistentesVueloFromDB();
        }

        // GET: api/AsistenteVuelo/5
        [HttpGet]
        [Route("GetAsistenteVuelo/{id}")]
        public AsistenteVuelo Get(string id)
        {
            return AsistenteVueloRepository.getAsistenteVueloFromDB(id);
        }

        // POST: api/AsistenteVuelo
        [HttpPost]
        [Route("SaveAsistenteVuelo")]
        public bool Post(AsistenteVuelo aeropuerto)
        {
            if (aeropuerto != null)
            {
                return AsistenteVueloRepository.addAsistenteVueloToDB(aeropuerto);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/AsistenteVuelo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("DeleteAsistenteVuelo/{id}")]
        public bool Delete(string id)
        {
            return AsistenteVueloRepository.deleteAsistenteVueloFromDB(id);
        }
    }
}
