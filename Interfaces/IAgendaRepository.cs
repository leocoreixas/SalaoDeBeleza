using SalaoApp.Models;
using System;
using System.Collections.Generic;

namespace SalaoApp.Interfaces

{
    public interface IAgendaRepository : IRepository<Agenda>
    {
        List<string> PreencheListaHorarios(int inicio); // preenche o horario na agenda
        List<string> PopulaComboHora(DateTime diaSelecionado, string horaInicial); //preenche com horario na agenda
        IList<string> AtualizarHorario(string horaInicial, string horaFinal);
        IList<Agenda> BuscarPorNomeCliente(string nomeCliente);
        IList<Agenda> ListarPorDataColaborador(DateTime dataAgendamento, string colaborador);

    }
}
