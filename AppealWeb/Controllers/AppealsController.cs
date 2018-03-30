using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppealWeb.Models;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using EFLibrary.Entities;
using EFLibrary.Managers;

namespace AppealWeb.Controllers
{
    [Authorize]
    public class AppealsController : BaseController
    {
        public ActionResult Index(string returnUrl)
        {
            return View(AppealManager.Appeals.ToList());
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
            var manager = new AppealManager(ModelState);
            manager.Create(appeal.Theme, appeal.Text);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(appeal);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Appeal appeal = AppealManager.Appeals.Find(id);

            if (appeal == null)
            {
                return HttpNotFound();
            }
            return View(appeal);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            AppealManager manager = new AppealManager();

            if (manager.Delete(id))
            {
                return RedirectToAction("Index");
            }

            return View("Errors", new string[] { "Обращение не найдено" });
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
