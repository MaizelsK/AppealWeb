using FluentNHibernate.Mapping;
using FluentNhibernateLibrary.Entities;

namespace FluentNhibernateLibrary.Mapping
{
    public class UserLoginMap : ClassMap<UserLogin>
    {
        public UserLoginMap()
        {
            Table("AspNetUserLogins");
            Id(x => x.UserId).Column("UserId");
            Map(x => x.LoginProvider);
            Map(x => x.ProviderKey);
        }
    }
}
