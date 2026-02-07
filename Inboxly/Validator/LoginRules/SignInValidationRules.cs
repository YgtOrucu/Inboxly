using FluentValidation;
using Inboxly.Dtos.LoginDtos;
using Inboxly.Validator.GlobalRules;


namespace Inboxly.Validator.LoginRules
{
    public class SignInValidationRules : AbstractValidator<SignInDto>
    {
        public SignInValidationRules()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(GlobalValidationRules.NotEmpty("Email")).
              MinimumLength(3).WithMessage(GlobalValidationRules.MinLenght(3, "Email")).
              MaximumLength(30).WithMessage(GlobalValidationRules.MaxLenght(30, "Email")).
              Matches(GlobalValidationRules.ForEmail).WithMessage(GlobalValidationRules.Email("Email"));

            RuleFor(x => x.Password).NotEmpty().WithMessage(GlobalValidationRules.NotEmpty("Password")).
               MinimumLength(6).WithMessage(GlobalValidationRules.MinLenght(6, "Password"));
        }
    }
}
