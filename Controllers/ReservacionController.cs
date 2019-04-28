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
    public class ReservacionController : ApiController
    {
        // GET: api/Reservacion
        [HttpGet]
        [Route("GetReservacion")]
        public IEnumerable<Reservacion> Get()
        {

            return ReservacionRepository.getAllReservacionesFromDB();
        }

        // GET: api/Reservacion/5
        [HttpGet]
        [Route("GetReservacion/{ID}")]
        public Reservacion Get(int ID)
        {
            return ReservacionRepository.getReservacionFromDB(ID);
        }

        // POST: api/Reservacion
        [HttpPost]
        [Route("SaveReservacion")]
        public bool Post(Reservacion Reservacion)
        {
            if (Reservacion != null)
            {
                return ReservacionRepository.addReservacionToDB(Reservacion);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/Reservacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("DeleteReservacion/{ID}")]
        public bool Delete(int ID)
        {
            return ReservacionRepository.deleteReservacionFromDB(ID);
        }
    }
}
