namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CatergoryId_Id", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "CatergoryId_Id" });
            RenameColumn(table: "dbo.Products", name: "CatergoryId_Id", newName: "CategoryId");
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.ProductCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "CatergoryId_Id");
            CreateIndex("dbo.Products", "CatergoryId_Id");
            AddForeignKey("dbo.Products", "CatergoryId_Id", "dbo.ProductCategories", "Id");
        }
    }
}
