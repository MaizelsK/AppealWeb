using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFLibrary.Managers
{
    public class AppealManager
    {
        private ModelStateDictionary modelState;

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public AppealManager() { }

        public AppealManager(ModelStateDictionary modelState) { this.modelState = modelState; }

        public void Create(string theme, string text)
        {
            using (var db = new IdentityDbContext())
            {
                var existingAppeal = db.Appeals.FirstOrDefault(x => x.Theme == theme);

                if (existingAppeal != null)
                {
                    modelState.AddModelError("", "Обращение с такой темой уже существует");
                }
                else
                {
                    db.Appeals.Add(new Entities.Appeal
                    {
                        Theme = theme,
                        Text = text,
                        PublishDate = DateTime.Now,
                        UserId = AuthManager.User.Identity.GetUserId(),
                    });
                    db.SaveChanges();
                }
            }
        }

        public bool Delete(int id)
        {
            using (var db = new IdentityDbContext())
            {
                Entities.Appeal appeal = db.Appeals.Find(id);

                if (appeal != null)
                {
                    db.Appeals.Remove(appeal);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }
    }
}