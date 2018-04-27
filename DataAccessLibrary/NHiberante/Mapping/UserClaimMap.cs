using DataAccessLibrary.Entities;
using FluentNHibernate.Mapping;

namespace DataAccessLibrary.NHiberante.Mapping
{
    public class UserClaimMap : ClassMap<UserClaim>
    {
        public UserClaimMap()
        {
            Table("UserClaims");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ClaimType);
            Map(x => x.ClaimValue);

            References(x => x.User).Column("User_Id");
        }
    }
}
