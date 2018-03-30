using System.Web.Mvc;

namespace AppealWeb.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }
    }
}