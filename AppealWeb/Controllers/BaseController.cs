using DataAccessLibrary.Services;
using Microsoft.AspNet.Identity.Owin;
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

        public RoleService RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<RoleService>();
            }
        }
    }
}