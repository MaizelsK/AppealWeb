using DataAccessLibrary;
using EFLibrary.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFLibrary.Managers
{
    public class AppRoleManager : RoleManager<Role>, IRepository<Role>
    {
        public AppRoleManager(IRoleStore<Role, string> store) : base(store) { }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options,
                                           IOwinContext context)
        {
            return new AppRoleManager(new RoleStore<Role>(context.Get<IdentityDbContext>()));
        }

        public Task<Role> FindByIdAsync(int id)
        {
            return FindByIdAsync(id);
        }

        public IEnumerable<Role> GetList()
        {
            return Roles;
        }

        Task IRepository<Role>.CreateAsync(Role role)
        {
            return CreateAsync(role);
        }

        Task IRepository<Role>.DeleteAsync(Role role)
        {
            return DeleteAsync(role);
        }

        Task IRepository<Role>.UpdateAsync(Role role)
        {
            return UpdateAsync(role);
        }
    }
}