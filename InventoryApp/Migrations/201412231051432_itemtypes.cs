namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemtypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemTypes",
                c => new
                    {
                        ItemTypeId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                    })
                .PrimaryKey(t => t.ItemTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemTypes");
        }
    }
}
