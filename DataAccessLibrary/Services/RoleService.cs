using DataAccessLibrary.Entities;
using DataAccessLibrary.Stores;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public class RoleService : RoleManager<Role>
    {
        public RoleService(IRoleStore<Role, string> store) : base(store) { }

        public static RoleService Create(IdentityFactoryOptions<RoleService> options,
                                           IOwinContext context)
        {
            return new RoleService(new RoleStore());
        }
    }
}
