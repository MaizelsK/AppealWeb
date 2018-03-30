using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppealWeb.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(5, ErrorMessage = "{0} Длина имени пользователся должна быть не менее {2} символов.", MinimumLength = 5)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} Длина пароля должна быть не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display (Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare(otherProperty: "Password", ErrorMessage = "Пароли не совпадают.")]
        [DataType(DataType.Password)]
        [Display(Name = "Подвердите пароль")]
        public string ConfirmPassword { get; set; }
    }
}