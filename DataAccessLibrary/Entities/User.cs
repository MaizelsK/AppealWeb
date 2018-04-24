using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Entities
{
    public class User : IUser<long>
    {
        public User(string username) : this() { UserName = username; }
        public User()
        {
            Appeals = new List<Appeal>();
            Logins = new List<UserLogin>();
            Claims = new List<UserClaim>();
            Roles = new List<Role>();
        }

        public virtual long Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual int AccessFailedCount { get; set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual ICollection<Role> Roles { get; protected set; }
        public virtual ICollection<UserClaim> Claims { get; protected set; }
        public virtual ICollection<UserLogin> Logins { get; protected set; }
        public virtual ICollection<Appeal> Appeals { get; protected set; }
    }
}
