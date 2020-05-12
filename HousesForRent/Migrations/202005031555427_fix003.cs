namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix003 : DbMigration
    {
        public override void Up()
        {
          
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PictureId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
