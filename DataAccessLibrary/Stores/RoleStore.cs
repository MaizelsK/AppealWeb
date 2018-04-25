using DataAccessLibrary.Entities;
using Microsoft.AspNet.Identity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Stores
{
    public class RoleStore : IRoleStore<Role>
    {
        private IRepository<Role, string> Repository { get; set; }

        public RoleStore()
        {
            Repository = RepositoryFactory.GetRepository<Role, string>();
        }

        #region IRoleStore
        public Task CreateAsync(Role role)
        {
            return Repository.CreateAsync(role);
        }

        public Task DeleteAsync(Role role)
        {
            return Repository.DeleteAsync(role);
        }

        public void Dispose()
        {
            Repository.Dispose();
        }

        public Task<Role> FindByIdAsync(string roleId)
        {
            return Repository.FindByIdAsync(roleId);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Task.Run(() =>
            {
                return Repository.GetList()
                .SingleOrDefault(x => x.Name == roleName);
            });
        }

        public Task UpdateAsync(Role role)
        {
            return Repository.UpdateAsync(role);
        }
        #endregion
    }
}
