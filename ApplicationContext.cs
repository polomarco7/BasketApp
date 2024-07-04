using BasketApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopApp
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<BasketProductCard> BasketProductCards { get; set; } = null!;
        public DbSet<History> Histories { get; set; } = null!;
        public ApplicationContext() {
            Database.EnsureCreated();        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("server=127.0.0.1; user=root;password=root;database=productsdb",
                new MySqlServerVersion(new Version(5, 7, 44)));
        }
    }
}
