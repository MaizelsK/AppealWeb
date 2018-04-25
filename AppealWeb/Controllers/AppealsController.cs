using System.Data;
using System.Web.Mvc;
using AppealWeb.Models;
using DataAccessLibrary;
using DataAccessLibrary.Entities;

namespace AppealWeb.Controllers
{
    [Authorize]
    public class AppealsController : BaseController
    {
        private IRepository<Appeal, int> repository;

        public AppealsController()
        {
            repository = RepositoryFactory.GetRepository<Appeal, int>();
        }

        public ActionResult Index(string returnUrl)
        {
            return View(repository.GetList());
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppealModel appeal)
        {
            repository.CreateAsync(new Appeal
            {
                Text = appeal.Text,
                Theme = appeal.Theme,
                User = AuthManager.GetAuthenticatedUser(RepositoryFactory.GetRepository<User, long>())
            });

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(appeal);
        }

        [HttpPost]
        public ActionResult Delete(Appeal appeal)
        {
            try
            {
                repository.DeleteAsync(appeal);
                return RedirectToAction("Index");
            }
            catch (DataException ex)
            {
                return View("Errors", new string[] { "Обращение не найдено" });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
