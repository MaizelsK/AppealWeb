using FluentNhibernateLibrary.Entities;
using Microsoft.AspNet.Identity;

namespace FluentNhibernateLibrary.Services
{
    public class RoleService : RoleManager<Role>
    {
        public RoleService(IRoleStore<Role, string> store) : base(store) { }
    }
}
