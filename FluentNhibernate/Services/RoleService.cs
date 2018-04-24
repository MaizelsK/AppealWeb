using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLibrary;
using Microsoft.AspNet.Identity;

namespace FluentNhibernateLibrary.Services
{
    public class RoleService : RoleManager<Role>, IRepository<Role>
    {
        public RoleService(IRoleStore<Role, string> store) : base(store) { }

        public Task<Role> FindByIdAsync(int id)
        {
            return this.FindByIdAsync(id);
        }

        public IEnumerable<Role> GetList()
        {
            return this.Roles;
        }

        Task IRepository<Role>.CreateAsync(Role role)
        {
            return this.CreateAsync(role);
        }

        Task IRepository<Role>.DeleteAsync(Role role)
        {
            return this.DeleteAsync(role);
        }

        Task IRepository<Role>.UpdateAsync(Role role)
        {
            return this.UpdateAsync(role);
        }
    }
}
