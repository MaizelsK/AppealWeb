using DataAccessLibrary;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace FluentNhibernateLibrary.Services
{
    public class AuthenticationService : SignInManager<User, long>
    {
        public AuthenticationService(UserManager<User, long> userManager, IAuthenticationManager authenticationManager)
        : base(userManager, authenticationManager) { }

        public void SignOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
