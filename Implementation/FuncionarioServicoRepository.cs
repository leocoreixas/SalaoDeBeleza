using SalaoApp.Models;
using SalaoApp.Generics;
using SalaoApp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SalaoApp.Data;
using System;


namespace SalaoApp.Implementation
{
    public class FuncionarioServicoRepository : AcessoDadosEntityFramework<FuncionarioServico>, IFuncionarioServicoRepository
    {
        public FuncionarioServicoRepository(SalaoAppContext _contexto) : base(_contexto)
        {
        }
    }
}
