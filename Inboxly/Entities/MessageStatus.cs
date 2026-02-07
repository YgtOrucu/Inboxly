namespace Inboxly.Entities
{
    public class MessageStatus
    {
        public int MessageStatusId { get; set; }
        public string? Name { get; set; }
        public List<Message> Messages { get; set; }
    }
}
