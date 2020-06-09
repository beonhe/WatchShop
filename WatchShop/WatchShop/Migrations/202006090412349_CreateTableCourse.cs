namespace WatchShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        price = c.Long(nullable: false),
                        brandId = c.Int(nullable: false),
                        categoryId = c.Int(nullable: false),
                        image = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Brands", t => t.brandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.brandId)
                .Index(t => t.categoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "categoryId", "dbo.Categories");
            DropForeignKey("dbo.Items", "brandId", "dbo.Brands");
            DropIndex("dbo.Items", new[] { "categoryId" });
            DropIndex("dbo.Items", new[] { "brandId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
            DropTable("dbo.Brands");
        }
    }
}
