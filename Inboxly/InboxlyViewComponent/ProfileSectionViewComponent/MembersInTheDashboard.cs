using AutoMapper;
using Inboxly.Dtos.GetMembersInTheProfileSection;
using Inboxly.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inboxly.InboxlyViewComponent.ProfileSectionViewComponent
{
    public class MembersInTheDashboard : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public MembersInTheDashboard(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.Users.ToListAsync();
            var getmembers = _mapper.Map<List<GetMember>>(user);
            return View("~/Views/Shared/Components/ProfileSectionViewComponent/MembersInTheDashboard.cshtml", getmembers);
        }
    }
}
