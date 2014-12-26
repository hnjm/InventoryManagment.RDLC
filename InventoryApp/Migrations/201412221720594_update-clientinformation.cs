namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateclientinformation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClientInformations", "ClientCode", c => c.String(nullable: false));
            AlterColumn("dbo.ClientInformations", "ClientName", c => c.String(nullable: false));
            AlterColumn("dbo.ClientInformations", "ContactPerson", c => c.String(nullable: false));
            AlterColumn("dbo.ClientInformations", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.ClientInformations", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.ClientInformations", "MobileNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClientInformations", "MobileNumber", c => c.String());
            AlterColumn("dbo.ClientInformations", "Email", c => c.String());
            AlterColumn("dbo.ClientInformations", "Address", c => c.String());
            AlterColumn("dbo.ClientInformations", "ContactPerson", c => c.String());
            AlterColumn("dbo.ClientInformations", "ClientName", c => c.String());
            AlterColumn("dbo.ClientInformations", "ClientCode", c => c.String());
        }
    }
}
