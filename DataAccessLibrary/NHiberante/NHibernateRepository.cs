using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.NHiberante
{
    public class NHibernateRepository<Entity> : IRepository<Entity> where Entity : class
    {
        private ISession Session { get; set; }

        public NHibernateRepository(ISession session) { Session = session; }

        public Task CreateAsync(Entity item)
        {
            return Session.SaveOrUpdateAsync(item);
        }

        public Task DeleteAsync(Entity item)
        {
            return Session.DeleteAsync(item);
        }

        public Task<Entity> FindByIdAsync(int id)
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
