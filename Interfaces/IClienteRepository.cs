using SalaoApp.Models;
using System;
using System.Collections.Generic;

namespace SalaoApp.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IList<Cliente> ListarPorNome(string nomeCliente);
        IList<Cliente> ListarPorTelefone(string telefone);
        IList<Cliente> PopulaGrid(); //preenche a lista de cliente


    }
}