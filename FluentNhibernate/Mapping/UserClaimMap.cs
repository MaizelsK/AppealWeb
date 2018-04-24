using DataAccessLibrary;
using FluentNHibernate.Mapping;

namespace FluentNhibernateLibrary.Mapping
{
    public class UserClaimMap : ClassMap<UserClaim>
    {
        public UserClaimMap()
        {
            Table("UserClaims");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ClaimType);
            Map(x => x.ClaimValue);

            References(x => x.User).Column("UserID");
        }
    }
}
