using FluentNhibernateLibrary.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppealWeb.Models
{
    public class RoleEditModel
    {
        public Role Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }

    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public long[] IdsToAdd { get; set; }
        public long[] IdsToDelete { get; set; }
    }
}