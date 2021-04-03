using SalaoApp.Models;
using SalaoApp.Generics;
using SalaoApp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SalaoApp.Data;
using System;

namespace SalaoApp.Implementation
{
    public class ClienteRepository : AcessoDadosEntityFramework<Cliente>, IClienteRepository
    {

        public ClienteRepository(SalaoAppContext _contexto) : base(_contexto)
        {
        }

        public IList<Cliente> PopulaGrid()
        {
            var listaPersonalizada = (from lista in ListarTodos()
                                      select new Cliente
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Email = lista.Email,
                                          Telefone = lista.Telefone

                                      }).ToList();
            return listaPersonalizada;
        }

        public IList<Cliente> ListarPorNome(string nomeCliente)
        {
            var listaNome = entidade.Where(c => c.Nome.Equals(nomeCliente.ToLower()));

            var listaPersonalizada = (from lista in listaNome
                                      select new Cliente
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Email = lista.Email,
                                          Telefone = lista.Telefone

                                      }).ToList();

            return listaPersonalizada;
        }

        public IList<Cliente> ListarPorTelefone(string telefone)
        {
            telefone = telefone.Replace("[^0-9]", "");
            var listaTelefone = entidade.Where(c => c.Telefone.Equals(telefone));
            var listaPersonalizada = (from lista in listaTelefone
                                      select new Cliente
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Email = lista.Email,
                                          Telefone = lista.Telefone
                                      }).ToList();
            return listaPersonalizada;
        }
    }
}
