namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateviews : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategories", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategories", "Name", c => c.String());
        }
    }
}
