using Microsoft.AspNetCore.Mvc;

namespace Inboxly.Controllers
{
    public class StartupPageController : Controller
    {
        public IActionResult StartPage()
        {
            return View();
        }
    }
}
