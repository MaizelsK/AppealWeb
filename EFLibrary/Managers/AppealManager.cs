using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EFLibrary.Managers
{
    public class AppealManager : IRepository<Appeal>
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

        public Task CreateAsync(Appeal appeal)
        {
            using (var db = new IdentityDbContext())
            {
                var existingAppeal = db.Appeals.FirstOrDefault(x => x.Theme == appeal.Theme);

                if (existingAppeal != null)
                {
                    modelState.AddModelError("", "Обращение с такой темой уже существует");
                }
                else
                {
                    db.Appeals.Add(new Appeal
                    {
                        Theme = appeal.Theme,
                        Text = appeal.Text,
                        PublishDate = DateTime.Now,
                        User = db.Users
                        .SingleOrDefault(x => x.Id == long.Parse(AuthManager.User.Identity.GetUserId()))
                    });
                }

                return db.SaveChangesAsync();
            }
        }

        public Task DeleteAsync(Appeal appeal)
        {
            using (var db = new IdentityDbContext())
            {
                Appeal searchAppeal = db.Appeals.Find(appeal.Id);

                if (searchAppeal != null)
                {
                    db.Appeals.Remove(searchAppeal);
                }

                return db.SaveChangesAsync();
            }
        }

        public IEnumerable<Appeal> GetList()
        {
            using (var context = new IdentityDbContext())
            {
                return context.Appeals;
            }
        }

        public Task<Appeal> FindByIdAsync(int id)
        {
            using (var context = new IdentityDbContext())
            {
                return context.Appeals.FindAsync(id);
            }
        }

        public Task UpdateAsync(Appeal appeal)
        {
            using (var context = new IdentityDbContext())
            {
                context.Entry(appeal).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            using (var context = new IdentityDbContext())
            {
                context.Dispose();
            }
        }
    }
}