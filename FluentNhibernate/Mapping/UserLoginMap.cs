using DataAccessLibrary;
using FluentNHibernate.Mapping;

namespace FluentNhibernateLibrary.Mapping
{
    public class UserLoginMap : ClassMap<UserLogin>
    {
        public UserLoginMap()
        {
            Table("UserLogins");
            Id(x => x.UserId).Column("UserId");
            Map(x => x.LoginProvider);
            Map(x => x.ProviderKey);
        }
    }
}
