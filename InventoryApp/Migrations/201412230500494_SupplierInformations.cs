namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupplierInformations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplierInformations",
                c => new
                    {
                        SupplierInformationId = c.Int(nullable: false, identity: true),
                        SupplierCode = c.String(nullable: false),
                        SupplierName = c.String(nullable: false),
                        ContactPerson = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierInformationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SupplierInformations");
        }
    }
}
