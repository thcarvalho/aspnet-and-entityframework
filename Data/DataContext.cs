using asptest.Models;
using Microsoft.EntityFrameworkCore;

namespace asptest.Data
{
  public class DataContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=database.sqlite");
    }
  }
}