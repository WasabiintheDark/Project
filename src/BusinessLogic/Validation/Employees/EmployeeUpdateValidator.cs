using CompanyWorkload.Domain.DTO.Employees;
using FluentValidation;

namespace CompanyWorkload.BusinessLogic.Validation.Employees;

public class EmployeeUpdateValidator : AbstractValidator<EmployeeUpdateDto>
{
    public EmployeeUpdateValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(256);
        RuleFor(x => x.HireDate).LessThanOrEqualTo(DateTime.UtcNow.Date.AddDays(1));
        RuleFor(x => x.DepartmentId).GreaterThan(0);
        RuleFor(x => x.PositionId).GreaterThan(0);
    }
}
