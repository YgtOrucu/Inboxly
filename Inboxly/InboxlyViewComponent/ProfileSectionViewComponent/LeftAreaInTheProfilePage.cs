using AutoMapper;
using Inboxly.Dtos.ForLeftAreaProfileDto;
using Inboxly.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inboxly.InboxlyViewComponent.ProfileSectionViewComponent
{
    public class LeftAreaInTheProfilePage : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public LeftAreaInTheProfilePage(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var ListProfile = _mapper.Map<ResultForLeftSectionDto>(user);
            return View("~/Views/Shared/Components/ProfileSectionViewComponent/LeftAreaInTheProfilePage.cshtml", ListProfile);
        }
    }
}
