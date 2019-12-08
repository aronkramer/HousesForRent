namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moveTimer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Timers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Timers", new[] { "UserId" });
            AddColumn("dbo.LeasersInformations", "Date", c => c.DateTime(nullable: false));
            DropTable("dbo.Timers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Timers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Days = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.LeasersInformations", "Date");
            CreateIndex("dbo.Timers", "UserId");
            AddForeignKey("dbo.Timers", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
