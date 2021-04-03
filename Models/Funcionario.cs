using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaoApp.Models
{
    [Table("Funcionario")]
    public class Funcionario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public double Comissao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public virtual List<FuncionarioServico> Servicos { get; set; }
        public virtual List<Agenda> Agendamentos { get; set; }
        public virtual List<Venda> Vendas { get; set; }
    }
}
