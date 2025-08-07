using System.Reflection;
using Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Database
/// </summary>
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
    {
    }
    /// <summary>
    /// Accounts
    /// </summary>
    public DbSet<Account> Accounts { get; set; }

    /// <summary>
    /// Addresses
    /// </summary>
    public DbSet<Address> Addresses { get; set; }

    /// <summary>
    /// Clients
    /// </summary>
    public DbSet<Client> Clients { get; set; }

    /// <summary>
    /// Countries
    /// </summary>
    public DbSet<Country> Countries { get; set; }

    /// <summary>
    /// Products
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Sales
    /// </summary>
    public DbSet<Sale> Sales { get; set; }

    /// <summary>
    /// Seed initial data
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Lion King",
                Type = "Book",
                Price = 25.00M
            },
            new Product
            {
                Id = 2,
                Name = "Gladiator 2",
                Type = "Movie",
                Price = 30.50M
            },
            new Product
            {
                Id = 3,
                Name = "God Of War: Ragnarok",
                Type = "PS5 Game",
                Price = 69.90M
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
