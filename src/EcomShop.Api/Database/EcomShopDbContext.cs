using Microsoft.EntityFrameworkCore;
using System.Reflection;

using EcomShop.Core.src.Entity;
using EcomShop.Api.Database;

namespace EcomShop.Api.src.Persistence;

public class EcomShopDbContext : DbContext
{
  public EcomShopDbContext(DbContextOptions<EcomShopDbContext> options)
    : base(options)
  {
  }

  public DbSet<Category> Categories { get; set; } = null!;
  public DbSet<Product> Products { get; set; } = null!;
  public DbSet<ProductImage> ProductImages { get; set; } = null!;
  public DbSet<Order> Orders { get; set; } = null!;
  public DbSet<OrderedLineItem> OrderedLineItems { get; set; } = null!;
  public DbSet<User> User { get; set; } = null!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    // db connection string: host; server name; username; pw; db name
    optionsBuilder.UseNpgsql("Host=ep-holy-poetry-a2h0ev99.eu-central-1.aws.neon.tech;Username=EcomShop_owner;Password=N1B2GsZlxHdP;Database=EcomShop;SslMode=Require"); // PostgreSQL
    optionsBuilder.UseSnakeCaseNamingConvention();
    base.OnConfiguring(optionsBuilder);
  }

  [Obsolete]
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Category>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.Name).IsRequired();
      entity.Property(e => e.Image).IsRequired();
      entity.HasIndex(e => e.Name).IsUnique();
      entity.HasData(SeedingData.GetCategoriesSeed());
    });

    modelBuilder.Entity<User>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Name).IsRequired();
      entity.Property(e => e.Email).IsRequired();
      entity.Property(e => e.Password).IsRequired();
      entity.Property(e => e.Role).IsRequired();
      entity.HasIndex(e => e.Email).IsUnique();
      entity.HasData(SeedingData.GetUsersSeed());
    });

    modelBuilder.Entity<Product>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Name).IsRequired();
      entity.Property(e => e.CategoryId).IsRequired();
      entity.Property(e => e.Price).IsRequired();
      entity.Property(e => e.Description).IsRequired();
      entity.HasData(SeedingData.GetProductsSeed());
    });

    modelBuilder.Entity<ProductImage>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.ProductId).IsRequired();
      entity.Property(e => e.Url).IsRequired();
      entity.HasData(SeedingData.GetProductImagesSeed());
    });

    modelBuilder.Entity<Order>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.UserId).IsRequired();
      entity.Property(e => e.CreatedAt).IsRequired();
    });

    modelBuilder.Entity<OrderedLineItem>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.OrderId).IsRequired();
      entity.Property(e => e.ProductId).IsRequired();
      entity.Property(e => e.Quantity).IsRequired();
    });
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}