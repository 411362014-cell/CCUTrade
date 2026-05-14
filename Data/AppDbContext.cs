using Microsoft.EntityFrameworkCore;
using CCUTrade.Models;

namespace CCUTrade.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=ccutrade.db");
    }
}