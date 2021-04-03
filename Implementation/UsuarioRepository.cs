using SalaoApp.Models;
using SalaoApp.Generics;
using SalaoApp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SalaoApp.Data;

namespace SalaoApp.Implementation
{
    public class UsuarioRepository : AcessoDadosEntityFramework<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SalaoAppContext _contexto) : base(_contexto)
        {
        }

        public IList<Usuario> BuscarPorNome(string nome)
        {
            var listaNome = entidade.ToList().Where(u => u.nomeUsuario.Equals(nome));
            var listaPersonalizada = (from lista in listaNome
                                      select new Usuario
                                      {
                                          Id = lista.Id,
                                          nomeUsuario = lista.nomeUsuario,
                                          Email = lista.Email

                                      }).ToList();

            return listaPersonalizada;
        }

        public IList<Usuario> PopulaGrid()
        {

            var listaPersonalizada = (from lista in ListarTodos()
                                      select new Usuario
                                      {
                                          Id = lista.Id,
                                          nomeUsuario = lista.nomeUsuario,
                                          Email = lista.Email

                                      }).ToList();

            return listaPersonalizada;

        }
    }
}
