using ETicaret.Application.CQRS.Commands.Auths;
using FluentValidation;

namespace ETicaret.API.Validations;

public class LoginUserValidator : AbstractValidator<LoginUserCommandRequest>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("E Mail Adresi Boş Geçilemez");
        RuleFor(x=>x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez");
        
        RuleFor(x=>x.Email).EmailAddress().WithMessage("Email Adresinizi Formatına Uygun Yazınız");
        RuleFor(x => x.Password).MinimumLength(7).WithMessage("Şifreniz Minimum 7 Karakter Olmalıdır");
    }
}