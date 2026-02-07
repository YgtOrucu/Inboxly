using Microsoft.AspNetCore.Mvc;

namespace Inboxly.InboxlyViewComponent.InboxlyLayoutViewComponent
{
    public class InboxlyHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/InboxlyLayoutViewComponent/InboxlyHeader.cshtml");
        }
    }
}
