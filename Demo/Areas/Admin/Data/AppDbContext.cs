using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Areas.Admin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Account> accounts { get; set; }
    }
}
