using DataAccessLibrary;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace EFLibrary
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext() : base("IdentityDb") { }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Appeal> Appeals { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Appeal>().ToTable("Appeals");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
        }
    }
}