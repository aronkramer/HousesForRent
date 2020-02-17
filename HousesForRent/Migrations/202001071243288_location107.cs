namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class location107 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.LeasersInformations", "Location_Id", "dbo.Locations");
            //DropIndex("dbo.LeasersInformations", new[] { "Location_Id" });
            //AddColumn("dbo.LeasersInformations", "LocationId", c => c.Int(nullable: false));
            //DropColumn("dbo.LeasersInformations", "Location_Id");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.LeasersInformations", "Location_Id", c => c.Int(nullable: false));
            //DropColumn("dbo.LeasersInformations", "LocationId");
            //CreateIndex("dbo.LeasersInformations", "Location_Id");
            //AddForeignKey("dbo.LeasersInformations", "Location_Id", "dbo.Locations", "Id", cascadeDelete: true);
        }
    }
}
