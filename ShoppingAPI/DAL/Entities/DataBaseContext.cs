using Microsoft.EntityFrameworkCore;
namespace ShoppingAPI.DAL.Entities
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<ShoppingCart>().ToTable("ShoppingCarts");
            modelBuilder.Entity<ShoppingCartItem>().ToTable("ShoppingCartItems");
        }
    }
}
