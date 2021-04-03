using Microsoft.AspNetCore.Mvc;
using SalaoApp.Models;
using SalaoApp.Data;
using System.Linq;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;
using System.Web.Helpers;
using SalaoApp.Services;

namespace SalaoAppControllers
{
    [Route("api/v1")]
    public class UserController : ControllerBase
    {
        private readonly SalaoAppContext _context;

        public UserController(SalaoAppContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("user")]  //cria o usuario
        public async Task<ActionResult<Usuario>> Post(
            [FromServices] SalaoAppContext context,
            [FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                context.User.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("user")] // procura usuario, se nao existir cria um
        public async Task<ActionResult<Usuario>> Put(
                    [FromServices] SalaoAppContext context,
                    int id,
                    [FromBody] Usuario model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.Id)
                return NotFound(new { mensagem = "Usuário não encontrado" });

            try
            {
                context.Entry(model).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { mensagem = "Não foi possível criar o usuário" });
            }
        }

        [Route("user/delete")]
        [HttpDelete]
        public async Task<ActionResult<Usuario>> Delete(
                    [FromServices] SalaoAppContext context,
                    int id,
                    [FromBody] Usuario usuario)
        {

            context.User.Remove(usuario);
            if (id != usuario.Id)
                return NotFound(new { mensagem = "Usuário apagado" });
            await context.SaveChangesAsync();
            return usuario;
        }


    }

}

