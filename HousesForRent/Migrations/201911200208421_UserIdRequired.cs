namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LeasersInformations", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.LeasersInformations", new[] { "UserId" });
            AlterColumn("dbo.LeasersInformations", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.LeasersInformations", "UserId");
            AddForeignKey("dbo.LeasersInformations", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeasersInformations", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.LeasersInformations", new[] { "UserId" });
            AlterColumn("dbo.LeasersInformations", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.LeasersInformations", "UserId");
            AddForeignKey("dbo.LeasersInformations", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
