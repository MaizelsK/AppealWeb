using FluentNhibernateLibrary.Entities;
using Microsoft.AspNet.Identity;

namespace FluentNhibernateLibrary.Services
{
    public class UserService : UserManager<User, long>
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
    }
}
