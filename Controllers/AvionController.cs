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
    public class AvionController : ApiController
    {
        // GET: api/Avion
        [HttpGet]
        [Route("GetAvion")]
        public IEnumerable<Avion> Get()
        {

            return AvionRepository.getAllAvionesFromDB();
        }

        // GET: api/Avion/5
        [HttpGet]
        [Route("GetAvion/{id}")]
        public Avion Get(string id)
        {
            return AvionRepository.getAvionFromDB(id);
        }

        // POST: api/Avion
        [HttpPost]
        [Route("SaveAvion")]
        public bool Post(Avion avion)
        {
            if (avion != null)
            {
                return AvionRepository.addAvionToDB(avion);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/Avion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("DeleteAvion/{id}")]
        public bool Delete(string id)
        {
            return AvionRepository.deleteAvionFromDB(id);
        }
    }
}
