using SalaoApp.Models;
using SalaoApp.Generics;
using SalaoApp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SalaoApp.Data;

namespace SalaoApp.Implementation
{
    public class ProdutoRepository : AcessoDadosEntityFramework<Produto>, IProdutoRepository
    {

        public ProdutoRepository(SalaoAppContext _contexto) : base(_contexto)
        {
        }

        public IList<Produto> ListarPorNome(string nomeProduto)
        {

            var listaNome = entidade.Where(c => c.Descricao.Equals(nomeProduto));

            var listaPersonalizada = (from lista in listaNome
                                      select new Produto
                                      {
                                          Id = lista.Id,
                                          Descricao = lista.Descricao,
                                          QntdEstoque = lista.QntdEstoque,
                                          Valor = lista.Valor

                                      }).ToList();

            return listaPersonalizada;
        }

        public IList<Produto> PopulaGrid()
        {

            var listaPersonalizada = (from lista in ListarTodos()
                                      select new Produto
                                      {
                                          Id = lista.Id,
                                          Descricao = lista.Descricao,
                                          QntdEstoque = lista.QntdEstoque,
                                          Valor = lista.Valor

                                      }).ToList();

            return listaPersonalizada;

        }
    }
}
