using SalaoApp.Models;
using SalaoApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SalaoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace SalaoApp.Generics
{
    public class AcessoDadosEntityFramework<T> : IRepository<T> where T : class
    {
        SalaoAppContext contexto = null;
        protected DbSet<T> entidade { get; } = null;

        public AcessoDadosEntityFramework(SalaoAppContext _contexto)
        {
            contexto = _contexto;
            entidade = contexto.Set<T>();
        }

        public void Adicionar(T model)
        {
            entidade.Add(model);
        }

        public void Atualizar(T model)
        {
            contexto.Entry(model).State = EntityState.Modified;
        }

        public T BuscarPorId(int id)
        {
            T model = entidade.Find(id);
            return model;
        }

        public void Excluir(T model)
        {
            entidade.Remove(model);
        }

        public void ExcluirPorId(int id)
        {
            T model = entidade.Find(id);
            entidade.Remove(model);
        }

        public List<T> ListarTodos()
        {
            return entidade.ToList();
        }

        public void Salvar()
        {
            contexto.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
