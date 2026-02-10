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

        public enum MessageStatus
        {
            Inbox = 1,
            Sent = 2,
            Draft = 3,
            Starred = 4,
            Trash = 6
        }

        public enum MessageCategories
        {
            Job = 1,
            Commerce = 2,
            Family = 3,
            Friendly = 4,
        }

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

        public IActionResult ListDrafts()
        {
            return View();
        }
        public async Task<IActionResult> ChangeStarsMessages(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var message = _ınboxlyContext.Messages
                .FirstOrDefault(x => x.MessageId == id);

            if (message == null)
                return NotFound();

            var redirect = message.MessageStatusId == (int)MessageStatus.Inbox ? nameof(Inbox) : nameof(SendBox);

            if (message.MessageStatusId == (int)MessageStatus.Inbox ||
                message.MessageStatusId == (int)MessageStatus.Sent)
            {
                message.MessageStatusId = (int)MessageStatus.Starred;
            }
            else if (message.MessageStatusId == (int)MessageStatus.Starred)
            {
                if (message.ReceiverMail == user.Email)
                {
                    message.MessageStatusId = (int)MessageStatus.Inbox;
                    redirect = nameof(Inbox);
                }
                else
                {
                    message.MessageStatusId = (int)MessageStatus.Sent;
                    redirect = nameof(SendBox);
                }
            }

            _ınboxlyContext.SaveChanges();
            return RedirectToAction(redirect);
        }
        public async Task<IActionResult> ListStarsMessages()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var usermail = user.Email;
            var getstarsmessage = _ınboxlyContext.Messages.Include(y => y.Categories).Where(x => x.MessageStatusId == (int)MessageStatus.Starred).ToList();

            var liststarsmessage = getstarsmessage.Select(x => new ForStarsMessageDtos
            {
                MessageId = x.MessageId,
                Name = x.ReceiverMail == usermail ? x.SenderName : x.ReceiverName,
                Surname = x.ReceiverMail == usermail ? x.SenderSurname : x.ReceiverSurname,
                Details = x.Details,
                CategoryName = x.Categories.CategoryName,
                SendDate = x.SendDate
            });
            return View(liststarsmessage);
        }

        public async Task<IActionResult> ListDeletedMessages()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var usermail = user.Email;
            var getdeletemessages = _ınboxlyContext.Messages.Include(y => y.Categories).Where(x => x.MessageStatusId == (int)MessageStatus.Trash).ToList();

            var listdeletemessages = getdeletemessages.Select(x => new ForDeleteMessageDtos
            {
                MessageId = x.MessageId,
                Name = x.ReceiverMail == usermail ? x.SenderName : x.ReceiverName,
                Surname = x.ReceiverMail == usermail ? x.SenderSurname : x.ReceiverSurname,
                Details = x.Details,
                CategoryName = x.Categories.CategoryName,
                SendDate = x.SendDate
            });
            return View(listdeletemessages);
        }

        public IActionResult DeleteMessage(int itemid)
        {
            var deletedmessage = _ınboxlyContext.Messages.Find(itemid);
            string redirect = deletedmessage.MessageStatusId switch
            {
                (int)MessageStatus.Inbox => nameof(Inbox),
                (int)MessageStatus.Sent => nameof(SendBox),
                (int)MessageStatus.Starred => nameof(ListStarsMessages),
                (int)MessageStatus.Draft => nameof(ListDrafts),
                _ => nameof(Inbox)
            };

            deletedmessage.MessageStatusId = (int)MessageStatus.Trash;
            _ınboxlyContext.SaveChanges();
            return RedirectToAction(redirect);

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





        public async Task<IActionResult> ListJobMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var usermail = user.Email;
            var getJobMessages = _ınboxlyContext.Messages.Include(y => y.Categories).Where(x => x.CategoryId == (int)MessageCategories.Job).ToList();

            var listJobMessages = getJobMessages.Select(x => new ListToCategoriesDtos
            {
                MessageId = x.MessageId,
                Name = x.ReceiverMail == usermail ? x.SenderName : x.ReceiverName,
                Surname = x.ReceiverMail == usermail ? x.SenderSurname : x.ReceiverSurname,
                Details = x.Details,
                CategoryName = x.Categories.CategoryName,
                SendDate = x.SendDate
            });
            return View(listJobMessages);
        }
        public async Task<IActionResult> ListCommerceMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var usermail = user.Email;
            var getCommerceMessages = _ınboxlyContext.Messages.Include(y => y.Categories).Where(x => x.CategoryId == (int)MessageCategories.Commerce).ToList();

            var listCommerceMessages = getCommerceMessages.Select(x => new ListToCategoriesDtos
            {
                MessageId = x.MessageId,
                Name = x.ReceiverMail == usermail ? x.SenderName : x.ReceiverName,
                Surname = x.ReceiverMail == usermail ? x.SenderSurname : x.ReceiverSurname,
                Details = x.Details,
                CategoryName = x.Categories.CategoryName,
                SendDate = x.SendDate
            });
            return View(listCommerceMessages);
        }
        public async Task<IActionResult> ListFamilyMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var usermail = user.Email;
            var getFamilyMessages = _ınboxlyContext.Messages.Include(y => y.Categories).Where(x => x.CategoryId == (int)MessageCategories.Family).ToList();

            var listFamilyMessages = getFamilyMessages.Select(x => new ListToCategoriesDtos
            {
                MessageId = x.MessageId,
                Name = x.ReceiverMail == usermail ? x.SenderName : x.ReceiverName,
                Surname = x.ReceiverMail == usermail ? x.SenderSurname : x.ReceiverSurname,
                Details = x.Details,
                CategoryName = x.Categories.CategoryName,
                SendDate = x.SendDate
            });
            return View(listFamilyMessages);
        }
        public async Task<IActionResult> ListFriendlyMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var usermail = user.Email;
            var getFriendlyMessages = _ınboxlyContext.Messages.Include(y => y.Categories).Where(x => x.CategoryId == (int)MessageCategories.Friendly).ToList();

            var listFriendlyMessages = getFriendlyMessages.Select(x => new ListToCategoriesDtos
            {
                MessageId = x.MessageId,
                Name = x.ReceiverMail == usermail ? x.SenderName : x.ReceiverName,
                Surname = x.ReceiverMail == usermail ? x.SenderSurname : x.ReceiverSurname,
                Details = x.Details,
                CategoryName = x.Categories.CategoryName,
                SendDate = x.SendDate
            });
            return View(listFriendlyMessages);
        }
    }
}
