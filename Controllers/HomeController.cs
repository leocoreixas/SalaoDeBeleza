using Microsoft.AspNetCore.Mvc;
using SalaoApp.Models;
using SalaoApp.Data;
using System.Linq;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SalaoAppControllers
{
    [Route("api/v1")]
    public class HomeController : ControllerBase
    {
        private readonly SalaoAppContext _context;

        public HomeController(SalaoAppContext context)
        {
            _context = context;
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<dynamic>> GetUsuario([FromServices] SalaoAppContext context)
        {
            var usuario = new Usuario
            {
                Id = 20,
                nomeUsuario = "leonardo",
                Email = "leonardo@gmail.com",
                Senha = "123456"
            };

            context.User.Add(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }

    }

}

