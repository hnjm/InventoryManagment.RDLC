namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateiteminformations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemInformations", "ItemCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemInformations", "ItemCategoryId");
            AddForeignKey("dbo.ItemInformations", "ItemCategoryId", "dbo.ItemCategories", "ItemCategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemInformations", "ItemCategoryId", "dbo.ItemCategories");
            DropIndex("dbo.ItemInformations", new[] { "ItemCategoryId" });
            DropColumn("dbo.ItemInformations", "ItemCategoryId");
        }
    }
}
