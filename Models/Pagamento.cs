using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalaoApp.Models
{
    [Table("Pagamento")]
    public class Pagamento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string FormaPagamento { get; set; }
        public double ValorTotal { get; set; }
        public double ValorRecebido { get; set; }
        [Required(ErrorMessage = "O campo 'Data Pagamento' é obrigatório.")]
        public DateTime DataPagamento { get; set; }
        public virtual Venda Venda { get; set; }
        public int VendaId { get; set; }
    }
}
