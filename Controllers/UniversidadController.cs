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
    public class UniversidadController : ApiController
    {
        // GET: api/Universidad
        [HttpGet]
        [Route("GetUniversidad")]
        public IEnumerable<Universidad> Get()
        {

            return UniversidadRepository.getAllUniversidadesFromDB();
        }

        // GET: api/Universidad/5
        [HttpGet]
        [Route("GetUniversidad/{nombre}")]
        public Universidad Get(string nombre)
        {
            return UniversidadRepository.getUniversidadFromDB(nombre);
        }

        // POST: api/Universidad
        [HttpPost]
        [Route("SaveUniversidad")]
        public bool Post(Universidad Universidad)
        {
            if (Universidad != null)
            {
                return UniversidadRepository.addUniversidadToDB(Universidad);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/Universidad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("DeleteUniversidad/{nombre}")]
        public bool Delete(string nombre)
        {
            return UniversidadRepository.deleteUniversidadFromDB(nombre);
        }
    }
}
