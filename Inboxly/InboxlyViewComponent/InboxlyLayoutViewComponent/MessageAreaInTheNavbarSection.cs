using Inboxly.Context;
using Inboxly.Dtos.MessageAreaInTheNavbarDto;
using Inboxly.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inboxly.InboxlyViewComponent.InboxlyLayoutViewComponent
{
    public class MessageAreaInTheNavbarSection : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly InboxlyContext _ınboxlyContext;

        public MessageAreaInTheNavbarSection(UserManager<AppUser> userManager, InboxlyContext ınboxlyContext)
        {
            _userManager = userManager;
            _ınboxlyContext = ınboxlyContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var messages = new MessageAreaSectionDto
            {
                AllMessageCount = _ınboxlyContext.Messages.Count(),
                Messages = _ınboxlyContext.Messages.Where(x => x.MessageStatusId == 1).OrderByDescending(y => y.SendDate).Take(5).Select(z => new MessagePreviewDto
                {
                    NameSurnameHead = z.SenderName.Substring(0, 1) + z.SenderSurname.Substring(0, 1),
                    NameSurname = z.SenderName + " " + z.SenderSurname,
                    Subject = z.Subject,
                    Date = z.SendDate.ToString("dd-MMM-yyyy")
                }).ToList()
            };

            return View("~/Views/Shared/Components/InboxlyLayoutViewComponent/MessageAreaInTheNavbarSection.cshtml", messages);
        }
    }
}
