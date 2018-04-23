using System.ComponentModel.DataAnnotations;

namespace AppealWeb.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} - длина должна быть не менее {2} символов.", MinimumLength = 5)]
        [Display(Name = "Имя пользователя")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} - длина должна быть не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display (Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare(otherProperty: "Password", ErrorMessage = "Пароли не совпадают.")]
        [DataType(DataType.Password)]
        [Display(Name = "Подвердите пароль")]
        public string ConfirmPassword { get; set; }
    }
}