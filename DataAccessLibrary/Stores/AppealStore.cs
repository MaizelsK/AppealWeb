using DataAccessLibrary.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Stores
{
    public class AppealStore : IAppealStore, IDisposable
    {
        private IRepository<Appeal, int> Repository { get; set; }

        public AppealStore()
        {
            Repository = RepositoryFactory.GetRepository<Appeal, int>();
        }

        public Task CreateAsync(Appeal appeal, long userId)
        {
            return Repository.CreateAppealAsync(appeal, userId);
        }

        public void Create(Appeal appeal, long userId)
        {
            Repository.CreateAppeal(appeal, userId);
        }

        public List<Appeal> GetList()
        {
            return Repository.GetList() as List<Appeal>;
        }

        public Task DeleteAsync(Appeal appeal)
        {
            return Repository.DeleteAsync(appeal);
        }

        public void Delete(Appeal appeal)
        {
            Repository.Delete(appeal);
        }

        public Task<Appeal> FindByIdAsync(int appealId)
        {
            return Repository.FindByIdAsync(appealId);
        }

        public Task<Appeal> FindByThemeAsync(string appealTheme)
        {
            return Task.Run(() =>
            {
                return Repository.GetList().SingleOrDefault(x => x.Theme == appealTheme);
            });
        }

        public Task UpdateAsync(Appeal appeal)
        {
            return Repository.UpdateAsync(appeal);
        }

        public void Dispose()
        {
            Repository.Dispose();
        }
    }
}
