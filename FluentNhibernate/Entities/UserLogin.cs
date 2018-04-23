namespace FluentNhibernateLibrary.Entities
{
    public class UserLogin
    {
        public virtual long UserId { get; set; }
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
    }
}
