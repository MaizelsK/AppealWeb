using DataAccessLibrary.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.NHiberante.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.AccessFailedCount);
            Map(x => x.Email);
            Map(x => x.EmailConfirmed);
            Map(x => x.LockoutEnabled);
            Map(x => x.LockoutEndDateUtc);
            Map(x => x.PasswordHash);
            Map(x => x.PhoneNumber);
            Map(x => x.PhoneNumberConfirmed);
            Map(x => x.TwoFactorEnabled);
            Map(x => x.UserName).Length(255).Not.Nullable().Unique();
            Map(x => x.SecurityStamp);

            HasMany(x => x.Claims).KeyColumn("User_Id")
                .Not.KeyUpdate().Cascade.All();

            HasMany(x => x.Logins).Table("UserLogins")
                .KeyColumn("User_Id").Cascade.All();

            HasManyToMany(x => x.Roles).Table("RoleUsers");

            HasMany(x => x.Appeals).Table("Appeals")
                .KeyColumn("User_Id").Cascade.All();
        }
    }
}
