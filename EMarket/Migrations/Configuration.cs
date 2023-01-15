using EMarket.Data;
using System.Data.Entity.Migrations;

namespace EMarket.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EMarketDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EMarketDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
