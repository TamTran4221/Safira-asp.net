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
        public DbSet<Cart> carts { get; set; }
      
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Cart>()
                .HasKey(c => new { c.AccountId, c.ProductId });
            modelBuilder.Entity<OrderDetail>()
               .HasKey(c => new { c.OrderId, c.ProductId });

        }
    }
}
