namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemCtegorys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        ItemCategoryId = c.Int(nullable: false, identity: true),
                        ItemCategoryCode = c.String(nullable: false),
                        ItemCategoryName = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ItemCategoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemCategories");
        }
    }
}
