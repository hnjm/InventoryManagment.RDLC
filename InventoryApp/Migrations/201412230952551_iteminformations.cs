namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iteminformations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemInformations",
                c => new
                    {
                        ItemInformationId = c.Int(nullable: false, identity: true),
                        ItemCode = c.String(nullable: false),
                        ItemName = c.String(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ItemInformationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemInformations");
        }
    }
}
