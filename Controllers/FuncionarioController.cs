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
    class FuncionarioController : ControllerBase
    {
        private readonly SalaoAppContext _context;

        public FuncionarioController(SalaoAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("funcionarios")]
        public async Task<ActionResult<List<Funcionario>>> GetAll([FromServices] SalaoAppContext context)
        {
            var funcionarios = await context.Funcionario.Include(x => x.Nome).AsNoTracking().ToListAsync();
            return funcionarios;
        }

        [HttpPost]
        [Route("funcionario")]  //cria o funcionario
        public async Task<ActionResult<Funcionario>> Post(
            [FromServices] SalaoAppContext context,
            [FromBody] Funcionario model)
        {
            if (ModelState.IsValid)
            {
                context.Funcionario.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("funcionario/delete")]
        [HttpDelete]
        public async Task<ActionResult<Funcionario>> Delete(
                    [FromServices] SalaoAppContext context,
                    int id,
                    [FromBody] Funcionario funcionario)
        {
            context.Funcionario.Remove(funcionario);
            if (id != funcionario.Id)
                return NotFound(new { mensagem = "Funcionário apagado" });
            await context.SaveChangesAsync();
            return funcionario;
        }


    }
}