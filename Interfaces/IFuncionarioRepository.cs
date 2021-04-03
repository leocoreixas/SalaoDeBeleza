using SalaoApp.Models;
using System.Collections.Generic;

namespace SalaoApp.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        IList<Funcionario> ListarPorNome(string nomeFuncionario);
        IList<Funcionario> ListarPorTelefone(string telefone);
        IList<Funcionario> PopulaGrid();
    }
}
