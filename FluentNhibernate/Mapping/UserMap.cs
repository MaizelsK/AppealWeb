using FluentNHibernate.Mapping;
using DataAccessLibrary;

namespace FluentNhibernateLibrary.Mapping
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

            HasMany(x => x.Claims).KeyColumn("UserId")
                .Not.KeyUpdate().Cascade.All();

            HasMany(x => x.Logins).Table("UserLogins")
                .KeyColumn("UserId").Cascade.All()
                .Component(m =>
                            {
                                m.Map(l => l.LoginProvider);
                                m.Map(p => p.ProviderKey);
                            });
                //.AsMap(m => m.LoginProvider).AsMap(m => m.ProviderKey);

            HasManyToMany(x => x.Roles).Table("UserRoles")
                .ChildKeyColumn("UserId");

            #region Simple NHibernate mapping
            //Bag(x => x.Claims, map =>
            //{
            //    map.Key(k =>
            //    {
            //        k.Column("UserId");
            //        k.Update(false); // to prevent extra update afer insert
            //    });
            //    map.Cascade(Cascade.All | Cascade.DeleteOrphans);
            //}, rel =>
            //{
            //    rel.OneToMany();
            //});

            //this.Set(x => x.Logins, cam =>
            //{
            //    cam.Table("AspNetUserLogins");
            //    cam.Key(km => km.Column("UserId"));
            //    cam.Cascade(Cascade.All | Cascade.DeleteOrphans);
            //},
            //         map =>
            //         {
            //             map.Component(comp =>
            //             {
            //                 comp.Property(p => p.LoginProvider);
            //                 comp.Property(p => p.ProviderKey);
            //             });
            //         });

            //this.Bag(x => x.Roles, map =>
            //{
            //    map.Table("AspNetUserRoles");
            //    map.Key(k => k.Column("UserId"));
            //}, rel => rel.ManyToMany(p => p.Column("RoleId")));
            #endregion
        }
    }
}
