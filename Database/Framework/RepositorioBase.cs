using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using VirouManchete.Database.Framework.Interface;

namespace VirouManchete.Database.Framework
{
    public class RepositorioBase<T> : IDisposable, IRepositorio<T> where T : class
    {
        private DbContext context;

        public RepositorioBase()
        {            
            context = ContextoFactory.CarregarContexto() as DbContext;
        }

        public T Carregar(object id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> Listar()
        {
            return context.Set<T>();
        }

        public void Incluir(T item)
        {
            context.Set<T>().Add(item);
        }

        public void Excluir(T item)
        {
            context.Set<T>().Remove(item);
        }

        public void Alterar(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Salvar()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }   
}
