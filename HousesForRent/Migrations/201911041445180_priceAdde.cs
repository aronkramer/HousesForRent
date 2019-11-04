namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priceAdde : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeasersInformations", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeasersInformations", "Price");
        }
    }
}
