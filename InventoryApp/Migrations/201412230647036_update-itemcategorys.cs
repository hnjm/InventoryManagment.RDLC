namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateitemcategorys : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ItemCategories", "ItemCategoryName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemCategories", "ItemCategoryName", c => c.String());
        }
    }
}
