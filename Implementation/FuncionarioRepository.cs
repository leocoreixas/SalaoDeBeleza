using SalaoApp.Models;
using SalaoApp.Generics;
using SalaoApp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SalaoApp.Data;
using System;

namespace SalaoApp.Implementation
{
    public class FuncionarioRepository : AcessoDadosEntityFramework<Funcionario>, IFuncionarioRepository
    {

        public FuncionarioRepository(SalaoAppContext _contexto) : base(_contexto)
        {
        }

        public IList<Funcionario> ListarPorNome(string nomeFuncionario)
        {
            var listaNome = entidade.Where(f => f.Nome.Equals(nomeFuncionario));
            var listaPersonalizada = (from lista in listaNome
                                      select new Funcionario
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Telefone = lista.Telefone

                                      }).ToList();
            return listaPersonalizada;
        }

        public IList<Funcionario> ListarPorTelefone(string telefone)
        {
            telefone = telefone.Replace("[^0-9]", "");
            var listaTelefone = entidade.Where(f => f.Telefone.Equals(telefone));
            var listaPersonalizada = (from lista in listaTelefone
                                      select new Funcionario
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Telefone = lista.Telefone

                                      }).ToList();
            return listaPersonalizada;
        }

        public IList<Funcionario> PopulaGrid()
        {
            var listaPersonalizada = (from lista in ListarTodos()
                                      select new Funcionario
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Telefone = lista.Telefone

                                      }).ToList();
            return listaPersonalizada;

        }
    }
}
