using Microsoft.AspNetCore.Mvc;
using SalaoApp.Models;
using SalaoApp.Data;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;

namespace SalaoAppControllers
{
    [Route("api/v1")]
    class ClienteController : ControllerBase
    {
        private readonly SalaoAppContext _context;

        public ClienteController(SalaoAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("clientes")]
        public async Task<ActionResult<List<Cliente>>> Get([FromServices] SalaoAppContext context)
        {
            var clientes = await context.Cliente.Include(x => x.Nome).AsNoTracking().ToListAsync();
            return clientes;
        }

        [HttpPost]
        [Route("cliente")]  //cria o cliente
        public async Task<ActionResult<Cliente>> Post(
            [FromServices] SalaoAppContext context,
            [FromBody] Cliente model)
        {
            if (ModelState.IsValid)
            {
                context.Cliente.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("cliente/delete")]
        [HttpDelete]
        public async Task<ActionResult<Cliente>> Delete(
                    [FromServices] SalaoAppContext context,
                    int id,
                    [FromBody] Cliente cliente)
        {
            context.Cliente.Remove(cliente);
            if (id != cliente.Id)
                return NotFound(new { mensagem = "Usuário apagado" });
            await context.SaveChangesAsync();
            return cliente;
        }


    }
}