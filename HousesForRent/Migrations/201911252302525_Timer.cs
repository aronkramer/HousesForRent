namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Timer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Timers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Days = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Timers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Timers", new[] { "UserId" });
            DropTable("dbo.Timers");
        }
    }
}
