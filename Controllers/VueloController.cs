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
    public class VueloController : ApiController
    {
        // GET: api/Vuelo
        [HttpGet]
        [Route("GetVuelo")]
        public IEnumerable<Vuelo> Get()
        {

            return VueloRepository.getAllVuelosFromDB();
        }

        // GET: api/Vuelo/5
        [HttpGet]
        [Route("GetVuelo/{nombre}")]
        public Vuelo Get(string nombre)
        {
            return VueloRepository.getVueloFromDB(nombre);
        }

        // POST: api/Vuelo
        [HttpPost]
        [Route("SaveVuelo")]
        public bool Post(Vuelo Vuelo)
        {
            if (Vuelo != null)
            {
                return VueloRepository.addVueloToDB(Vuelo);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/Vuelo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("DeleteVuelo/{nombre}")]
        public bool Delete(string nombre)
        {
            return VueloRepository.deleteVueloFromDB(nombre);
        }
    }
}
