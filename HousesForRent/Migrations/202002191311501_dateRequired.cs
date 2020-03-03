namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LeasersInformations", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LeasersInformations", "Date", c => c.DateTime());
        }
    }
}
