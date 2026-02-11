using Inboxly.Context;
using Inboxly.Dtos.MessagesByCategoryInTheProfileDtos;
using Inboxly.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inboxly.InboxlyViewComponent.ProfileSectionViewComponent
{
    public class MessageByCategoryInTheDashboard : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly InboxlyContext _ınboxlyContext;

        public MessageByCategoryInTheDashboard(UserManager<AppUser> userManager, InboxlyContext ınboxlyContext)
        {
            _userManager = userManager;
            _ınboxlyContext = ınboxlyContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var values = _ınboxlyContext.Messages.Include(z=>z.Categories).ToList()
                .Where(x => x.ReceiverMail == user.Email)
                .GroupBy(x => x.Categories.CategoryName)
                .Select(y => new MessageByCategory
                {
                    CategoryName = y.Key,
                    Count = y.Count(),
                }).ToList();

            ViewBag.TotalMessageCount = _ınboxlyContext.Messages.Count();
            ViewBag.TotalCategoryCount = _ınboxlyContext.Categories.Count();
            return View("~/Views/Shared/Components/ProfileSectionViewComponent/MessageByCategoryInTheDashboard.cshtml", values);
        }
    }
}
