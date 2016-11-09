namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDTO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "OriginalDateTime", c => c.DateTime());
            AddColumn("dbo.Notifications", "OriginalVenue", c => c.String());
            DropColumn("dbo.Notifications", "OriginatlDateTime");
            DropColumn("dbo.Notifications", "OrignalVenue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "OrignalVenue", c => c.String());
            AddColumn("dbo.Notifications", "OriginatlDateTime", c => c.DateTime());
            DropColumn("dbo.Notifications", "OriginalVenue");
            DropColumn("dbo.Notifications", "OriginalDateTime");
        }
    }
}
