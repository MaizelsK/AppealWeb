using EFLibrary.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace EFLibrary
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        public IdentityDbContext() : base("IdentityDb") { }

        static IdentityDbContext()
        {
            Database.SetInitializer(new IdentityDbInit());
        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }

        public virtual DbSet<Appeal> Appeals { get; set; }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDbContext>
    {
        protected override void Seed(IdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        public void PerformInitialSetup(IdentityDbContext context)
        {
            // настройки конфигурации контекста будут указываться здесь
        }
    }
}