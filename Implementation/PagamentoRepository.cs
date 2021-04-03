using SalaoApp.Models;
using SalaoApp.Generics;
using SalaoApp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SalaoApp.Data;
using System;

namespace SalaoApp.Implementation
{
    public class PagamentoRepository : AcessoDadosEntityFramework<Pagamento>, IPagamentoRepository
    {



        public PagamentoRepository(SalaoAppContext _contexto) : base(_contexto)
        {
        }


        public List<Servico> PopulaServico()
        {
            List<Servico> listaServicos = new List<Servico>();

            Cliente cliente = new Cliente();
            cliente.Id = 1;
            cliente.Nome = "leonardo";
            cliente.Telefone = "021976644381";
            cliente.Email = "leonardocoreixas@hotmail.com";

            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            funcionario.Nome = "Karol";
            funcionario.Telefone = "021941474001";
            funcionario.Comissao = 60;

            Servico servico = new Servico();
            servico.Nome = "Corte Masculino";
            servico.Id = 1;
            servico.Valor = 30;

            Servico servico2 = new Servico();
            servico2.Nome = "Unha simples";
            servico2.Id = 2;
            servico2.Valor = 25;


            Servico servico3 = new Servico();
            servico3.Nome = "Venda";
            servico3.Id = 3;
            servico3.Valor = 30;

            listaServicos.Add(servico);
            listaServicos.Add(servico2);
            listaServicos.Add(servico3);

            return listaServicos;
        }

        public List<Produto> PopulaProduto()
        {
            List<Produto> listaProdutos = new List<Produto>();

            Produto produto = new Produto();
            produto.Id = 1;
            produto.Descricao = "Shampoo Cabelo 300ml";
            produto.QntdEstoque = 10;
            produto.Valor = 25;

            Produto produto2 = new Produto();
            produto2.Id = 2;
            produto2.Descricao = "Condicionador Cabelo 300ml";
            produto2.QntdEstoque = 10;
            produto2.Valor = 20;

            Produto produto3 = new Produto();
            produto3.Id = 3;
            produto3.Descricao = "Kit Cabelo";
            produto3.QntdEstoque = 10;
            produto3.Valor = 80;

            listaProdutos.Add(produto);
            listaProdutos.Add(produto2);
            listaProdutos.Add(produto3);

            return listaProdutos;
        }

        public double calculaDesconto(double auxValor, double valor, double porcentagem) // acertar promocao
        {

            double desconto = auxValor * porcentagem;
            valor = auxValor - desconto;
            return valor;
        }
        public double CartaFidelidade(double valor, Servico servico)
        {
            servico.fidelidade += 1;
            if (servico.fidelidade == 10)
            {
                valor = 0;
                servico.fidelidade = 0;
            }
            return servico.fidelidade;
        }
    }
}
