using SalaoApp.Models;
using SalaoApp.Generics;
using SalaoApp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SalaoApp.Data;

namespace SalaoApp.Implementation
{
    public class ServicoRepository : AcessoDadosEntityFramework<Servico>, IServicoRepository
    {

        public ServicoRepository(SalaoAppContext _contexto) : base(_contexto)
        {
        }

        public IList<Servico> BuscarPorNome(string nome)
        {
            var listaNome = entidade.ToList().Where(s => s.Nome.Equals(nome));

            var listaPersonalizada = (from lista in listaNome
                                      select new Servico
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Valor = lista.Valor,
                                          Funcionarios = lista.Funcionarios

                                      }).ToList();

            return listaPersonalizada;
        }
    }
}
