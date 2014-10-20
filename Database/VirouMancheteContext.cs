using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using VirouManchete.Database.Framework.Interface;
using VirouManchete.Entidade;

namespace VirouManchete.Database
{
    public class VirouMancheteContext : DbContext, IUnitOfWork
    {
        public DbSet<Noticia> Usuarios { get; set; }

        public void Save()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw;
            }
        }
    }
}
