namespace Ticketing.Application.Contract.Tickets
{
    public class CommentAttachmentDto
    {
        public long Id { get; set; }
        public string FileUri { get; set; }
        public string FileName  { get; set; }
        public string DateTime { get; set; }
    }
}
