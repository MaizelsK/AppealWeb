using DataAccessLibrary.EF;
using DataAccessLibrary.NHiberante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class RepositoryFactory
    {
        public static bool IsEntityFramework = true;

        public static IRepository<Entity, Key> GetRepository<Entity, Key>() where Entity : class
        {
            if (IsEntityFramework)
                return new EFRepository<Entity, Key>();
            else
                return new NHibernateRepository<Entity, Key>();
        }
    }
}
