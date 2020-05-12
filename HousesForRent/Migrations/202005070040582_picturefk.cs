namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class picturefk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "FileName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pictures", "FileName");
        }
    }
}
