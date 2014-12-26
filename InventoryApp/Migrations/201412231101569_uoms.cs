namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uoms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uoms",
                c => new
                    {
                        UomId = c.Int(nullable: false, identity: true),
                        UomName = c.String(),
                    })
                .PrimaryKey(t => t.UomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uoms");
        }
    }
}
