using AutoMapper;
using Inboxly.Context;
using Inboxly.Dtos.ForEmailSectionDtos;
using Inboxly.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Inboxly.Controllers
{
    public class InboxlyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly InboxlyContext _ınboxlyContext;
        private readonly IMapper _mapper;

        public InboxlyController(UserManager<AppUser> userManager, InboxlyContext ınboxlyContext, IMapper mapper)
        {
            _userManager = userManager;
            _ınboxlyContext = ınboxlyContext;
            _mapper = mapper;
        }

        public IActionResult Inbox()
        {
            var getınbox = _ınboxlyContext.Messages.Include(y => y.Categories).Where(x => x.MessageStatusId == 1).ToList();

            var Listınbox = _mapper.Map<List<ForInboxDtos>>(getınbox);

            return View(Listınbox);
        }

        public IActionResult SendBox()
        {
            var getsendbox = _ınboxlyContext.Messages.Include(y => y.Categories).Where(x => x.MessageStatusId == 2).ToList();
            var ListSendbox = _mapper.Map<List<ForSendboxDtos>>(getsendbox);
            return View(ListSendbox);
        }

        public IActionResult Drafts()
        {
            return View();
        }
        public IActionResult ChangeStarsMessages(int id)
        {
            var redirect = "SendBox";
            var getmessage = _ınboxlyContext.Messages.Where(x => x.MessageId == id).FirstOrDefault();
            if (getmessage.MessageStatusId == 1)
                redirect = "Inbox";
            getmessage.MessageStatusId = 4;
            _ınboxlyContext.Messages.Update(getmessage);
            _ınboxlyContext.SaveChanges();
            return RedirectToAction(redirect);
        }

        public IActionResult DeletedMessages()
        {
            return View();
        }

        public IActionResult SendNewMessage()
        {
            return View();
        }


        public IActionResult MessageDetails(int itemid)
        {
            var getmessage = _ınboxlyContext.Messages.Where(x => x.MessageId == itemid).FirstOrDefault();
            var messageDetails = _mapper.Map<EmailDetailsDto>(getmessage);
            return View(messageDetails);
        }

    }
}
