using DataAccessLibrary.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.NHiberante.Mapping
{
    public class UserLoginMap : ClassMap<UserLogin>
    {
        public UserLoginMap()
        {
            Table("UserLogins");
            Id(x => x.UserId).Column("UserId");
            Map(x => x.LoginProvider);
            Map(x => x.ProviderKey);

            //References(x => x.UserId).Column("User_Id");
        }
    }
}
