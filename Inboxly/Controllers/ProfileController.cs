using AutoMapper;
using Inboxly.Dtos.LoginDtos;
using Inboxly.Dtos.SettingAreaInTheProfilePageDto;
using Inboxly.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Inboxly.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public ProfileController(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public IActionResult Profil()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ProfileSettings(SettingInTheProfilePageDto settingInTheProfilePageDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userPassword = user.PasswordHash;

            if (settingInTheProfilePageDto.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(settingInTheProfilePageDto.ImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var uploadPath = Path.Combine(resource, "wwwroot", "images");

                var saveLocation = Path.Combine(uploadPath, imageName);
                if (!string.IsNullOrEmpty(user.AvatarImage))
                {
                    var oldImagePath = Path.Combine(
                        resource,
                        "wwwroot",
                        user.AvatarImage.TrimStart('/')
                    );

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using var stream = new FileStream(saveLocation, FileMode.Create);
                await settingInTheProfilePageDto.ImageFile.CopyToAsync(stream);

                settingInTheProfilePageDto.AvatarImage = "/images/" + imageName;
            }
            else
            {
                settingInTheProfilePageDto.AvatarImage = user.AvatarImage;
            }

            _mapper.Map(settingInTheProfilePageDto, user);

            if (settingInTheProfilePageDto.Password != null)
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, settingInTheProfilePageDto.Password);
            string changepassword = user.PasswordHash;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                if (userPassword != changepassword)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    await _signInManager.RefreshSignInAsync(user);
                    return RedirectToAction("Profil", "Profile");
                }

            }
            return View();
        }
    }
}
