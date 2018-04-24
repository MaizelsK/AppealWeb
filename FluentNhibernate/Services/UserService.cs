using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLibrary;
using Microsoft.AspNet.Identity;

namespace FluentNhibernateLibrary.Services
{
    public class UserService : UserManager<User, long>, IRepository<User>
    {
        public UserService(IUserStore<User, long> store) : base(store)
        {
            UserValidator = new UserValidator<User, long>(this)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = false
            };
        }

        public Task<User> FindByIdAsync(int id)
        {
            return this.FindByIdAsync(id);
        }

        public IEnumerable<User> GetList()
        {
            return this.Users;
        }

        Task IRepository<User>.CreateAsync(User user)
        {
            return this.CreateAsync(user);
        }

        Task IRepository<User>.DeleteAsync(User user)
        {
            return this.DeleteAsync(user);
        }

        Task IRepository<User>.UpdateAsync(User user)
        {
            return this.UpdateAsync(user);
        }
    }
}
