using SalaoApp.Models;
using System.Collections.Generic;

namespace SalaoApp.Interfaces
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        List<Servico> PopulaServico(); //preenche informações do servico
        List<Produto> PopulaProduto();// preenche informações do produto
        double calculaDesconto(double auxValor, double valor, double porcentagem);
        double CartaFidelidade(double valor, Servico servico);
    }
}
