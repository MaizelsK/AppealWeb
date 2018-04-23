using System.ComponentModel.DataAnnotations;

namespace AppealWeb.Models
{
    public class AppealModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} должна содержать как минимум {2} символов", MinimumLength = 5)]
        [Display(Name = "Тема")]
        public string Theme { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "{0} должен содержать как минимум {2} символов", MinimumLength = 10)]
        [Display(Name = "Текст")]
        public string Text { get; set; }
    }
}