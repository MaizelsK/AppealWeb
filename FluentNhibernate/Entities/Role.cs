using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace FluentNhibernateLibrary.Entities
{
    public class Role : IRole<string>
    {
        public Role() { Users = new List<User>(); }
        public Role(string roleName) : this() { Name = roleName; }

        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
