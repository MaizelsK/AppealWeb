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
            Table("Appeals");
            Id(x => x.Id);
            Map(x => x.Theme);
            Map(x => x.Text);
            Map(x => x.PublishDate);
            Map(x => x.FileName);
            Map(x => x.FileData);

            References(x => x.User).Column("User_Id").Cascade.SaveUpdate();
        }
    }
}
