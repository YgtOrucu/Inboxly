using AutoMapper;
using Inboxly.Dtos.ForLeftAreaProfileDto;
using Inboxly.Dtos.SettingAreaInTheProfilePageDto;
using Inboxly.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inboxly.InboxlyViewComponent.ProfileSectionViewComponent
{
    public class SettingInTheProfilePage : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public SettingInTheProfilePage(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var getusers = _mapper.Map<SettingInTheProfilePageDto>(user);
            return View("~/Views/Shared/Components/ProfileSectionViewComponent/SettingInTheProfilePage.cshtml", getusers);
        }
    }
}
