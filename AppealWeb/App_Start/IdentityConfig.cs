using AppealWeb.App_Start;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using DataAccessLibrary.Entities;
using DataAccessLibrary.Services;
using DataAccessLibrary.Stores;

[assembly: OwinStartup(typeof(IdentityConfig))]
namespace AppealWeb.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new RoleService(new RoleStore()));
            app.CreatePerOwinContext(() => new UserService(new IdentityStore()));
            app.CreatePerOwinContext<AuthenticationService>((options, context) => 
                new AuthenticationService(context.GetUserManager<UserService>(), context.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}