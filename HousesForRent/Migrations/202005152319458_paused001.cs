namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paused001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeasersInformations", "Paused", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeasersInformations", "Paused");
        }
    }
}
