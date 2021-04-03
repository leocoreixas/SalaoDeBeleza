using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SalaoApp.Models;

namespace SalaoApp.Models
{
    [Table("Venda")]
    public class Venda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "o campo 'Data' é obrigatório.")]
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public bool Desconto { get; set; } = false;
        public double ValorDesconto { get; set; } = 0;
        public double ValorTotal { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
        public virtual List<Produto> Produtos { get; set; }
        public virtual List<Servico> Servicos { get; set; }
    }
}
