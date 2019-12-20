namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leaserlocaton : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeasersInformations", "LocationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeasersInformations", "LocationId");
        }
    }
}
