using FluentNHibernate.Mapping;
using DataAccessLibrary;

namespace FluentNhibernateLibrary.Mapping
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
