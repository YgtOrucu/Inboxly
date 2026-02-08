using Inboxly.Entities;

namespace Inboxly.Dtos.MessageAreaInTheNavbarDto
{
    public class MessageAreaSectionDto
    {
        public int AllMessageCount { get; set; }
        public List<MessagePreviewDto> Messages { get; set; }
    }
}
