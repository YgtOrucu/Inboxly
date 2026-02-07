using FluentValidation;
using Inboxly.Dtos.LoginDtos;
using Inboxly.Validator.GlobalRules;

namespace Inboxly.Validator.LoginRules
{
    public class SignUpValidationRules : AbstractValidator<SignUpDto>
    {
        public SignUpValidationRules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(GlobalValidationRules.NotEmpty("Name")).
               MinimumLength(3).WithMessage(GlobalValidationRules.MinLenght(3, "Name")).
               MaximumLength(30).WithMessage(GlobalValidationRules.MaxLenght(30, "Name"));

            RuleFor(x => x.Surname).NotEmpty().WithMessage(GlobalValidationRules.NotEmpty("Surname")).
               MinimumLength(3).WithMessage(GlobalValidationRules.MinLenght(3, "Surname")).
               MaximumLength(30).WithMessage(GlobalValidationRules.MaxLenght(30, "Surname"));

            RuleFor(x => x.UserName).NotEmpty().WithMessage(GlobalValidationRules.NotEmpty("Username")).
               MinimumLength(3).WithMessage(GlobalValidationRules.MinLenght(3, "Username")).
               MaximumLength(30).WithMessage(GlobalValidationRules.MaxLenght(30, "Username"));

            RuleFor(x => x.Email).NotEmpty().WithMessage(GlobalValidationRules.NotEmpty("Email")).
               MinimumLength(3).WithMessage(GlobalValidationRules.MinLenght(3, "Email")).
               MaximumLength(30).WithMessage(GlobalValidationRules.MaxLenght(30, "Email")).
               Matches(GlobalValidationRules.ForEmail).WithMessage(GlobalValidationRules.Email("Email"));

            RuleFor(x => x.Password).NotEmpty().WithMessage(GlobalValidationRules.NotEmpty("Password")).
               MinimumLength(6).WithMessage(GlobalValidationRules.MinLenght(6, "Password")).
               Equal(x => x.ConfirmPassword).WithMessage("Şifreler birbiri ile uyuşmuyor.Lütfen kontrol ediniz !!!");

            RuleFor(x => x.ImageFile).NotEmpty().WithMessage(GlobalValidationRules.NotEmpty("ImageFile"));
        }
    }
}
