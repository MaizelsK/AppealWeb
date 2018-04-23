using AppealWeb.Models;
using FluentNhibernateLibrary.Entities;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppealWeb.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoggingUser loggingUser, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await UserManager.FindAsync(loggingUser.Username, loggingUser.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Неправильное имя пользователя или пароль");
                }
                else
                {
                    await AuthManager.SignInAsync(user, true, false);

                    if (returnUrl == null || returnUrl == "")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
            }

            return View(loggingUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}