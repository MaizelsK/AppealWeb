using DataAccessLibrary.Entities;
using DataAccessLibrary.NHiberante.Mapping;
using DataAccessLibrary.Stores;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNet.Identity;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.NHiberante
{
    public class NHibernateContext
    {
        private readonly ISessionFactory sessionFactory;

        public NHibernateContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AppealDb"].ConnectionString;
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
