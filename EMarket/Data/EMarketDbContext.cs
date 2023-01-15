using EMarket.Models;
using System.Data.Entity;

namespace EMarket.Data
{
    public partial class EMarketDbContext : DbContext
    {
        public EMarketDbContext() : base("name=EMarket")
        {
            // .....
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}