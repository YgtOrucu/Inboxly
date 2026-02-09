namespace Inboxly.Dtos.ForEmailSectionDtos
{
    public class LeftBarInTheMailOperationsDto
    {
        public int InboxCount { get; set; }
        public int StarsMessagesCount { get; set; }
        public int DraftsCount { get; set; }
        public int SendBoxCount { get; set; }
        public int DeletedMessagesCount { get; set; }
    }
}
