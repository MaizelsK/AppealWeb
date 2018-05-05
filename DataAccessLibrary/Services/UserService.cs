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
    public class UserService : UserManager<User, long>
    {
        public UserService(IUserStore<User, long> store) : base(store) { }

        public static UserService Create(IdentityFactoryOptions<UserService> options, IOwinContext context)
        {
            UserService manager = new UserService(new IdentityStore());

            manager.UserValidator = new UserValidator<User, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            return manager;
        }
    }
}
