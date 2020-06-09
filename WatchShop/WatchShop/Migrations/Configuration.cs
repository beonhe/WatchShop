namespace WatchShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WatchShop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WatchShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WatchShop.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Categories.AddOrUpdate(x => x.id,
                new Category() { id = 1, name = "Dong ho co" },
                new Category() { id = 2, name = "Dong ho dien tu" }
            );
            context.Brands.AddOrUpdate(x => x.id,
                new Brand() { id = 1, name = "Rolex" },
                new Brand() { id = 2, name = "Casio" }
            );
            context.Items.AddOrUpdate(x => x.id,
                new Item()
                {
                    id = 1,
                    name = "Dong ho 1",
                    price = 100000,
                    categoryId = 1,
                    brandId = 2,
                    image = "/assets/img/gallery/popular1.png"
                },
                new Item()
                {
                    id = 2,
                    name = "Dong ho 2",
                    price = 100000,
                    categoryId = 1,
                    brandId = 1,
                    image = "/assets/img/gallery/popular1.png"
                },
                new Item()
                {
                    id = 3,
                    name = "Dong ho 3",
                    price = 100000,
                    categoryId = 2,
                    brandId = 2,
                    image = "/assets/img/gallery/popular1.png"
                }
                );
        }
    }
}
