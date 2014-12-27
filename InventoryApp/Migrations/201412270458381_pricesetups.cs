namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pricesetups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceSetups",
                c => new
                    {
                        PriceSetupId = c.Int(nullable: false, identity: true),
                        ItemCategoryId = c.Int(nullable: false),
                        ItemInformationId = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        Vat = c.Double(nullable: false),
                        VatPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PriceSetupId)
                .ForeignKey("dbo.ItemCategories", t => t.ItemCategoryId, cascadeDelete: false)
                .ForeignKey("dbo.ItemInformations", t => t.ItemInformationId, cascadeDelete: false)
                .Index(t => t.ItemCategoryId)
                .Index(t => t.ItemInformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceSetups", "ItemInformationId", "dbo.ItemInformations");
            DropForeignKey("dbo.PriceSetups", "ItemCategoryId", "dbo.ItemCategories");
            DropIndex("dbo.PriceSetups", new[] { "ItemInformationId" });
            DropIndex("dbo.PriceSetups", new[] { "ItemCategoryId" });
            DropTable("dbo.PriceSetups");
        }
    }
}
