using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AppealWeb.Models
{
    public class AppealModel
    {
        public string Theme { get; set; }
        public string Text { get; set; }

        public HttpPostedFileBase FileData { get; set; }
    }
}