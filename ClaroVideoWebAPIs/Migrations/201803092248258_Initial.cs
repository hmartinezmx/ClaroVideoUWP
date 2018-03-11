namespace ClaroVideoWebAPIs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RatingCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        TitleOriginal = c.String(),
                        Description = c.String(nullable: false),
                        DescriptionLarge = c.String(),
                        URLImageBase = c.String(nullable: false),
                        Duration = c.String(),
                        Date = c.DateTime(nullable: false),
                        VotesAverage = c.Byte(nullable: false),
                        Actors = c.String(),
                        Directors = c.String(),
                        RatingCodeId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.RatingCodes", t => t.RatingCodeId, cascadeDelete: true)
                .Index(t => t.RatingCodeId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VCards", "RatingCodeId", "dbo.RatingCodes");
            DropForeignKey("dbo.VCards", "CategoryId", "dbo.Categories");
            DropIndex("dbo.VCards", new[] { "CategoryId" });
            DropIndex("dbo.VCards", new[] { "RatingCodeId" });
            DropTable("dbo.VCards");
            DropTable("dbo.RatingCodes");
            DropTable("dbo.Categories");
        }
    }
}
