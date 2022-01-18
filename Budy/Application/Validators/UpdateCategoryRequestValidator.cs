using Budy.Application.Categories.Requests;
using FluentValidation;

namespace Budy.Application.Validators
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(request =>  request.Name)
                .NotNull()
                .Length(1, 100);
        }
    }
}