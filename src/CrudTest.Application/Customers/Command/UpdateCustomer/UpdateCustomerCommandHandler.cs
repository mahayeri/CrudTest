using CrudTest.Application.Common.Interfaces.Messaging;
using CrudTest.Application.Common.Interfaces.Persistence;
using CrudTest.Domain.Common.Errors;
using CrudTest.Domain.CustomerAggregate.ValueObjects;
using ErrorOr;

namespace CrudTest.Application.Customers.Command.UpdateCustomer;
internal sealed class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(CustomerId.Create(request.Id), cancellationToken);

        if (customer is null)
        {
            return Errors.Customer.CustomerNotFound;
        }

        customer.Update(
            request.FirstName,
            request.LastName,
            request.DateOfBirth,
            request.PhoneNumber,
            request.Email,
            request.BankAccountNumber);

        await _customerRepository.Update(customer);

        return true;
    }
}
