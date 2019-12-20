namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationfixed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Locations", "CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "CityId", c => c.String());
        }
    }
}
