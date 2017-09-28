namespace JRO.Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDateUpdateToDateUpdatedPostModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "DateUpdated", c => c.DateTime());
            DropColumn("dbo.Posts", "DateUpdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "DateUpdate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Posts", "DateUpdated");
        }
    }
}
