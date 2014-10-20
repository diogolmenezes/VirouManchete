using System;
using System.Collections.Generic;
using System.Linq;
using VirouManchete.Database;
using VirouManchete.Database.Framework;
using VirouManchete.Database.Framework.Interface;
using VirouManchete.Entidade.Framework;
using VirouManchete.Negocio.Framework.Interface;

namespace VirouManchete.Negocio.Framework
{
    public class ServicoBase<T> : IServico<T> where T : DmgEntidade
    {
        IRepositorio<T> repositorio;

        public ServicoBase()
        {
            repositorio = new RepositorioBase<T>();
        }

        public T Carregar(object id)
        {
            return repositorio.Carregar(id);
        }

        public IQueryable<T> Filtrar()
        {
            return repositorio.Listar();
        }

        public IList<T> Listar()
        {
            return repositorio.Listar().ToList();
        }

        public void Incluir(T item)
        {
            item.Id = Guid.NewGuid().ToString().Replace("-", "");
            repositorio.Incluir(item);
        }

        public void Excluir(T item)
        {
            repositorio.Excluir(item);
        }

        public void Alterar(T item)
        {
            repositorio.Alterar(item);
        }

        public void Salvar()
        {
            repositorio.Salvar();
        }

        public void Dispose()
        {
            repositorio.Dispose();
        }
    }
}
