namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priceNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LeasersInformations", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LeasersInformations", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
