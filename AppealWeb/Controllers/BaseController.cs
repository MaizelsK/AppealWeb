using EFLibrary;
using EFLibrary.Managers;
using FluentNhibernateLibrary;
using FluentNhibernateLibrary.Entities;
using FluentNhibernateLibrary.Services;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace AppealWeb.Controllers
{
    public abstract class BaseController : Controller
    {
        public AuthenticationService AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<AuthenticationService>();
            }
        }

        public UserService UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<UserService>();
            }
        }

        public AppealService AppealManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppealService>();
            }
        }

        public RoleService RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<RoleService>();
            }
        }
    }
}