using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Data;
// ✅ Inherit from IdentityDbContext<ApplicationUser>
public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // ✅ Application Tables
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<ShoppingCartItem> ShoppingCartItems => Set<ShoppingCartItem>();
    public DbSet<ProductReview> ProductReviews => Set<ProductReview>();
    public DbSet<Payment> Payments => Set<Payment>();

    // ✅ Optional: override OnModelCreating to customize schema
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Example: set decimal precision globally
        builder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        // Example: optional custom table name
        // builder.Entity<ApplicationUser>().ToTable("Users");
    }
}
