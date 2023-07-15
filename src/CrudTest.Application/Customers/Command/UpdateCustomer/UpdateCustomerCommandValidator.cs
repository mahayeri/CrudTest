using CrudTest.Application.Common.Interfaces.Validations;
using CrudTest.Domain.Common.Errors;
using FluentValidation;

namespace CrudTest.Application.Customers.Command.UpdateCustomer;
public sealed class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator(ICustomerValidation customerValidation)
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Must(customerValidation.BeMobileNumber)
            .WithMessage(Errors.Customer.InvalidPhoneNumber.Description);

        RuleFor(x => x.BankAccountNumber)
            .NotEmpty()
            .Must(customerValidation.BeIban)
            .WithMessage(Errors.Customer.InvalidIban.Description);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MustAsync(customerValidation.BeUniqueEmailAsync)
            .WithMessage(Errors.Customer.UniqueEmail.Description);
    }
}
