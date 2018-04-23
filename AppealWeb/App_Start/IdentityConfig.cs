using AppealWeb.App_Start;
using FluentNhibernateLibrary.Services;
using FluentNhibernateLibrary;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(IdentityConfig))]
namespace AppealWeb.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            #region Entity Framework
            //app.CreatePerOwinContext<IdentityDbContext>(IdentityDbContext.Create);
            //app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            //app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);
            #endregion

            app.CreatePerOwinContext(() => new AppealService(new FNDataContext().Appeals));
            app.CreatePerOwinContext(() => new RoleService(new FNDataContext().Roles));
            app.CreatePerOwinContext(() => new UserService(new FNDataContext().Users));
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