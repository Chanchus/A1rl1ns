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
    public class MaletaController : ApiController
    {
        // GET: api/Maleta
        [HttpGet]
        [Route("GetMaleta")]
        public IEnumerable<Maleta> Get()
        {

            return MaletaRepository.getAllMaletasFromDB();
        }

        // GET: api/Maleta/5
        [HttpGet]
        [Route("GetMaleta/{codigoM}")]
        public Maleta Get(string codigoM)
        {
            return MaletaRepository.getMaletaFromDB(codigoM);
        }

        // POST: api/Maleta
        [HttpPost]
        [Route("SaveMaleta")]
        public bool Post(Maleta maleta)
        {
            if (maleta != null)
            {
                return MaletaRepository.addMaletaToDB(maleta);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/Maleta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("DeleteMaleta/{codigoM}")]
        public bool Delete(string codigoM)
        {
            return MaletaRepository.deleteMaletaFromDB(codigoM);
        }
    }
}
