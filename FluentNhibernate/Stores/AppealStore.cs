using System.Threading.Tasks;
using FluentNhibernateLibrary.Entities;
using NHibernate;
using System.Linq;
using System.Collections.Generic;

namespace FluentNhibernateLibrary.Stores
{
    public class AppealStore : IAppealStore
    {
        private readonly ISession session;
        public IEnumerable<Appeal> Appeals { get; }

        public AppealStore(ISession session)
        {
            this.session = session;
            Appeals = session.CreateCriteria<Appeal>().List<Appeal>();
        }

        public Task CreateAsync(Appeal appeal)
        {
            return session.SaveOrUpdateAsync(appeal);
        }

        public Task DeleteAsync(Appeal appeal)
        {
            return session.DeleteAsync(appeal);
        }

        public Task<Appeal> FindByIdAsync(int appealId)
        {
            return session.GetAsync<Appeal>(appealId);
        }

        public Task<Appeal> FindByThemeAsync(string appealTheme)
        {
            return Task.Run(() =>
            {
                return session.QueryOver<Appeal>()
                    .Where(u => u.Theme == appealTheme)
                    .SingleOrDefault();
            });
        }

        public Task UpdateAsync(Appeal appeal)
        {
            return session.SaveOrUpdateAsync(appeal);
        }
    }
}
