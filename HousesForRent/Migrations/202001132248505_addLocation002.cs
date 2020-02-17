namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLocation002 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LeasersInformations", "Location_Id", "dbo.Locations");
            DropIndex("dbo.LeasersInformations", new[] { "Location_Id" });
            AlterColumn("dbo.LeasersInformations", "Location_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.LeasersInformations", "Location_Id");
            AddForeignKey("dbo.LeasersInformations", "Location_Id", "dbo.Locations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeasersInformations", "Location_Id", "dbo.Locations");
            DropIndex("dbo.LeasersInformations", new[] { "Location_Id" });
            AlterColumn("dbo.LeasersInformations", "Location_Id", c => c.Int());
            CreateIndex("dbo.LeasersInformations", "Location_Id");
            AddForeignKey("dbo.LeasersInformations", "Location_Id", "dbo.Locations", "Id");
        }
    }
}
