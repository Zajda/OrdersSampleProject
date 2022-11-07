using ApiSampleProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSampleProject.DbContexts;

public class OrdersSampleDbContext : DbContext
{
    public OrdersSampleDbContext(DbContextOptions<OrdersSampleDbContext> options)
        : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        // Connection string only included because it is a sample project, otherwise it should be in config
        DbPath = Path.Join(path, "OrdersSampleDatabase.db");
    }

    public string DbPath { get; }

    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}