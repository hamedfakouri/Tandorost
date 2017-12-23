namespace Ticketing.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTicketAttachmentNameToTicketCommentAndAddPropFileNameAndFileSize : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketAttachments", "TicketCommentId", "dbo.TicketComments");
            DropIndex("dbo.TicketAttachments", new[] { "TicketCommentId" });
            CreateTable(
                "dbo.CommentAttachments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FileUri = c.String(),
                        FileName = c.String(),
                        FileSize = c.Long(nullable: false),
                        TicketDescription = c.String(),
                        DateTime = c.String(),
                        TicketCommentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketComments", t => t.TicketCommentId, cascadeDelete: true)
                .Index(t => t.TicketCommentId);
            
            DropTable("dbo.TicketAttachments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TicketAttachments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SrcFile = c.String(),
                        TicketDescription = c.String(),
                        DateTime = c.String(),
                        TicketCommentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.CommentAttachments", "TicketCommentId", "dbo.TicketComments");
            DropIndex("dbo.CommentAttachments", new[] { "TicketCommentId" });
            DropTable("dbo.CommentAttachments");
            CreateIndex("dbo.TicketAttachments", "TicketCommentId");
            AddForeignKey("dbo.TicketAttachments", "TicketCommentId", "dbo.TicketComments", "Id", cascadeDelete: true);
        }
    }
}
