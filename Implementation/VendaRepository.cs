using SalaoApp.Models;
using SalaoApp.Generics;
using SalaoApp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SalaoApp.Data;
using System;

namespace SalaoApp.Implementation
{
    public class VendaRepository : AcessoDadosEntityFramework<Venda>, IVendaRepository
    {
        public VendaRepository(SalaoAppContext _contexto) : base(_contexto)
        {
        }

        public IEnumerable<Venda> ListTodasVendas()
        {
            return entidade.ToList().OrderBy(v => v.Data);
        }

        public IEnumerable<Venda> ListarPorIntervaloPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            var lista = entidade.Where(p => p.Data >= dataInicial && p.Data <= dataFinal).ToList();
            var listaPersonalizada = (from list in lista
                                      select new Venda
                                      {
                                          Id = list.Id,
                                          Data = list.Data,
                                          Hora = list.Hora,
                                          Produtos = list.Produtos,
                                          Servicos = list.Servicos,
                                          ValorTotal = list.ValorTotal

                                      }).ToList();

            return listaPersonalizada;
        }

        public IEnumerable<Venda> ListarPorFuncionario(string funcionario)
        {
            return entidade.Where(v => v.Funcionario.Equals(funcionario)).OrderBy(v => v.Data);
        }
        public IList<Venda> ListarPorData(DateTime data)
        {
            var lista = entidade.Where(p => p.Data == data);
            var listaPersonalizada = (from list in lista
                                      select new Venda
                                      {
                                          Id = list.Id,
                                          Data = list.Data,
                                          Hora = list.Hora,
                                          Produtos = list.Produtos,
                                          Servicos = list.Servicos,
                                          ValorTotal = list.ValorTotal

                                      }).ToList();
            return listaPersonalizada;
        }

        public dynamic RecuperaProdutosVendidosPorData(DateTime dataInicial, DateTime dataFinal)
        {
            var query = (from listaProdutos in entidade.Where(v => v.Produtos.Count > 0)
                         select new
                         {
                             produtos = listaProdutos.Produtos.FirstOrDefault().Descricao

                         }).OrderBy(p => p.produtos);
            return query;
        }
    }
}
