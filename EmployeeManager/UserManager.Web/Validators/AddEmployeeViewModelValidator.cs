using FluentValidation;
using UserManager.Web.ViewModels;

namespace UserManager.Web.Validators;

public class AddEmployeeViewModelValidator : AbstractValidator<AddEmployeeViewModel>
{
    public AddEmployeeViewModelValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull().WithMessage("First name is required.")
            .NotEmpty().WithMessage("First name is required.")
            .MinimumLength(3).WithMessage("First name should contain at least 3 chars")
            .MaximumLength(100).WithMessage("First name should contain maximum 100 chars");
    }
}
