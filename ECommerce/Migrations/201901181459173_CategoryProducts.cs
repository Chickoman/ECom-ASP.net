namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Beskrivning = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CatergoryId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.CatergoryId_Id)
                .Index(t => t.CatergoryId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CatergoryId_Id", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "CatergoryId_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
        }
    }
}
