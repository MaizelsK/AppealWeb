using DataAccessLibrary.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.NHiberante.Mapping
{
    public class AppealMap : ClassMap<Appeal>
    {
        public AppealMap()
        {
            Id(x => x.Id);
            Map(x => x.Theme);
            Map(x => x.Text);
            Map(x => x.PublishDate);
            References(x => x.User).Column("Id").Cascade.SaveUpdate();

            Table("Appeals");
        }
    }
}
