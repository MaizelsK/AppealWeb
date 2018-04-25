using DataAccessLibrary.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Stores
{
    public class AppealStore : IAppealStore
    {
        private IRepository<Appeal, int> Repository { get; set; }

        public AppealStore()
        {
            Repository = RepositoryFactory.GetRepository<Appeal, int>();
        }

        public Task CreateAsync(Appeal appeal)
        {
            return Repository.CreateAsync(appeal);
        }

        public Task DeleteAsync(Appeal appeal)
        {
            return Repository.DeleteAsync(appeal);
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
    }
}
