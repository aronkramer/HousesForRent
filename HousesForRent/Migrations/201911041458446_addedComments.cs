namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeasersInformations", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeasersInformations", "Comments");
        }
    }
}
