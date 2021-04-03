using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalaoApp.Models;



namespace SalaoApp.Data
{
    public class SalaoAppContext : DbContext
    {
        public SalaoAppContext(DbContextOptions<SalaoAppContext> options)
        : base(options)
        {
        }
        public DbSet<Usuario> User { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<FuncionarioServico> FuncionarioServico { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Agenda> Agendamento { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuncionarioServico>()
                .HasKey(fs => new { fs.FuncionarioId, fs.ServicoId });
        }


    }
}

