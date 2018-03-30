using EFLibrary.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;

namespace EFLibrary.Managers
{
    public class AuthenticationManager
    {
        public IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public AppUserManager UserManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        public void SignIn(User user)
        {
            ClaimsIdentity ident = UserManager.CreateIdentity(user,
                                       DefaultAuthenticationTypes.ApplicationCookie);

            AuthManager.SignOut();
            AuthManager.SignIn(new AuthenticationProperties { IsPersistent = true }, ident);
        }
    }
}