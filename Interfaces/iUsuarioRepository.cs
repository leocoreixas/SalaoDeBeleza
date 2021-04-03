using SalaoApp.Models;
using System.Collections.Generic;

namespace SalaoApp.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IList<Usuario> PopulaGrid(); // preenche informações do usuario
        IList<Usuario> BuscarPorNome(string nome);
    }


}
