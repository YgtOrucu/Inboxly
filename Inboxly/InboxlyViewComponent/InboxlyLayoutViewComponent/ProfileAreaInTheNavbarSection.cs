using AutoMapper;
using Inboxly.Context;
using Inboxly.Dtos.ProfileAreaInTheNavbarDto;
using Inboxly.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inboxly.InboxlyViewComponent.InboxlyLayoutViewComponent
{
    public class ProfileAreaInTheNavbarSection : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly InboxlyContext _ınboxlyContext;
        private readonly IMapper _mapper;

        public ProfileAreaInTheNavbarSection(UserManager<AppUser> userManager, InboxlyContext ınboxlyContext, IMapper mapper)
        {
            _userManager = userManager;
            _ınboxlyContext = ınboxlyContext;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userProfile = _mapper.Map<ProfileAreaSectionDto>(user);
            return View("~/Views/Shared/Components/InboxlyLayoutViewComponent/ProfileAreaInTheNavbarSection.cshtml", userProfile);
        }
    }
}
