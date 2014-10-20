using System;
using System.Collections;
using System.Threading;
using System.Web;
using VirouManchete.Database.Framework.Interface;

namespace VirouManchete.Database.Framework
{
    public static class ContextoFactory 
    {
        private const string HTTPCONTEXTKEY = "PrimaryObjects.Repository.Base.HttpContext.Key";
        private static readonly Hashtable _threads = new Hashtable();        

        public static IUnitOfWork CarregarContexto()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items.Contains(HTTPCONTEXTKEY))
                    return (IUnitOfWork)HttpContext.Current.Items[HTTPCONTEXTKEY];

                return null;
            }
            else
            {
                Thread thread = Thread.CurrentThread;
                if (string.IsNullOrEmpty(thread.Name))
                {
                    thread.Name = Guid.NewGuid().ToString();
                    return null;
                }
                else
                {
                    lock (_threads.SyncRoot)
                    {
                        return (IUnitOfWork)_threads[Thread.CurrentThread.Name];
                    }
                }
            }
        }

        public static IUnitOfWork CriarContexto(IUnitOfWork unitOfWork)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items[HTTPCONTEXTKEY] = unitOfWork;
            }
            else
            {
                lock (_threads.SyncRoot)
                {
                    _threads[Thread.CurrentThread.Name] = unitOfWork;
                }
            }

            return unitOfWork;
        }
    }
}
