namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bathroomDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LeasersInformations", "Bathrooms", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LeasersInformations", "Bathrooms", c => c.Int(nullable: false));
        }
    }
}
