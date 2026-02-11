using Inboxly.Context;
using Inboxly.Dtos.MessageStatisticInTheProfileSectionDtos;
using Inboxly.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inboxly.InboxlyViewComponent.ProfileSectionViewComponent
{
    public class MessageStatisticInTheDashboard :ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly InboxlyContext _ınboxlyContext;

        public MessageStatisticInTheDashboard(UserManager<AppUser> userManager, InboxlyContext ınboxlyContext)
        {
            _userManager = userManager;
            _ınboxlyContext = ınboxlyContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = new MessageStatistic
            {
                InboxCount = _ınboxlyContext.Messages.Where(x => x.MessageStatusId == 1).Count(),
                SendBoxCount = _ınboxlyContext.Messages.Where(x => x.MessageStatusId == 2).Count(),
                DraftsCount = _ınboxlyContext.Messages.Where(x => x.MessageStatusId == 3).Count(),
                StarsMessagesCount = _ınboxlyContext.Messages.Where(x => x.MessageStatusId == 4).Count()
            };
            return View("~/Views/Shared/Components/ProfileSectionViewComponent/MessageStatisticInTheDashboard.cshtml", values);
        }
    }
}
