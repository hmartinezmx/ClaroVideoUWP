namespace ClaroVideoWebAPIs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VCards", "URLImageH", c => c.String(nullable: false));
            AddColumn("dbo.VCards", "URLImageV", c => c.String());
            AddColumn("dbo.VCards", "Year", c => c.Int(nullable: false));
            DropColumn("dbo.VCards", "URLImageBase");
            DropColumn("dbo.VCards", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VCards", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.VCards", "URLImageBase", c => c.String(nullable: false));
            DropColumn("dbo.VCards", "Year");
            DropColumn("dbo.VCards", "URLImageV");
            DropColumn("dbo.VCards", "URLImageH");
        }
    }
}
