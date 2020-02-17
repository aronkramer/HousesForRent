namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class location004 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.LeasersInformations", name: "Location_Id", newName: "LocationId");
            RenameIndex(table: "dbo.LeasersInformations", name: "IX_Location_Id", newName: "IX_LocationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.LeasersInformations", name: "IX_LocationId", newName: "IX_Location_Id");
            RenameColumn(table: "dbo.LeasersInformations", name: "LocationId", newName: "Location_Id");
        }
    }
}
