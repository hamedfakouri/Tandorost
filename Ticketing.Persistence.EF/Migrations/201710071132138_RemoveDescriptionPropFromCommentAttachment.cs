namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDescriptionPropFromCommentAttachment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CommentAttachments", "TicketDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CommentAttachments", "TicketDescription", c => c.String());
        }
    }
}
