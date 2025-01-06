using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace AspDotNetCoreEmpty.Models;

public class BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Pie> Pies { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(BethanysPieShopDbContext).Assembly);
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Pie>().ToTable("Pies");
        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<OrderDetail>().ToTable("OderLines");

        // Fluent API
        builder.Entity<Category>()
            .Property(x => x.CategoryName)
            .IsRequired();
    }
}