using DataAccessLibrary.Entities;
using DataAccessLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.EF
{
    public class EFRepository<Entity, Key> : IRepository<Entity, Key> where Entity : class
    {
        private IdentityDbContext Context { get; set; }

        public EFRepository()
        {
            Context = new IdentityDbContext();
        }

        public IEnumerable<Entity> GetList()
        {
            return Context.Set<Entity>().ToList();
        }

        #region Async methods
        public Task<Entity> FindByIdAsync(Key id)
        {
            return Context.Set<Entity>().FindAsync(id);
        }

        public Task CreateAsync(Entity item)
        {
            Context.Set<Entity>().Add(item);
            return Context.SaveChangesAsync();
        }

        public Task CreateAppealAsync(Appeal appeal, long userId)
        {
            appeal.User = Context.Users.SingleOrDefault(x => x.Id == userId);

            Context.Appeals.Add(appeal);
            return Context.SaveChangesAsync();
        }

        public Task UpdateAsync(Entity item)
        {
            Context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public Task DeleteAsync(Entity item)
        {
            Context.Set<Entity>().Remove(item);
            return Context.SaveChangesAsync();
        }
        #endregion

        #region Non-async methods
        public Entity FindById(Key id)
        {
            return Context.Set<Entity>().Find(id);
        }

        public void Create(Entity item)
        {
            Context.Set<Entity>().Add(item);
            Context.SaveChanges();
        }

        public void CreateAppeal(Appeal appeal, long userId)
        {
            appeal.User = Context.Users.SingleOrDefault(x => x.Id == userId);

            Context.Appeals.Add(appeal);
            Context.SaveChanges();
        }

        public void Update(Entity item)
        {
            Context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(Entity item)
        {
            Context.Set<Entity>().Remove(item);
            Context.SaveChanges();
        }
        #endregion

        public void Dispose()
        {
            if (Context.Database.CurrentTransaction != null
                && Context.Database.CurrentTransaction.UnderlyingTransaction == null)
                Context.Database.CurrentTransaction.Commit();
        }
    }
}
