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
    public class TiqueteController : ApiController
    {
        // GET: api/Tiquete
        [HttpGet]
        [Route("GetTiquete")]
        public IEnumerable<Tiquete> Get()
        {

            return TiqueteRepository.getAllTiquetesFromDB();
        }

        // GET: api/Tiquete/5
        [HttpGet]
        [Route("GetTiquete/{id}")]
        public Tiquete Get(int ID)
        {
            return TiqueteRepository.getTiqueteFromDB(ID);
        }

        // POST: api/Tiquete
        [HttpPost]
        [Route("SaveTiquete")]
        public bool Post(Tiquete Tiquete)
        {
            if (Tiquete != null)
            {
                return TiqueteRepository.addTiqueteToDB(Tiquete);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/Tiquete/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("DeleteTiquete/{id}")]
        public bool Delete(int ID)
        {
            return TiqueteRepository.deleteTiqueteFromDB(ID);
        }
    }
}
