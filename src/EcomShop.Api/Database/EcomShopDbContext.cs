using Microsoft.EntityFrameworkCore;
using System.Reflection;

using EcomShop.Core.src.Entity;
using EcomShop.Api.Helpers;

namespace EcomShop.Api.src.Persistence;

public class EcomShopDbContext : DbContext
{
  public EcomShopDbContext(DbContextOptions<EcomShopDbContext> options)
    : base(options)
  {
  }

  public DbSet<Category> Categories { get; set; } = null!;
  public DbSet<Address> Addresses { get; set; } = null!;
  public DbSet<Product> Products { get; set; } = null!;
  public DbSet<Order> Orders { get; set; } = null!;
  public DbSet<User> User { get; set; } = null!;
  public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;

  public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

  public DbSet<OrderedLineItem> OrderedLineItems { get; set; } = null!;
  // public DbSet<User> Users { get; set; } = null!;
  // public DbSet<Order> Orders { get; set; } = null!;
  public DbSet<Review> Review { get; set; } = null!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    // db connection string: host; server name; username; pw; db name
    optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Database=group2demo;Port=5433;Password=trungdn123"); // PostgreSQL
    optionsBuilder.UseSnakeCaseNamingConvention(); // convert C# class names to snake_case table names in database
    base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Category>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.Name).IsRequired();
      entity.Property(e => e.Description).IsRequired();
      entity.Property(e => e.Image).IsRequired();
      entity.HasIndex(e => e.Name).IsUnique();
    });

    modelBuilder.Entity<Address>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.StreetName).IsRequired();
      entity.Property(e => e.StreetNumber);
      entity.Property(e => e.UnitNumber);
      entity.Property(e => e.PostalCode).IsRequired();
      entity.Property(e => e.City).IsRequired();
      entity.Property(e => e.UserId).IsRequired();
    });

    modelBuilder.Entity<User>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.FirstName); // .IsRequired();
      entity.Property(e => e.LastName); // .IsRequired();
      entity.Property(e => e.Email).IsRequired();
      entity.Property(e => e.PasswordHash).IsRequired();
      entity.Property(e => e.Phone); // .IsRequired();
      entity.Property(e => e.Role).IsRequired();
      entity.HasIndex(e => e.Email).IsUnique();
    });

    modelBuilder.Entity<ShoppingCart>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.UserId).IsRequired();
    });

    modelBuilder.Entity<Product>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Name).IsRequired();
      entity.Property(e => e.CategoryId).IsRequired();
      entity.Property(e => e.Price).IsRequired();
      entity.Property(e => e.QuantityInStock).IsRequired();
      entity.Property(e => e.Image);
      entity.Property(e => e.Description).IsRequired();
    });

    modelBuilder.Entity<ShoppingCartItem>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.ShoppingCartId).IsRequired();
      entity.Property(e => e.ProductId).IsRequired();
      entity.Property(e => e.Quantity).IsRequired();
    });
    modelBuilder.Entity<Order>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.UserId).IsRequired();
      entity.Property(e => e.AddressId).IsRequired();
      entity.Property(e => e.OrderDate).IsRequired();
    });
    modelBuilder.Entity<Review>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.Property(e => e.UserId).IsRequired();
      entity.Property(e => e.ProductId).IsRequired();
      entity.Property(e => e.Date).IsRequired();
      entity.Property(e => e.Rating).IsRequired();
      entity.Property(e => e.ReviewText).IsRequired();
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