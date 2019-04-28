 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEST.Models;
using TEST.Processors;
using TEST.Repositories;

namespace TEST.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        [HttpGet]
        [Route("GetCliente")]
        public IEnumerable<Cliente> Get()
        {

            return ClienteRepository.getAllClientesFromDB();
        }

        // GET: api/Cliente/5
        [HttpGet]
        [Route("GetCliente/{correo}")]
        public Cliente Get(string pasaporte)
        {
            return ClienteRepository.getClienteFromDB(pasaporte);
        }

        // POST: api/Cliente
        [HttpPost]
        [Route("SaveCliente")]
        public bool Post(Cliente cliente)
        {
            if (cliente != null)
            {
                return ClienteProcessor.ProcessCliente(cliente);
            }
            else
            {
                return false;
            }


        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("DeleteCliente/{correo}")]
        public bool Delete(string pasaporte)
        {
            return ClienteRepository.deleteClienteFromDB(pasaporte);
        }
    }
}
