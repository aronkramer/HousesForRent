namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeasersInformations", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.LeasersInformations", "UserId");
            AddForeignKey("dbo.LeasersInformations", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeasersInformations", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.LeasersInformations", new[] { "UserId" });
            DropColumn("dbo.LeasersInformations", "UserId");
        }
    }
}
