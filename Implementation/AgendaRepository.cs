using SalaoApp.Models;
using SalaoApp.Generics;
using SalaoApp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SalaoApp.Data;
using System;

namespace SalaoApp.Implementation
{
    public class AgendaRepository : AcessoDadosEntityFramework<Agenda>, IAgendaRepository
    {
        List<string> listaHora = new List<string>();

        public AgendaRepository(SalaoAppContext _contexto) : base(_contexto)
        {
        }

        public List<string> PreencheListaHorarios(int inicio)
        {
            var hoje = DateTime.Now;
            var minutoHoje = hoje.Minute;
            var contadorMinutos = minutoHoje;
            var contadorHoras = inicio;

            for (int i = inicio; i < 21; i++)
            {
                if (contadorMinutos > 30)
                {
                    contadorHoras += 1;
                    listaHora.Add((contadorHoras) + ":" + "00");

                    if (contadorMinutos < 60)
                    {
                        contadorMinutos = 0;
                        contadorMinutos = 30;
                    }
                    listaHora.Add(contadorHoras + ":" + contadorMinutos);
                    contadorMinutos = minutoHoje;
                }
                else
                {
                    listaHora.Add(contadorHoras + ":" + "30");
                    contadorHoras += 1;
                    contadorMinutos = 0;
                    listaHora.Add(contadorHoras + ":" + contadorMinutos + "0");
                }
            }
            return listaHora;
        }

        public IList<string> AtualizarHorario(string horaInicial, string horaFinal)
        {
            int posHoraInicial = 0, posHoraFinal = 0;
            IList<Agenda> lista = ListarTodos().Where(a => a.Data.Equals(DateTime.Now.ToString())).ToList();

            int posRemovida = posHoraInicial;
            while (posHoraInicial <= posHoraFinal)
            {
                listaHora.RemoveAt(posRemovida);
                posHoraInicial++;
            }
            return listaHora;
        }


        public List<string> PopulaComboHora(DateTime diaSelecionado, string horaInicial)
        {
            List<string> listaHora;
            if (diaSelecionado.Date == DateTime.Now.Date)
            {
                listaHora = PreencheListaHorarios(DateTime.Now.Hour);
            }
            else
            {
                listaHora = PreencheListaHorarios(6);
            }
            return listaHora;
        }
        
        public IList<Agenda> BuscarPorNomeCliente(string nomeCliente)
        {
            var lista = this.ListarTodos().Where(a => a.NomeCliente.Contains(nomeCliente));

            var listaPersonalizada = (from list in lista
                                      select new Agenda
                                      {

                                          Id = list.Id,
                                          Data = list.Data,
                                          Funcionario = list.Funcionario,
                                          NomeCliente = list.NomeCliente,
                                          Horario = list.Horario,
                                          Servico = list.Servico

                                      }).ToList();

            return listaPersonalizada;
        }

        public IList<Agenda> ListarPorDataColaborador(DateTime dataAgendamento, string colaborador)
        {
            var lista = ListarTodos().Where(a => a
                .Data.Equals(dataAgendamento))
                .Where(a => a.Funcionario
                .Equals(colaborador))
                .ToList();
            var listaPersonalizada = (from list in lista
                                      select new Agenda
                                      {

                                          Id = list.Id,
                                          Data = list.Data,
                                          Funcionario = list.Funcionario,
                                          NomeCliente = list.NomeCliente,
                                          Horario = list.Horario,
                                          Servico = list.Servico
                                      }).ToList();
            return listaPersonalizada;

        }
    }
}
