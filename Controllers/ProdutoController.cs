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
    class ProdutoController : ControllerBase
    {
        private readonly SalaoAppContext _context;

        public ProdutoController(SalaoAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("produtos")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] SalaoAppContext context)
        {
            var produtos = await context.Produto.Include(x => x.Descricao).AsNoTracking().ToListAsync();
            return produtos;
        }

        [HttpPost]
        [Route("produto")]  //cria o produto
        public async Task<ActionResult<Produto>> Post(
                        [FromServices] SalaoAppContext context,
                        [FromBody] Produto model)
        {
            if (ModelState.IsValid)
            {
                context.Produto.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("produto/delete")]
        [HttpDelete]
        public async Task<ActionResult<Produto>> Delete(
                    [FromServices] SalaoAppContext context,
                    int id,
                    [FromBody] Produto produto)
        {

            context.Produto.Remove(produto);
            if (id != produto.Id)
                return NotFound(new { mensagem = "Produto apagado" });
            await context.SaveChangesAsync();
            return produto;
        }
    }
}