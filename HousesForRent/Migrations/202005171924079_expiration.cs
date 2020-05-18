namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expiration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeasersInformations", "Expiration", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeasersInformations", "Expiration");
        }
    }
}
