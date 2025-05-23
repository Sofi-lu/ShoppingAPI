using Microsoft.EntityFrameworkCore;
using ShoppingAPI.DAL.Entities;
namespace ShoppingAPI.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();

        }

        
        public DbSet<Country> Countries { get; set; } = null!;
        
        
    }
}
