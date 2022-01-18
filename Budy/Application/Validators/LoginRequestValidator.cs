using Budy.Application.Identity.Requests;
using FluentValidation;

namespace Budy.Application.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(request => request.Password)
                .NotNull()
                .Length(1, 100);

            RuleFor(request => request.Username)
                .NotNull()
                .Length(1, 100);
        }
    }
}