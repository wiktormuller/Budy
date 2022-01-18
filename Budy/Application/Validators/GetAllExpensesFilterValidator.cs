using Budy.Application.Expenses.Filters;
using FluentValidation;

namespace Budy.Application.Validators
{
    public class GetAllExpensesFilterValidator : AbstractValidator<GetAllExpensesFilter>
    {
        public GetAllExpensesFilterValidator()
        {
            RuleFor(filter => filter.CategoryId)
                .GreaterThan(0);
        }
    }
}