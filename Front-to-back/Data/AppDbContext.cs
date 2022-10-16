using Front_to_back.Models;
using Microsoft.EntityFrameworkCore;


namespace Front_to_back.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
         public DbSet<Product> Products { get; set; }

    }
}