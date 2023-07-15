using CrudTest.Application.Common.Interfaces.Messaging;
using CrudTest.Application.Common.Interfaces.Persistence;
using CrudTest.Domain.CustomerAggregate;
using ErrorOr;

namespace CrudTest.Application.Customers.Command.CreateCustomer;
internal sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, string>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<string>> Handle(
        CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = Customer.Create(
            request.FirstName,
            request.LastName,
            request.DateOfBirth,
            request.PhoneNumber,
            request.Email,
            request.BankAccountNumber);

        await _customerRepository.Add(customer);

        return customer.Id.Value.ToString();
    }
}
