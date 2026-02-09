namespace Inboxly.Dtos.ForEmailSectionDtos
{
    public class ForSendboxDtos
    {
        public int MessageId { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverSurname { get; set; }
        public string? Details { get; set; }
        public string? CategoryName { get; set; }
        public DateTime SendDate { get; set; }
    }
}
