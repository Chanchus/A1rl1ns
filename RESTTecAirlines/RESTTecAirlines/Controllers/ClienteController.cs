using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTTecAirlines.Models;

namespace RESTTecAirlines.Controllers
{
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : ControllerBase
    {

        private readonly ApplicationDbContext context;


        public ClienteController(ApplicationDbContext context)
        {
            this.context = context;
        }



        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return context.Clientes.ToList();
        }


        [HttpGet("{id}", Name = "clienteCreado")]
        public IActionResult GetById(int id)
        {
            var cliente = context.Clientes.FirstOrDefault(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
                return new CreatedAtRouteResult("clienteCreado", new { id = cliente.Id }, cliente);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Cliente cliente, int id)
        {
            if(cliente.Id != id)
            {
                return BadRequest();
            }

            context.Entry(cliente).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = context.Clientes.FirstOrDefault(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return Ok(cliente);
        }


    }

}