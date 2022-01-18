using Budy.Application.Expenses.Requests;
using FluentValidation;

namespace Budy.Application.Validators
{
    public class UpdateExpenseRequestValidator : AbstractValidator<UpdateExpenseRequest>
    {
        public UpdateExpenseRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotNull()
                .Length(1, 100);

            RuleFor(request => request.Amount)
                .NotEmpty()
                .InclusiveBetween(1, 1_000_000);

            RuleFor(request => request.CategoryId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(request => request.OccuredAt)
                .NotEmpty();
        }
    }
}