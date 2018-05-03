using AppealWeb.Models;
using DataAccessLibrary.Entities;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppealWeb.Controllers
{
    public class UsersController : BaseController
    {
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.Username, Email = model.Email };

                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    AuthManager.SignInAsync(user, true, false);

                    return Json(new { IsSuccess = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string errorMessage = "";
                    foreach(var error in result.Errors)
                    {
                        errorMessage += error + "\n";
                    }

                    return Json(new { IsSuccess = false, ErrorMsg = errorMessage }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { IsSuccess = false, ErrorMsg = "Error!" });
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(long id)
        {
            User user = await UserManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Errors", new string[] { "Пользователь не найден" });
            }
        }
    }
}