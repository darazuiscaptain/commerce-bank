using cs451_commerce_bank_project.Models;
using Microsoft.EntityFrameworkCore;

namespace cs451_commerce_bank_project
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Transaction>()
              .HasOne(p => p.User)
              .WithMany(b => b.Transactions)
              .HasForeignKey(p => p.UserAccountId)
              .HasPrincipalKey(b => b.AccountId);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<NotificationRule> NotificationRules { get; set; }
    }
}
