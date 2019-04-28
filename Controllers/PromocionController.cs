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
    public class PromocionController : ApiController
    {
        // GET: api/Promocion
        [HttpGet]
        [Route("GetPromocion")]
        public IEnumerable<Promocion> Get()
        {

            return PromocionRepository.getAllPromocionesFromDB();
        }

        // GET: api/Promocion/5
        [HttpGet]
        [Route("GetPromocion/{ruta}")]
        public Promocion Get(string ruta)
        {
            return PromocionRepository.getPromocionFromDB(ruta);
        }

        // POST: api/Promocion
        [HttpPost]
        [Route("SavePromocion")]
        public bool Post(Promocion Promocion)
        {
            if (Promocion != null)
            {
                return PromocionRepository.addPromocionToDB(Promocion);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/Promocion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("DeletePromocion/{ruta}")]
        public bool Delete(string ruta)
        {
            return PromocionRepository.deletePromocionFromDB(ruta);
        }
    }
}
