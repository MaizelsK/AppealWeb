using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using EFLibrary.Managers;

namespace EFLibrary
{
    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            AppUserManager manager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            
            return new MvcHtmlString(manager.FindByIdAsync(id).Result.UserName);
        }
    }
}