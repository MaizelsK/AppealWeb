using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Entities;

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

        public IEnumerable<Entity> GetList()
        {
            return Session.Query<Entity>().AsEnumerable().ToList();
        }

        #region Async methods
        public Task<Entity> FindByIdAsync(Key id)
        {
            return Session.GetAsync<Entity>(id);
        }

        public Task CreateAsync(Entity item)
        {
            return Session.SaveAsync(item);
        }

        public Task CreateAppealAsync(Appeal appeal, long userId)
        {
            appeal.User = Session.Get<User>(userId);

            return Session.SaveAsync(appeal);
        }

        public Task UpdateAsync(Entity item)
        {
            return Session.UpdateAsync(item);
        }

        public Task DeleteAsync(Entity item)
        {
            return Session.DeleteAsync(item);
        }
        #endregion

        #region Non-async methods
        public Entity FindById(Key id)
        {
            return Session.Get<Entity>(id);
        }

        public void Create(Entity item)
        {
            Session.BeginTransaction();
            Session.Save(item);
            Session.Transaction.Commit();
        }

        public void CreateAppeal(Appeal appeal, long userId)
        {
            appeal.User = Session.Get<User>(userId);

            Session.Save(appeal);
        }

        public void Update(Entity item)
        {
            Session.Update(item);
        }

        public void Delete(Entity item)
        {
            Session.BeginTransaction();
            Session.Delete(item);
            Session.Transaction.Commit();
        }
        #endregion

        public void Dispose()
        {
            if (Session.Transaction != null)
                Session.Transaction.Dispose();
        }
    }
}
