using SalaoApp.Models;
using System.Collections.Generic;

namespace SalaoApp.Interfaces
{
    public interface IServicoRepository : IRepository<Servico>
    {
        IList<Servico> BuscarPorNome(string nome);
    }
}
