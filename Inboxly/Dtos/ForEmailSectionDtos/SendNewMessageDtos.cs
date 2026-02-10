namespace Inboxly.Dtos.ForEmailSectionDtos
{
    public class SendNewMessageDtos
    {
        public string ReceiverName { get; set; }
        public string ReceiverSurname { get; set; }
        public string ReceiverMail { get; set; }
        public string SenderMail { get; set; }
        public string SenderName { get; set; }
        public string SenderSurname { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public DateTime SendDate { get; set; }
        public int MessageStatusId { get; set; }
        public int CategoryId { get; set; }
    }
}
