using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppealWeb.Models
{
    public class LoggingUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (string.IsNullOrWhiteSpace(Username))
        //    {
        //        yield return new ValidationResult("Введите имя пользователя", new string[] { "Username" });
        //    }
        //    if (string.IsNullOrWhiteSpace(Password))
        //    {
        //        yield return new ValidationResult("Введите пароль", new string[] { "Password" });
        //    }
        //}
    }
}