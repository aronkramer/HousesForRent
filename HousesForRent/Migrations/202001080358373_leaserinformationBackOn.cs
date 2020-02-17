namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leaserinformationBackOn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeasersInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ContactInfo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Bedrooms = c.Int(nullable: false),
                        Bathrooms = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Comments = c.String(),
                        Date = c.DateTime(),
                        Furnished = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeasersInformations", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.LeasersInformations", new[] { "UserId" });
            DropTable("dbo.LeasersInformations");
        }
    }
}
