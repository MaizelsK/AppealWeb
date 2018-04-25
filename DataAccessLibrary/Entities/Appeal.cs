using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Entities
{
    public class Appeal
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Theme { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime PublishDate { get; set; }
        public virtual User User { get; set; }
    }
}
