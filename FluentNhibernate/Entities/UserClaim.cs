namespace FluentNhibernateLibrary.Entities
{
    public class UserClaim
    {
        public virtual long Id { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }
        public virtual User User { get; set; }
    }
}
