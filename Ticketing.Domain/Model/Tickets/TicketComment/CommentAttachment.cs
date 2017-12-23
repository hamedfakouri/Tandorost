using Framework.Domain;

namespace Ticketing.Domain.Model.Tickets.TicketComment
{
    public class CommentAttachment:EntityBase<long>
    {
        public string FileUri { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string DateTime { get; set; }
        public long TicketCommentId { get; set; }
        public TicketComment TicketComment { get; set; }

        public CommentAttachment(string fileName, string fileUri)
        {
            if (fileUri==null)
                return;
            FileName = fileName;
            FileUri = fileUri;
        }

        protected CommentAttachment()
        {
            
        }
    }
}
