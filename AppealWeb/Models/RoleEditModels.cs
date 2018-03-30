using EFLibrary.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppealWeb.Models
{
    public class RoleEditModel
    {
        public AppRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }

    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}