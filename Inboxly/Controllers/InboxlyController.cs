using Microsoft.AspNetCore.Mvc;

namespace Inboxly.Controllers
{
    public class InboxlyController : Controller
    {
        public IActionResult Inbox()
        {
            return View();
        }
    }
}
