namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientInformations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientInformations",
                c => new
                    {
                        ClientInformationId = c.Int(nullable: false, identity: true),
                        ClientCode = c.String(),
                        ClientName = c.String(),
                        ContactPerson = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        MobileNumber = c.String(),
                    })
                .PrimaryKey(t => t.ClientInformationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClientInformations");
        }
    }
}
