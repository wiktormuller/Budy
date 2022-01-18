using System.Data;
using Budy.Application.Categories.Requests;
using FluentValidation;

namespace Budy.Application.Validators
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotNull()
                .Length(1, 100);
        }
    }
}