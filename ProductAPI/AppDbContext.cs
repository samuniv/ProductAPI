using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(10, 2); // Precision: 10, Scale: 2

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
}
