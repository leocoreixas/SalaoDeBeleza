using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaoApp.Models
{
    [Table("Servico")]
    public class Servico
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int fidelidade { get; set; }
        public virtual Venda Venda { get; set; }
        public int VendaId { get; set; }
        public virtual List<FuncionarioServico> Funcionarios { get; set; }
    }
}
