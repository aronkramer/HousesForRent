namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeasersInformations", "Location_Id", c => c.Int());
            CreateIndex("dbo.LeasersInformations", "Location_Id");
            AddForeignKey("dbo.LeasersInformations", "Location_Id", "dbo.Locations", "Id");
            DropColumn("dbo.LeasersInformations", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LeasersInformations", "LocationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.LeasersInformations", "Location_Id", "dbo.Locations");
            DropIndex("dbo.LeasersInformations", new[] { "Location_Id" });
            DropColumn("dbo.LeasersInformations", "Location_Id");
        }
    }
}
