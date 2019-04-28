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
    public class AsientoController : ApiController
    {
        // GET: api/Asiento
        [HttpGet]
        [Route("GetAsiento")]
        public IEnumerable<Asiento> Get()
        {

            return AsientoRepository.getAllAsientosFromDB();
        }

        // GET: api/Asiento/5
        [HttpGet]
        [Route("GetAsiento/{numero}")]
        public Asiento Get(int numero)
        {
            return AsientoRepository.getAsientoFromDB(numero);
        }

        // POST: api/Asiento
        [HttpPost]
        [Route("SaveAsiento")]
        public bool Post(Asiento asiento)
        {
            if (asiento != null)
            {
                return AsientoRepository.addAsientoToDB(asiento);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/Asiento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("DeleteAsiento/{numero}")]
        public bool Delete(int numero)
        {
            return AsientoRepository.deleteAsientoFromDB(numero);
        }
    }
}
