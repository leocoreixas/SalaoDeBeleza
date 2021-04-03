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
    class PagamentoController : ControllerBase
    {
        private readonly SalaoAppContext _context;

        public PagamentoController(SalaoAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("pagamentos")]
        public async Task<ActionResult<List<Pagamento>>> Get([FromServices] SalaoAppContext context)
        {
            var pagamentos = await context.Pagamento.Include(x => x.Id).AsNoTracking().ToListAsync();
            return pagamentos;
        }

        [HttpPost]
        [Route("Pagamento")]  //cria o Pagamento
        public async Task<ActionResult<Pagamento>> Post(
                        [FromServices] SalaoAppContext context,
                        [FromBody] Pagamento model)
        {
            if (ModelState.IsValid)
            {
                context.Pagamento.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("pagamento/delete")]
        [HttpDelete]
        public async Task<ActionResult<Pagamento>> Delete(
                    [FromServices] SalaoAppContext context,
                    int id,
                    [FromBody] Pagamento pagamento)
        {
            context.Pagamento.Remove(pagamento);
            if (id != pagamento.Id)
                return NotFound(new { mensagem = "Pagamento apagado" });
            await context.SaveChangesAsync();
            return pagamento;
        }
    }
}