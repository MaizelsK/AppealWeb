using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLibrary;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace EFLibrary.Managers
{
    public class AppUserManager : UserManager<User>, IRepository<User>
    {
        public AppUserManager(IUserStore<User> store) : base(store) { }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            IdentityDbContext db = context.Get<IdentityDbContext>();
            AppUserManager manager = new AppUserManager(new UserStore<User>(db));

            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = false
            };

            return manager;
        }

        public Task<User> FindByIdAsync(int id)
        {
            return FindByIdAsync(id);
        }

        public IEnumerable<User> GetList()
        {
            return Users;
        }

        Task IRepository<User>.CreateAsync(User user)
        {
            return CreateAsync(user);
        }

        Task IRepository<User>.DeleteAsync(User user)
        {
            return DeleteAsync(user);
        }

        Task IRepository<User>.UpdateAsync(User user)
        {
            return UpdateAsync(user);
        }
    }
}
