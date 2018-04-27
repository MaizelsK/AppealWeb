using DataAccessLibrary.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.NHiberante.Mapping
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Table("Roles");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Name).Length(255).Not.Nullable().Unique();

            HasManyToMany(x => x.Users).Table("RoleUsers");
        }
    }
}
