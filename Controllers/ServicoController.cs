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
    class ServicoController : ControllerBase
    {
        private readonly SalaoAppContext _context;

        public ServicoController(SalaoAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("servicos")]
        public async Task<ActionResult<List<Servico>>> Get([FromServices] SalaoAppContext context)
        {
            var servicos = await context.Servico.Include(x => x.Nome).AsNoTracking().ToListAsync();
            return servicos;
        }
        [HttpPost]
        [Route("servico")]  //cria o servico
        public async Task<ActionResult<Servico>> Post(
            [FromServices] SalaoAppContext context,
            [FromBody] Servico model)
        {
            if (ModelState.IsValid)
            {
                context.Servico.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [Route("servico/delete")]
        [HttpDelete]
        public async Task<ActionResult<Servico>> Delete(
                    [FromServices] SalaoAppContext context,
                    int id,
                    [FromBody] Servico servico)
        {

            context.Servico.Remove(servico);
            if (id != servico.Id)
                return NotFound(new { mensagem = "Serviço apagado" });
            await context.SaveChangesAsync();
            return servico;
        }
    }
}