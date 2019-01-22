namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ECommerce.Models.ECommerceDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ECommerce.Models.ECommerceDB context)
        {
            //  This method will be called after migrating to the latest version.
            context.ProductCategories.AddOrUpdate(r => r.Id,
               new ECommerce.Models.ProductCategory { Id = 1 , Name = "Beer"},
               new ECommerce.Models.ProductCategory { Id = 2, Name = "Soda" },
                 new ECommerce.Models.ProductCategory { Id = 3, Name = "Wine" }
                );

                context.Products.AddOrUpdate(r => r.Id,
                new ECommerce.Models.Product { Id = 1 , Name = "Sierra Nevada Pale Ale", Beskrivning = "En god Ipa med Amerikansk Humle", Price = 20 , CategoryId = 1},
                new ECommerce.Models.Product { Id = 2, Name = "Castillo de gredos", Beskrivning = "Systemets sämsta vin", Price = 20, CategoryId = 3 },
                new ECommerce.Models.Product { Id = 3, Name = "Pripps Blå", Beskrivning = "Blå är havet", Price = 23, CategoryId = 1 },
                new ECommerce.Models.Product { Id = 4, Name = "Coca Cola", Beskrivning = "Coca Cola ", Price = 24, CategoryId = 2},
                new ECommerce.Models.Product { Id = 5, Name = "Modus Hoperandi", Beskrivning = "Första Ipan på burk", Price = 22, CategoryId = 1 },
                new ECommerce.Models.Product { Id = 6, Name = "Coca Cola", Beskrivning = "Coca Cola ", Price = 24, CategoryId = 2 }



                 );


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
