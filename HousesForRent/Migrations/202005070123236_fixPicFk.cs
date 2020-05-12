namespace HousesForRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixPicFk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LeasersInformations", "PicturesId", "dbo.Pictures");
            DropIndex("dbo.LeasersInformations", new[] { "PicturesId" });
            DropColumn("dbo.LeasersInformations", "PicturesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LeasersInformations", "PicturesId", c => c.Int());
            CreateIndex("dbo.LeasersInformations", "PicturesId");
            AddForeignKey("dbo.LeasersInformations", "PicturesId", "dbo.Pictures", "Id");
        }
    }
}
