using AutoMapper;
using Inboxly.Dtos.ConfirmCodeDto;
using Inboxly.Dtos.LoginDtos;
using Inboxly.Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Inboxly.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region EmailVerification
        [HttpGet]
        public IActionResult EmailVerification()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmailVerification(ConfirmCodeDto confirmCodeDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
                return View("SignIn");

            if(user.ConfirmCode == confirmCodeDto.ConfirmCode)
            {
                user.ConfirmCode = 0;
                user.TwoFactorEnabled = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("InboxEmail", "Email");
            }
            else
            {
                user.ConfirmCode = 0;
                await _userManager.UpdateAsync(user);
                ModelState.AddModelError("", "Doğrulama kodu hatalı.Kodunuz sıfırlanmıştır.Lütfen tekrar giriş yapınız");
                return View(confirmCodeDto);
            }
        }
        #endregion

        #region SignIn

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            if (!ModelState.IsValid)
                return View(signInDto);

            var user = await _userManager.FindByEmailAsync(signInDto.Email);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, signInDto.Password, signInDto.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!user.TwoFactorEnabled)
                    {
                        Random random = new Random();
                        var confirmcode = random.Next(100000, 999999);
                        user.ConfirmCode = confirmcode;
                        await _userManager.UpdateAsync(user);
                        await SendConfirmCodeToUser(signInDto.Email, confirmcode);
                        return RedirectToAction("EmailVerification");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mail veya Şifre Hatalı !!!");
                    return View(signInDto);
                }
                return RedirectToAction("InboxEmail", "Email");
            }
            else
            {
                ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı.Lütfen girilen değerleri kontrol ediniz");
                return View(signInDto);
            }

        }

        private async Task SendConfirmCodeToUser(string email, int confirmcode)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Admin", "orucuyigit@gmail.com"));
            mimeMessage.To.Add(new MailboxAddress("User", email));
            mimeMessage.Subject = "Giriş Doğrulama Kodu";
            var bodybuilder = new BodyBuilder
            {
                TextBody = $"Giriş doğrulama kodunuz : {confirmcode}"
            };
            mimeMessage.Body = bodybuilder.ToMessageBody();


            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("orucuyigit@gmail.com", "iird tqib syqm yprr");
            await client.SendAsync(mimeMessage);
            await client.DisconnectAsync(true);
        }

        #endregion

        #region SignUp
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            if (!ModelState.IsValid)
                return View(signUpDto);

            var newuser = _mapper.Map<AppUser>(signUpDto);
            var result = await _userManager.CreateAsync(newuser, signUpDto.Password);

            if (result.Succeeded)
            {

                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(signUpDto.ImageFile.Name);
                var imageName = Guid.NewGuid() + extension;
                var uploadPath = Path.Combine(resource, "wwwroot", "images");

                var saveLocation = Path.Combine(uploadPath, imageName);

                using var stream = new FileStream(saveLocation, FileMode.Create);
                await signUpDto.ImageFile.CopyToAsync(stream);

                newuser.AvatarImage = "/images/" + imageName;
                await _userManager.UpdateAsync(newuser);

                return RedirectToAction("SignIn");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(signUpDto);
        }

        #endregion
    }
}
