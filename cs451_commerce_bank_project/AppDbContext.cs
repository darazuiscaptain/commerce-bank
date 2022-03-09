using cs451_commerce_bank_project.Models;
using Microsoft.EntityFrameworkCore;

namespace cs451_commerce_bank_project
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
