using System.Data;
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

        [Authorize]
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
        public JsonResult Create(AppealModel appeal)
        {
            if (ModelState.IsValid) {
                var userId = AuthManager.AuthenticationManager
                                .User.Identity.GetUserId<long>();

                byte[] fileData = new byte[appeal.FileData.InputStream.Length];
                appeal.FileData.InputStream.Read(fileData, 0, (int)appeal.FileData.InputStream.Length);
                
                appealStore.Create(new Appeal
                {
                    Text = appeal.Text,
                    Theme = appeal.Theme,
                    PublishDate = DateTime.Now,
                    FileName = appeal.FileData.FileName,
                    FileData = fileData
                }, userId);

                return Json(new { IsSuccess = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { IsSuccess = false, ErrorMsg = "Ошибка, возможно введены некорректные данные" });
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
