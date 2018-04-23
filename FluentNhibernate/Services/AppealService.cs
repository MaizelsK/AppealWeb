using FluentNhibernateLibrary.Entities;
using FluentNhibernateLibrary.Stores;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FluentNhibernateLibrary.Services
{
    public class AppealService : IDisposable
    {
        public AppealStore Store { get; set; }

        private AuthenticationService AuthManager
        {
            get { return HttpContext.Current.GetOwinContext().Get<AuthenticationService>(); }
        }

        public AppealService(IAppealStore store)
        {
            Store = store as AppealStore;
        }

        public void Create(string theme, string text, ModelStateDictionary modelState)
        {
            var existingAppeal = Store.FindByThemeAsync(theme);

            if (existingAppeal.Result != null)
            {
                modelState.AddModelError("", "Обращение с такой темой уже существует");
            }
            else
            {
                Store.CreateAsync(new Appeal()
                {
                    Theme = theme,
                    Text = text,
                    PublishDate = DateTime.Now,
                    User = GetCurrentUser()
                });
            }
        }

        public User GetCurrentUser()
        {
            var user = new UserService(new FNDataContext().Users)
                        .FindById(AuthManager.AuthenticationManager.User.Identity.GetUserId<long>());
            return user;
        }

        public void Dispose()
        {
            AuthManager.Dispose();
        }
    }
}
