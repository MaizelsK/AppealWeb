using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Entities
{
    public class Role : IRole<string>
    {
        public Role() { Users = new List<User>(); }
        public Role(string roleName) : this() { Name = roleName; }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
