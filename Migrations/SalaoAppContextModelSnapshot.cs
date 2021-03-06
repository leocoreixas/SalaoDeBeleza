// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalaoApp.Data;

namespace SalaoTeste.Migrations
{
    [DbContext(typeof(SalaoAppContext))]
    partial class SalaoAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("SalaoApp.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("ServicoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("ServicoId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("SalaoApp.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("SalaoApp.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Comissao")
                        .HasColumnType("REAL");

                    b.Property<string>("Nome")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("SalaoApp.Models.FuncionarioServico", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServicoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FuncionarioId", "ServicoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("FuncionarioServico");
                });

            modelBuilder.Entity("SalaoApp.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("FormaPagamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeCliente")
                        .HasColumnType("TEXT");

                    b.Property<double>("ValorRecebido")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("REAL");

                    b.Property<int>("VendaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VendaId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("SalaoApp.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<int>("QntdEstoque")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.Property<int>("VendaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VendaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("SalaoApp.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.Property<int>("VendaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("fidelidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VendaId");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("SalaoApp.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nomeUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("SalaoApp.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Desconto")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hora")
                        .HasColumnType("TEXT");

                    b.Property<double>("ValorDesconto")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("SalaoApp.Models.Agenda", b =>
                {
                    b.HasOne("SalaoApp.Models.Funcionario", "Funcionario")
                        .WithMany("Agendamentos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalaoApp.Models.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("SalaoApp.Models.Funcionario", b =>
                {
                    b.HasOne("SalaoApp.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SalaoApp.Models.FuncionarioServico", b =>
                {
                    b.HasOne("SalaoApp.Models.Funcionario", "Funcionario")
                        .WithMany("Servicos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalaoApp.Models.Servico", "Servico")
                        .WithMany("Funcionarios")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("SalaoApp.Models.Pagamento", b =>
                {
                    b.HasOne("SalaoApp.Models.Venda", "Venda")
                        .WithMany()
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("SalaoApp.Models.Produto", b =>
                {
                    b.HasOne("SalaoApp.Models.Venda", "Venda")
                        .WithMany("Produtos")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("SalaoApp.Models.Servico", b =>
                {
                    b.HasOne("SalaoApp.Models.Venda", "Venda")
                        .WithMany("Servicos")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("SalaoApp.Models.Venda", b =>
                {
                    b.HasOne("SalaoApp.Models.Funcionario", "Funcionario")
                        .WithMany("Vendas")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("SalaoApp.Models.Funcionario", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Servicos");

                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("SalaoApp.Models.Servico", b =>
                {
                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("SalaoApp.Models.Venda", b =>
                {
                    b.Navigation("Produtos");

                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}
