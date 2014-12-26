namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientInformations", "CreatedDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientInformations", "CreatedDateTime");
        }
    }
}
