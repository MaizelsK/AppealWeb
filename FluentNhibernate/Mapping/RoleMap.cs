using DataAccessLibrary;
using FluentNHibernate.Mapping;

namespace FluentNhibernateLibrary.Mapping
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Table("Roles");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Name).Length(255).Not.Nullable().Unique();

            HasManyToMany(x => x.Users).Table("UserRoles")
                .Cascade.None().ChildKeyColumn("RoleId");

            //Bag(x => x.Users, map =>
            //{
            //    map.Table("AspNetUserRoles");
            //    map.Cascade(Cascade.Cone);
            //    map.Key(k => k.Column("RoleId"));
            //}, rel => rel.ManyToMany(p => p.Column("UserId")));
        }
    }
}
