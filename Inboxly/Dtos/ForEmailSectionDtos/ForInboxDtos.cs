namespace Inboxly.Dtos.ForEmailSectionDtos
{
    public class ForInboxDtos
    {
        public int MessageId { get; set; }
        public string? SenderName { get; set; }
        public string? SenderSurname { get; set; }
        public string? Details { get; set; }
        public string? CategoryName { get; set; }
        public DateTime SendDate { get; set; }
    }
}
