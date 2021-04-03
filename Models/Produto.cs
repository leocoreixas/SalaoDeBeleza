using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;


namespace SalaoApp.Models
{

    [Table("Produto")]
    public class Produto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(120)]
        public string Descricao { get; set; }
        public int QntdEstoque { get; set; }
        public double Valor { get; set; }
        public virtual Venda Venda { get; set; }
        public int VendaId { get; set; }
    }
}