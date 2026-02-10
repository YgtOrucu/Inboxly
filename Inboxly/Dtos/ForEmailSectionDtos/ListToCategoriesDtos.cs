namespace Inboxly.Dtos.ForEmailSectionDtos
{
    public class ListToCategoriesDtos
    {
        public int MessageId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Details { get; set; }
        public string? CategoryName { get; set; }
        public DateTime SendDate { get; set; }
    }
}
