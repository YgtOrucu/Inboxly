using Microsoft.AspNetCore.Mvc;

namespace Inboxly.InboxlyViewComponent.InboxlyLayoutViewComponent
{
    public class InboxlyHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/InboxlyLayoutViewComponent/InboxlyHead.cshtml");
        }

    }
}
