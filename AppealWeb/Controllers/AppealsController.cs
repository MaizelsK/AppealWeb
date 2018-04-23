using System.Data;
using System.Web.Mvc;
using AppealWeb.Models;
using FluentNhibernateLibrary.Entities;
using System.Collections.Generic;

namespace AppealWeb.Controllers
{
    [Authorize]
    public class AppealsController : BaseController
    {
        public ActionResult Index(string returnUrl)
        {
            return View(AppealManager.Store.Appeals);
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
            AppealManager.Create(appeal.Theme, appeal.Text, ModelState);

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
                AppealManager.Store.DeleteAsync(appeal);
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
                AppealManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
