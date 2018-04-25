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

        public Task CreateAsync(Entity item)
        {
            Context.Set<Entity>().Add(item);
            return Context.SaveChangesAsync();
        }

        public Task DeleteAsync(Entity item)
        {
            Context.Set<Entity>().Remove(item);
            return Context.SaveChangesAsync();
        }

        public Task<Entity> FindByIdAsync(Key id)
        {
            return Context.Set<Entity>().FindAsync(id);
        }

        public IEnumerable<Entity> GetList()
        {
            return Context.Set<Entity>().ToList();
        }

        public Task UpdateAsync(Entity item)
        {
            Context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
