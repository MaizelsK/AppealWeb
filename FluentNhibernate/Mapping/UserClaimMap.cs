using FluentNHibernate.Mapping;
using FluentNhibernateLibrary.Entities;

namespace FluentNhibernateLibrary.Mapping
{
    public class UserClaimMap : ClassMap<UserClaim>
    {
        public UserClaimMap()
        {
            Table("AspNetUserClaims");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ClaimType);
            Map(x => x.ClaimValue);

            References(x => x.User).Column("UserID");
        }
    }
}
