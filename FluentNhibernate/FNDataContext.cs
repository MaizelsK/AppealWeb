using FluentNhibernateLibrary.Stores;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNhibernateLibrary.Entities;
using Microsoft.AspNet.Identity;
using NHibernate;
using System.Configuration;
using FluentNhibernateLibrary.Mapping;
using NHibernate.Tool.hbm2ddl;

namespace FluentNhibernateLibrary
{
    public class FNDataContext
    {
        private readonly ISessionFactory sessionFactory;

        public IUserStore<User, long> Users
        {
            get { return new IdentityStore(MakeSession()); }
        }

        public IRoleStore<Role> Roles
        {
            get { return new FluentRoleStore(MakeSession()); }
        }

        public IAppealStore Appeals
        {
            get { return new AppealStore(MakeSession()); }
        }

        public FNDataContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["IdentityDb"].ConnectionString;
            sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }

        public ISession MakeSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}
