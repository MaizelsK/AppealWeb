using DataAccessLibrary;
using Microsoft.AspNet.Identity;
using NHibernate;
using System.Threading.Tasks;

namespace FluentNhibernateLibrary.Stores
{
    public class FluentRoleStore : IRoleStore<Role>
    {
        private readonly ISession session;

        public FluentRoleStore(ISession session)
        {
            this.session = session;
        }

        #region IRoleStore
        public Task CreateAsync(Role role)
        {
            return Task.Run(() => session.SaveOrUpdate(role));
        }

        public Task DeleteAsync(Role role)
        {
            return Task.Run(() => session.Delete(role));
        }

        public void Dispose()
        {
            session.Dispose();
        }

        public Task<Role> FindByIdAsync(string roleId)
        {
            return Task.Run(() => session.Get<Role>(roleId));
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Task.Run(() =>
            {
                return session.QueryOver<Role>()
                    .Where(u => u.Name == roleName)
                    .SingleOrDefault();
            });
        }

        public Task UpdateAsync(Role role)
        {
            return Task.Run(() => session.SaveOrUpdate(role));
        }
        #endregion
    }
}
