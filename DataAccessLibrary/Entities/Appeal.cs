using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Entities
{
    public class Appeal
    {
        [Key]
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual User User { get; set; }
    }
}
