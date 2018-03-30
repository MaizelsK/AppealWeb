using System;

namespace EFLibrary.Entities
{
    public class Appeal
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public DateTime PublishDate { get; set; }

        public virtual User User { get; set; }
    }
}