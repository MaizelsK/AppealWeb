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
            //Appeals = new List<Appeal>();
            //Logins = new List<UserLogin>();
            //Claims = new List<UserClaim>();
            //Roles = new List<Role>();
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public int AccessFailedCount { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string SecurityStamp { get; set; }
        public virtual ICollection<Role> Roles { get; protected set; }
        public virtual ICollection<UserClaim> Claims { get; protected set; }
        public virtual ICollection<UserLogin> Logins { get; protected set; }
        public virtual ICollection<Appeal> Appeals { get; protected set; }
    }
}
