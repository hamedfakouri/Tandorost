using System.Collections.Generic;
using System.Linq;
using Framework.Domain;
using Ticketing.Domain.Model.Users;

namespace Ticketing.Domain.Model.Tickets.TicketComment
{

    public class TicketComment : EntityBase<long>
    {
        public string Comment { get; set; }
        public string DateTime { get; set; }
        public long UserId { get; set; }
        public User Users { get; set; }
        public long TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public List<CommentAttachment> CommentAttachments { get; set; }
        public TicketComment()
        {

        }

        public TicketComment(string comment, string dateTime,List<CommentAttachment> commentAttachments, long userId)
        {
            Comment = comment;
            DateTime = dateTime;
            UserId = userId;
            if (commentAttachments !=null)
            {
                CommentAttachments = new List<CommentAttachment>();
                foreach (var attachment in commentAttachments)
                {
                    this.CommentAttachments.Add(attachment);
                }
            }
        }

        public string CreateTicketAttachment(CommentAttachment ticketAttachment)
        {
            CommentAttachments = new List<CommentAttachment>();
            this.CommentAttachments.Add(ticketAttachment);
            return ticketAttachment.FileUri;
        }
        public List<CommentAttachment> GetTicketAttachment(long ticketCommentId)
        {
            var myTicketComments = this.CommentAttachments.Where(x => x.TicketCommentId == ticketCommentId).ToList();
            return myTicketComments;
        }

        //public void EditTicketAttachment(TicketAttachment ticketAttachment)
        //{
        //    var ticketAttachments = this.TicketAttachments.SingleOrDefault(x => x.TicketId == ticketAttachment.TicketId);

        //    ticketAttachments.DateTime = ticketAttachment.DateTime;
        //    ticketAttachments.SrcFile = ticketAttachment.SrcFile;
        //    ticketAttachments.TicketDescription = ticketAttachment.TicketDescription;
        //}
    }
}
