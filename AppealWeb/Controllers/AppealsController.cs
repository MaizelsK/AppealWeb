﻿using System.Data;
using System.Web.Mvc;
using AppealWeb.Models;
using DataAccessLibrary;
using DataAccessLibrary.Entities;
using Microsoft.AspNet.Identity;
using System;
using DataAccessLibrary.Stores;

namespace AppealWeb.Controllers
{
    [Authorize]
    public class AppealsController : BaseController
    {
        private AppealStore appealStore;

        public AppealsController()
        {
            appealStore = new AppealStore();
        }

        public ActionResult Index(string returnUrl)
        {
            return View(appealStore.GetList());
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
            var userId = AuthManager.AuthenticationManager
                            .User.Identity.GetUserId<long>();

            appealStore.Create(new Appeal
            {
                Text = appeal.Text,
                Theme = appeal.Theme,
                PublishDate = DateTime.Now,
            }, userId);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(appeal);
        }

        [HttpPost]
        public ActionResult Delete(int appealId)
        {
            var appeal = appealStore.FindByIdAsync(appealId).Result;

            try
            {
                appealStore.Delete(appeal);
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
                appealStore.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
