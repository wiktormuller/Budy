using Budy.Application.Income.Filters;
using FluentValidation;

namespace Budy.Application.Validators
{
    public class GetAllIncomesFilterValidator : AbstractValidator<GetAllIncomesFilter>
    {
        public GetAllIncomesFilterValidator()
        {
            RuleFor(filter => filter.CategoryId)
                .GreaterThan(0);
        }
    }
}