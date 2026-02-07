using Microsoft.AspNetCore.Mvc;

namespace Inboxly.InboxlyViewComponent.InboxlyLayoutViewComponent
{
    public class MessageAreaInTheNavbarSection : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/InboxlyLayoutViewComponent/MessageAreaInTheNavbarSection.cshtml");
        }
    }
}
