using SalaoApp.Interfaces;
using SalaoApp.Models;
using System.Collections.Generic;

namespace SalaoApp.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IList<Produto> ListarPorNome(string nomeProduto);
        IList<Produto> PopulaGrid(); //metodo para criar informaçoes do produto
    }
}
