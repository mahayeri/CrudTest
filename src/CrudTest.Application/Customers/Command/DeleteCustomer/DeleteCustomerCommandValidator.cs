using FluentValidation;

namespace CrudTest.Application.Customers.Command.DeleteCustomer;
public sealed class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
