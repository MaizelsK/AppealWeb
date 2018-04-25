using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.NHiberante
{
    public class NHibernateRepository<Entity, Key> : IRepository<Entity, Key> where Entity : class
    {
        private ISession Session { get; set; }

        public NHibernateRepository()
        {
            var newSession = new NHibernateContext().MakeSession();
            Session = newSession;
        }

        public Task CreateAsync(Entity item)
        {
            return Session.SaveOrUpdateAsync(item);
        }

        public Task DeleteAsync(Entity item)
        {
            return Session.DeleteAsync(item);
        }

        public Task<Entity> FindByIdAsync(Key id)
        {
            return Session.GetAsync<Entity>(id);
        }

        public IEnumerable<Entity> GetList()
        {
            return Session.CreateCriteria<Entity>().List() as IEnumerable<Entity>;
        }

        public Task UpdateAsync(Entity item)
        {
            return Session.SaveOrUpdateAsync(item);
        }

        public void Dispose()
        {
            Session.Dispose();
        }
    }
}
