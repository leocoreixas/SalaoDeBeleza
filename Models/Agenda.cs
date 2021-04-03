using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaoApp.Models
{
    [Table("Agendamento")]

    public class Agenda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public string NomeCliente { get; set; }
        [Required(ErrorMessage = "Insira uma data, por gentileza.")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Qual o horário de atendimento?")]
        public string Horario { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
        public virtual Servico Servico { get; set; }
        public int ServicoId { get; set; }
    }
}
