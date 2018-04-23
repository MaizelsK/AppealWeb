using FluentNHibernate.Mapping;
using FluentNhibernateLibrary.Entities;

namespace FluentNhibernateLibrary.Mapping
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Table("AspNetRoles");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Name).Length(255).Not.Nullable().Unique();

            HasManyToMany(x => x.Users).Table("AspNetUserRoles")
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
