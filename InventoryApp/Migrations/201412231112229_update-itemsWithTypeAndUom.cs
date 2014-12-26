namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateitemsWithTypeAndUom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemInformations", "ItemTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.ItemInformations", "UomId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemInformations", "ItemTypeId");
            CreateIndex("dbo.ItemInformations", "UomId");
            AddForeignKey("dbo.ItemInformations", "ItemTypeId", "dbo.ItemTypes", "ItemTypeId", cascadeDelete: true);
            AddForeignKey("dbo.ItemInformations", "UomId", "dbo.Uoms", "UomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemInformations", "UomId", "dbo.Uoms");
            DropForeignKey("dbo.ItemInformations", "ItemTypeId", "dbo.ItemTypes");
            DropIndex("dbo.ItemInformations", new[] { "UomId" });
            DropIndex("dbo.ItemInformations", new[] { "ItemTypeId" });
            DropColumn("dbo.ItemInformations", "UomId");
            DropColumn("dbo.ItemInformations", "ItemTypeId");
        }
    }
}
